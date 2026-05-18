using AOI_Tool.Core;
using OpenCvSharp;
using OpenCvSharp.Extensions;
using System.Drawing;
using ZXing;
using ZXing.Windows.Compatibility;

namespace AOI_Tool.Tools
{
    public class QrCodeTool : ITool
    {
        public string Name => "QRCode檢測";

        public void Execute(InspectionContext context)
        {
            using Bitmap bitmap = BitmapConverter.ToBitmap(context.CurrentImage);

            var reader = new BarcodeReader
            {
                Options = new ZXing.Common.DecodingOptions
                {
                    TryHarder = true,
                    PossibleFormats = new List<BarcodeFormat>
                    {
                        BarcodeFormat.QR_CODE
                    }
                }
            };

            var result = reader.Decode(bitmap);

            Mat display = context.CurrentImage.Clone();

            if (display.Channels() == 1)
            {
                Cv2.CvtColor(display, display, ColorConversionCodes.GRAY2BGR);
            }

            if (result != null)
            {
                string qrText = result.Text;

                Cv2.PutText(
                    display,
                    $"QR: {qrText}",
                    new OpenCvSharp.Point(20, 40),
                    HersheyFonts.HersheySimplex,
                    0.8,
                    Scalar.LimeGreen,
                    2
                );

                context.CurrentImage = display;
                context.AddResult(Name, true, $"QRCode讀取成功：{qrText}");
            }
            else
            {
                Cv2.PutText(
                    display,
                    "QR Code Not Found",
                    new OpenCvSharp.Point(20, 40),
                    HersheyFonts.HersheySimplex,
                    0.8,
                    Scalar.Red,
                    2
                );

                context.CurrentImage = display;
                context.AddResult(Name, false, "QRCode讀取失敗");
            }
        }
    }
}