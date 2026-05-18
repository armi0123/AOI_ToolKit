using AOI_Tool.Core;
using OpenCvSharp;

namespace AOI_Tool.Tools
{
    public class SobelTool : ToolBase
    {
        public override string Name => "Sobel邊緣檢測";

        public override void Execute(InspectionContext context)
        {
            // 1. 取得這個 Tool 自己的 ROI 影像
            Mat input = GetInputImage(context);

            // 2. 轉灰階
            Mat gray = new Mat();

            if (input.Channels() == 3)
                Cv2.CvtColor(input, gray, ColorConversionCodes.BGR2GRAY);
            else
                gray = input.Clone();

            // 3. Sobel X/Y
            Mat sobelX = new Mat();
            Mat sobelY = new Mat();

            Cv2.Sobel(gray, sobelX, MatType.CV_32F, 1, 0);
            Cv2.Sobel(gray, sobelY, MatType.CV_32F, 0, 1);

            // 4. 轉成 8bit
            Mat absX = new Mat();
            Mat absY = new Mat();

            Cv2.ConvertScaleAbs(sobelX, absX);
            Cv2.ConvertScaleAbs(sobelY, absY);

            Mat result = new Mat();
            Cv2.Add(absX, absY, result);

            // 5. 建立顯示用影像
            Mat display = context.CurrentImage.Clone();

            if (display.Channels() == 1)
                Cv2.CvtColor(display, display, ColorConversionCodes.GRAY2BGR);

            // Sobel結果轉彩色，才能貼回彩色原圖
            Mat resultColor = new Mat();
            Cv2.CvtColor(result, resultColor, ColorConversionCodes.GRAY2BGR);

            // 6. 取得安全 ROI
            Rect? roi = GetSafeROI(context);

            if (roi != null)
            {
                // 只把 Sobel 結果貼回 ROI 區域
                resultColor.CopyTo(new Mat(display, roi.Value));

                // 畫黃色 ROI 框
                Cv2.Rectangle(display, roi.Value, Scalar.Yellow, 2);

                context.CurrentImage = display;
            }
            else
            {
                // 沒有 ROI 就顯示整張 Sobel
                context.CurrentImage = resultColor;
            }

            context.AddResult(Name, true, "Sobel邊緣檢測完成");
        }
    }
}