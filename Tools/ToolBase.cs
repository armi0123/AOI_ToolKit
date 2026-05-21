using AOI_Tool.Core;
using OpenCvSharp;

namespace AOI_Tool.Tools
{
    public abstract class ToolBase : ITool
    {
        public abstract string Name { get; }

        public Rect? ROI { get; set; } = null;

        public abstract void Execute(InspectionContext context);

        protected Mat GetInputImage(InspectionContext context)
        {
            if (ROI == null)
                return context.CurrentImage.Clone();

            Rect roi = ROI.Value;

            int x = Math.Clamp(roi.X, 0, context.CurrentImage.Width - 1);
            int y = Math.Clamp(roi.Y, 0, context.CurrentImage.Height - 1);
            int w = Math.Clamp(roi.Width, 1, context.CurrentImage.Width - x);
            int h = Math.Clamp(roi.Height, 1, context.CurrentImage.Height - y);

            return new Mat(context.CurrentImage, new Rect(x, y, w, h)).Clone();
        }
        protected Mat GetInputImageFromSource(InspectionContext context)
        {
            if (ROI == null)
                return context.SourceImage.Clone();

            Rect roi = ROI.Value;

            int x = Math.Clamp(roi.X, 0, context.SourceImage.Width - 1);
            int y = Math.Clamp(roi.Y, 0, context.SourceImage.Height - 1);
            int w = Math.Clamp(roi.Width, 1, context.SourceImage.Width - x);
            int h = Math.Clamp(roi.Height, 1, context.SourceImage.Height - y);

            return new Mat(context.SourceImage, new Rect(x, y, w, h)).Clone();
        }

        protected Rect? GetSafeROI(InspectionContext context)
        {
            if (ROI == null)
                return null;

            Rect roi = ROI.Value;

            int x = Math.Clamp(roi.X, 0, context.CurrentImage.Width - 1);
            int y = Math.Clamp(roi.Y, 0, context.CurrentImage.Height - 1);
            int w = Math.Clamp(roi.Width, 1, context.CurrentImage.Width - x);
            int h = Math.Clamp(roi.Height, 1, context.CurrentImage.Height - y);

            return new Rect(x, y, w, h);
        }
    }
}