using AOI_Tool.Core;
using OpenCvSharp;
using OpenCvSharp.Extensions;
using System.Drawing;
using ZXing;
using ZXing.Windows.Compatibility;

namespace AOI_Tool.Tools
{
    public class DataMatrixTool : ITool
    {
        public string Name => "DataMatrix檢測";

        public void Execute(InspectionContext context)
        {
            Mat input = context.CurrentImage.Clone();

            // 建議先轉灰階，提升穩定性
            Mat gray = new Mat();

            if (input.Channels() == 3)
                Cv2.CvtColor(input, gray, ColorConversionCodes.BGR2GRAY);
            else
                gray = input.Clone();

            // 放大影像，DataMatrix 太小時比較好讀
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
                        BarcodeFormat.DATA_MATRIX
                    }
                }
            };

            var result = reader.Decode(bitmap);

            Mat display = input.Clone();

            if (display.Channels() == 1)
                Cv2.CvtColor(display, display, ColorConversionCodes.GRAY2BGR);

            if (result != null)
            {
                string text = result.Text;

                Cv2.PutText(
                    display,
                    $"DataMatrix: {text}",
                    new OpenCvSharp.Point(20, 40),
                    HersheyFonts.HersheySimplex,
                    0.8,
                    Scalar.LimeGreen,
                    2
                );

                context.CurrentImage = display;
                context.AddResult(Name, true, $"DataMatrix讀取成功：{text}");
            }
            else
            {
                Cv2.PutText(
                    display,
                    "DataMatrix Not Found",
                    new OpenCvSharp.Point(20, 40),
                    HersheyFonts.HersheySimplex,
                    0.8,
                    Scalar.Red,
                    2
                );

                context.CurrentImage = display;
                context.AddResult(Name, false, "DataMatrix讀取失敗");
            }
        }
    }
}