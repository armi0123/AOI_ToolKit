using AOI_Tool.Core;

namespace AOI_Tool.Tools
{
    public class CornerDetectTool : ITool
    {
        public string Name => "特徵角檢測";

        public void Execute(InspectionContext context)
        {
            // 之後加入角點檢測、角度判定、位置判定
            context.Message += "特徵角檢測完成；";
        }
    }
}
