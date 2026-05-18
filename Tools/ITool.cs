using AOI_Tool.Core;

namespace AOI_Tool.Tools
{
    public interface ITool
    {
        string Name { get; }
        void Execute(InspectionContext context);
    }
}