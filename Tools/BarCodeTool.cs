using AOI_Tool.Core;
using OpenCvSharp;
using OpenCvSharp.Extensions;
using System.Drawing;
using ZXing;
using ZXing.Windows.Compatibility;

namespace AOI_Tool.Tools
{
    public class BarCodeTool : ToolBase
    {
        public bool UseThreshold { get; set; } = false;
        public int ThresholdValue { get; set; } = 100;
        public override string Name => "BarCode檢測";

        public override void Execute(InspectionContext context)
        {
            Mat input = GetInputImage(context);

            Mat gray = new Mat();

            if (input.Channels() == 3)
                Cv2.CvtColor(input, gray, ColorConversionCodes.BGR2GRAY);
            else
                gray = input.Clone();

            if (UseThreshold)//若有要使用二值化
            {
                Cv2.Threshold(gray, gray, ThresholdValue, 255, ThresholdTypes.Binary);
            }

            Mat enlarged = new Mat();
            Cv2.Resize(gray, enlarged, new OpenCvSharp.Size(), 2.0, 2.0, InterpolationFlags.Cubic);

            using Bitmap bitmap = BitmapConverter.ToBitmap(enlarged);

            var reader = new BarcodeReader
            {
                AutoRotate = true,
                Options = new ZXing.Common.DecodingOptions
                {
                    TryHarder = true,
                    PossibleFormats = new List<BarcodeFormat>
            {
                BarcodeFormat.DATA_MATRIX,
                BarcodeFormat.QR_CODE,
                BarcodeFormat.CODE_128,
                BarcodeFormat.CODE_39,
                BarcodeFormat.EAN_13,
                BarcodeFormat.EAN_8,
                BarcodeFormat.UPC_A,
                BarcodeFormat.UPC_E
            }
                }
            };

            var result = reader.Decode(bitmap);

            Mat display = context.CurrentImage.Clone();

            if (display.Channels() == 1)
                Cv2.CvtColor(display, display, ColorConversionCodes.GRAY2BGR);

            Rect? roi = GetSafeROI(context);

            if (roi != null)
            {
                Cv2.Rectangle(display, roi.Value, Scalar.Yellow, 2);
            }

            if (result != null)
            {
                Cv2.PutText(
                    display,
                    $"BarCode: {result.Text}",
                    new OpenCvSharp.Point(20, 40),
                    HersheyFonts.HersheySimplex,
                    0.8,
                    Scalar.LimeGreen,
                    2
                );

                context.CurrentImage = display;
                context.AddResult(Name, true, $"BarCode讀取成功：{result.Text}");
            }
            else
            {
                Cv2.PutText(
                    display,
                    "BarCode Not Found",
                    new OpenCvSharp.Point(20, 40),
                    HersheyFonts.HersheySimplex,
                    0.8,
                    Scalar.Red,
                    2
                );

                context.CurrentImage = display;
                context.AddResult(Name, false, "BarCode讀取失敗");
            }
        }
    }
}