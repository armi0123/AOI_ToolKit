using AOI_Tool.Core;
using OpenCvSharp;

namespace AOI_Tool.Tools
{
    public class LineFitTool : ToolBase
    {
        public override string Name => "擬合線檢測";

        public string FeatureName { get; set; } = "Line_1";
        public int CannyThreshold1 { get; set; } = 50;
        public int CannyThreshold2 { get; set; } = 150;

        public override void Execute(InspectionContext context)
        {
            Mat input = GetInputImageFromSource(context);

            Mat gray = new Mat();

            if (input.Channels() == 3)
                Cv2.CvtColor(input, gray, ColorConversionCodes.BGR2GRAY);
            else
                gray = input.Clone();

            Mat edges = new Mat();
            Cv2.Canny(gray, edges, CannyThreshold1, CannyThreshold2);

            List<OpenCvSharp.Point> points = new List<OpenCvSharp.Point>();

            for (int y = 0; y < edges.Rows; y++)
            {
                for (int x = 0; x < edges.Cols; x++)
                {
                    if (edges.At<byte>(y, x) > 0)
                    {
                        points.Add(new OpenCvSharp.Point(x, y));
                    }
                }
            }

            if (points.Count < 2)
            {
                context.AddResult(Name, false, "邊緣點不足，無法擬合線");
                return;
            }

            // 以 Mat 作為 InputArray，並以 Mat 接收輸出，避免使用不相容的 ref/out 簽章
            Mat ptsMat = Mat.FromArray(points.ToArray());
            Mat lineMat = new Mat();
            Cv2.FitLine(ptsMat, lineMat, DistanceTypes.L2, 0, 0.01, 0.01);
            Vec4f line = lineMat.Get<Vec4f>(0);

            float vx = line.Item0;
            float vy = line.Item1;
            float x0 = line.Item2;
            float y0 = line.Item3;

            int length = 1000;

            var p1 = new OpenCvSharp.Point(
                (int)(x0 - vx * length),
                (int)(y0 - vy * length)
            );

            var p2 = new OpenCvSharp.Point(
                (int)(x0 + vx * length),
                (int)(y0 + vy * length)
            );

            Rect? roi = GetSafeROI(context);

            Mat display = context.CurrentImage.Clone();

            if (display.Channels() == 1)
                Cv2.CvtColor(display, display, ColorConversionCodes.GRAY2BGR);

            if (roi != null)
            {
                p1.X += roi.Value.X;
                p1.Y += roi.Value.Y;
                p2.X += roi.Value.X;
                p2.Y += roi.Value.Y;

                Cv2.Rectangle(display, roi.Value, Scalar.Yellow, 2);
            }

            context.AddFeature(
                FeatureName,
                "Line",
                new LineFeature
                {
                    Name = FeatureName,
                    P1 = new Point2f(p1.X, p1.Y),
                    P2 = new Point2f(p2.X, p2.Y)
                }
            );

            Cv2.Line(display, p1, p2, Scalar.LimeGreen, 2);

            context.CurrentImage = display;
            context.AddResult(Name, true, $"擬合線成功，Feature={FeatureName}, 點數={points.Count}");
        }
    }
}
