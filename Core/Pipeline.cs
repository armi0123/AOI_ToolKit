using OpenCvSharp;
using AOI_Tool.Tools;

namespace AOI_Tool.Core
{
    public class Pipeline
    {
        public List<ITool> Tools { get; } = new();

        public void AddTool(ITool tool)
        {
            Tools.Add(tool);
        }

        public void RemoveAt(int index)
        {
            if (index >= 0 && index < Tools.Count)
                Tools.RemoveAt(index);
        }

        public void Clear()
        {
            Tools.Clear();
        }

        public InspectionContext Run(Mat input)
        {
            InspectionContext context = new InspectionContext(input);

            foreach (var tool in Tools)
            {
                tool.Execute(context);
            }

            return context;
        }
    }
}