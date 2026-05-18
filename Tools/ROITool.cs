using AOI_Tool.Core;
using OpenCvSharp;

namespace AOI_Tool.Tools
{
    public class RoiTool : ITool
    {
        public string Name => "ROI設定";

        public Rect Roi { get; set; }

        public RoiTool(Rect roi)
        {
            Roi = roi;
        }

        public void Execute(InspectionContext context)
        {
            int x = Math.Clamp(Roi.X, 0, context.CurrentImage.Width - 1);
            int y = Math.Clamp(Roi.Y, 0, context.CurrentImage.Height - 1);
            int w = Math.Clamp(Roi.Width, 1, context.CurrentImage.Width - x);
            int h = Math.Clamp(Roi.Height, 1, context.CurrentImage.Height - y);

            context.ROI = new Rect(x, y, w, h);

            context.AddResult(Name, true, $"ROI設定完成 X={x}, Y={y}, W={w}, H={h}");
        }
    }
}