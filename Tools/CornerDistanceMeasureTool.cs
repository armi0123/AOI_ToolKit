using AOI_Tool.Core;
using OpenCvSharp;
using Point = OpenCvSharp.Point;

namespace AOI_Tool.Tools
{
    public class CornerDistanceMeasureTool : ToolBase
    {
        public override string Name => "角點距離量測";

        public string EdgeLineAName { get; set; } = "EdgeLine_A";
        public string EdgeLineBName { get; set; } = "EdgeLine_B";
        public string TangentLineName { get; set; } = "CornerTangent";

        public double MinDistance { get; set; } = 5.0;
        public double MaxDistance { get; set; } = 20.0;

        public override void Execute(InspectionContext context)
        {
            LineFeature? lineA = context.GetFeature<LineFeature>(EdgeLineAName);
            LineFeature? lineB = context.GetFeature<LineFeature>(EdgeLineBName);
            LineFeature? tangent = context.GetFeature<LineFeature>(TangentLineName);

            if (lineA == null || lineB == null || tangent == null)
            {
                context.AddResult(Name, false, "缺少線條資料，無法計算角點距離");
                return;
            }

            if (!TryGetLineIntersection(lineA.P1, lineA.P2, lineB.P1, lineB.P2, out Point2f intersection))
            {
                context.AddResult(Name, false, "兩條邊線平行，無法取得交點");
                return;
            }

            double distance = DistancePointToLine(intersection, tangent.P1, tangent.P2);

            bool isOK = distance >= MinDistance && distance <= MaxDistance;

            Mat display = context.CurrentImage.Clone();

            if (display.Channels() == 1)
                Cv2.CvtColor(display, display, ColorConversionCodes.GRAY2BGR);

            Cv2.Line(
                display,
                ToPoint(lineA.P1),
                ToPoint(lineA.P2),
                Scalar.LimeGreen,
                2
            );

            Cv2.Line(
                display,
                ToPoint(lineB.P1),
                ToPoint(lineB.P2),
                Scalar.LimeGreen,
                2
            );

            Cv2.Line(
                display,
                ToPoint(tangent.P1),
                ToPoint(tangent.P2),
                Scalar.Cyan,
                2
            );

            Cv2.Circle(
                display,
                ToPoint(intersection),
                5,
                Scalar.Red,
                -1
            );

            Cv2.PutText(
                display,
                $"D={distance:F2} {(isOK ? "OK" : "NG")}",
                new OpenCvSharp.Point((int)intersection.X + 10, (int)intersection.Y + 10),
                HersheyFonts.HersheySimplex,
                0.8,
                isOK ? Scalar.LimeGreen : Scalar.Red,
                2
            );

            context.CurrentImage = display;

            context.AddResult(
                Name,
                isOK,
                $"角點距離={distance:F2}, 範圍={MinDistance:F2}~{MaxDistance:F2}"
            );
        }

        private bool TryGetLineIntersection(
            Point2f a1, Point2f a2,
            Point2f b1, Point2f b2,
            out Point2f intersection)
        {
            intersection = new Point2f();

            float x1 = a1.X, y1 = a1.Y;
            float x2 = a2.X, y2 = a2.Y;
            float x3 = b1.X, y1b = b1.Y;
            float x4 = b2.X, y2b = b2.Y;

            float denominator =
                (x1 - x2) * (y1b - y2b) -
                (y1 - y2) * (x3 - x4);

            if (Math.Abs(denominator) < 0.0001f)
                return false;

            float px =
                ((x1 * y2 - y1 * x2) * (x3 - x4) -
                 (x1 - x2) * (x3 * y2b - y1b * x4)) / denominator;

            float py =
                ((x1 * y2 - y1 * x2) * (y1b - y2b) -
                 (y1 - y2) * (x3 * y2b - y1b * x4)) / denominator;

            intersection = new Point2f(px, py);
            return true;
        }

        private double DistancePointToLine(Point2f p, Point2f a, Point2f b)
        {
            double numerator = Math.Abs(
                (b.Y - a.Y) * p.X -
                (b.X - a.X) * p.Y +
                b.X * a.Y -
                b.Y * a.X
            );

            double denominator = Math.Sqrt(
                Math.Pow(b.Y - a.Y, 2) +
                Math.Pow(b.X - a.X, 2)
            );

            if (denominator < 0.0001)
                return 0;

            return numerator / denominator;
        }

        private Point ToPoint(Point2f p)
        {
            return new Point((int)p.X, (int)p.Y);
        }
    }
}