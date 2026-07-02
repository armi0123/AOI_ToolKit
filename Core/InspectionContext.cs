using OpenCvSharp;

namespace AOI_Tool.Core
{
    /// <summary>
    /// InspectionContext
    /// ---------------------------------------------------------
    /// AOI ToolKit 中所有 Tool 共用的資料容器。
    ///
    /// 每個 Tool 不直接互相呼叫，而是共同讀寫 Context。
    ///
    /// Context 負責保存：
    ///
    /// 1. 原始影像
    /// 2. 目前影像
    /// 3. ROI
    /// 4. Tool執行結果
    /// 5. Tool產生的Feature
    ///
    /// 這樣每個 Tool 都可以專心完成自己的工作，
    /// 不需要知道上一個 Tool 做了什麼，降低耦合度。
    /// </summary>
    public class InspectionContext
    {
        // 原始影像
        // 建立 Context 時會先 Clone 一份保存。
        // 不論後續做多少影像處理，都保留最初影像。
        public Mat SourceImage { get; set; }
        // 目前流程中的影像
        // 每個 Tool 可以修改 CurrentImage，
        // 下一個 Tool 就接續使用修改後的影像。
        public Mat CurrentImage { get; set; }
        // 目前的檢測區域
        // 若沒有設定 ROI，代表整張圖片皆為檢測範圍。
        public Rect? ROI { get; set; } = null;
        // 整體檢測結果
        // 初始為 true，只要任一 Tool 判定 NG，
        // 最終結果就會變成 false。
        public bool IsOK { get; set; } = true;
        // 所有 Tool 的執行訊息
        // 每完成一個 Tool 都會加入文字描述，
        // 最後可一次顯示完整檢測紀錄。
        public string Message { get; set; } = "";
        // 保存每一個 Tool 的執行結果
        // 可提供 UI 顯示、Log 或後續分析。
        public List<ToolResult> Results { get; set; } = new();
        // 建立新的 InspectionContext
        // 建立時複製原始影像，避免修改到外部圖片。
        public InspectionContext(Mat source)
        {
            SourceImage = source.Clone();
            CurrentImage = source.Clone();
        }
        /// <summary>
        /// 取得目前需要檢測的影像。
        ///
        /// 若沒有設定 ROI，回傳整張圖片。
        /// 若設定 ROI，只回傳 ROI 區域。
        ///
        /// 每個 Tool 幾乎都透過此函式取得工作影像，
        /// 不需要自行判斷 ROI。
        /// </summary>
        public Mat GetRoiImage()
        {
            if (ROI == null)
                return CurrentImage.Clone();

            return new Mat(CurrentImage, ROI.Value).Clone();
        }
        /// <summary>
        /// Tool 執行完成後呼叫。
        ///
        /// 功能：
        ///
        /// 1. 保存 ToolResult
        /// 2. 更新整體 IsOK
        /// 3. 累積顯示訊息
        /// </summary>
        public void AddResult(string toolName, bool isOK, string message)
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
        // Tool 之間共享的特徵資料。
        // 例如 Template、Blob、Contour、QRCode 等。
        // 後續 Tool 可直接取用，不需重新計算。
        public List<FeatureResult> Features { get; set; } = new();
        /// <summary>
        /// 根據名稱取得指定 Feature。
        ///
        /// 使用泛型讓 Tool 可以取得對應型別，
        /// 避免大量型別轉換。
        /// </summary>
        public void AddFeature(string name, string type, object data)
        {
            Features.Add(new FeatureResult
            {
                Name = name,
                Type = type,
                Data = data
            });
        }
        /// <summary>
        /// 根據名稱取得指定 Feature。
        ///
        /// 使用泛型讓 Tool 可以取得對應型別，
        /// 避免大量型別轉換。
        /// </summary>
        public T? GetFeature<T>(string name) where T : class
        {
            var feature = Features.FirstOrDefault(f => f.Name == name);

            if (feature == null)
                return null;

            return feature.Data as T;
        }
    }
}