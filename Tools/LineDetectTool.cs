using AOI_Tool.Core;
using OpenCvSharp;

namespace AOI_Tool.Tools
{
    public class LineDetectTool : ToolBase
    {
        public override string Name => "線條檢測";

        public int CannyThreshold1 { get; set; } = 50;
        public int CannyThreshold2 { get; set; } = 150;

        public double MinLineLength { get; set; } = 50;
        public double MaxLineGap { get; set; } = 10;

        public override void Execute(InspectionContext context)
        {
            Mat input = GetInputImage(context);

            Mat gray = new Mat();

            if (input.Channels() == 3)
                Cv2.CvtColor(input, gray, ColorConversionCodes.BGR2GRAY);
            else
                gray = input.Clone();

            Mat edges = new Mat();
            Cv2.Canny(gray, edges, CannyThreshold1, CannyThreshold2);

            LineSegmentPoint[] lines = Cv2.HoughLinesP(
                edges,
                1,
                Math.PI / 180,
                50,
                MinLineLength,
                MaxLineGap
            );

            Mat display = context.CurrentImage.Clone();

            if (display.Channels() == 1)
                Cv2.CvtColor(display, display, ColorConversionCodes.GRAY2BGR);

            Rect? roi = GetSafeROI(context);

            if (lines.Length == 0)
            {
                if (roi != null)
                    Cv2.Rectangle(display, roi.Value, Scalar.Red, 2);

                context.CurrentImage = display;
                context.AddResult(Name, false, "未找到線條");
                return;
            }

            LineSegmentPoint bestLine = lines
                .OrderByDescending(l => GetLineLength(l))
                .First();

            OpenCvSharp.Point p1 = bestLine.P1;
            OpenCvSharp.Point p2 = bestLine.P2;

            if (roi != null)
            {
                p1.X += roi.Value.X;
                p1.Y += roi.Value.Y;
                p2.X += roi.Value.X;
                p2.Y += roi.Value.Y;

                Cv2.Rectangle(display, roi.Value, Scalar.Yellow, 2);
            }

            Cv2.Line(display, p1, p2, Scalar.LimeGreen, 2);

            context.CurrentImage = display;
            context.AddResult(
                Name,
                true,
                $"線條檢測成功 P1=({p1.X},{p1.Y}) P2=({p2.X},{p2.Y})"
            );
        }

        private double GetLineLength(LineSegmentPoint line)
        {
            double dx = line.P1.X - line.P2.X;
            double dy = line.P1.Y - line.P2.Y;

            return Math.Sqrt(dx * dx + dy * dy);
        }
    }
}