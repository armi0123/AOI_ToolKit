using AOI_Tool.Core;
using OpenCvSharp;

namespace AOI_Tool.Tools
{
    public class ThresholdTool : ToolBase
    {
        public override string Name => "二值化";

        public int ThresholdValue { get; set; } = 100;

        public ThresholdTool(int thresholdValue)
        {
            ThresholdValue = thresholdValue;
        }

        public override void Execute(InspectionContext context)
        {
            Mat input = GetInputImage(context);

            Mat gray = new Mat();

            if (input.Channels() == 3)
                Cv2.CvtColor(input, gray, ColorConversionCodes.BGR2GRAY);
            else
                gray = input.Clone();

            Mat result = new Mat();
            Cv2.Threshold(gray, result, ThresholdValue, 255, ThresholdTypes.Binary);

            Rect? roi = GetSafeROI(context);

            if (roi != null)
            {
                if (context.CurrentImage.Channels() == 3)
                {
                    Mat resultColor = new Mat();
                    Cv2.CvtColor(result, resultColor, ColorConversionCodes.GRAY2BGR);
                    resultColor.CopyTo(new Mat(context.CurrentImage, roi.Value));
                }
                else
                {
                    result.CopyTo(new Mat(context.CurrentImage, roi.Value));
                }
                //畫檢測框
                Cv2.Rectangle(context.CurrentImage, roi.Value, Scalar.Yellow, 2);
            }
            else
            {
                context.CurrentImage = result;
            }

            context.AddResult(Name, true, $"二值化完成，Threshold={ThresholdValue}");
        }
    }
}