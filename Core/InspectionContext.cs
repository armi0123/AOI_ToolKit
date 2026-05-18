using OpenCvSharp;

namespace AOI_Tool.Core
{
    public class InspectionContext
    {
        public Mat SourceImage { get; set; }//原始圖片
        public Mat CurrentImage { get; set; }//預處理後的圖片

        public Rect? ROI { get; set; } = null;//檢測框

        public bool IsOK { get; set; } = true;//整體判定結果
        public string Message { get; set; } = "";//整體檢測訊息

        public List<ToolResult> Results { get; set; } = new();//結構化的結果紀錄

        public InspectionContext(Mat source)//建構子
        {
            SourceImage = source.Clone();
            CurrentImage = source.Clone();
        }

        public Mat GetRoiImage()
        {
            if (ROI == null)
                return CurrentImage.Clone();

            return new Mat(CurrentImage, ROI.Value).Clone();
        }

        public void AddResult(string toolName, bool isOK, string message)//工具執行完後記錄檢測結果
        {
            Results.Add(new ToolResult
            {
                ToolName = toolName,
                IsOK = isOK,
                Message = message
            });

            if (!isOK)
                IsOK = false;

            Message += $"{toolName}: {message}\r\n";
        }
    }
}