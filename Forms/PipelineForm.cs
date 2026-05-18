using AOI_Tool.Core;
using AOI_Tool.Tools;
using OpenCvSharp;

namespace AOI_Tool.Forms
{
    public partial class PipelineForm : Form
    {
        private Pipeline pipeline;

        private Mat? sourceImage;

        public PipelineForm(Pipeline pipeline, Mat? sourceImage)
        {
            InitializeComponent();

            this.pipeline = pipeline;
            this.sourceImage = sourceImage;

            InitAvailableTools();
            RefreshPipelineList();
        }

        private void InitAvailableTools()
        {
            listBoxAvailable.Items.Clear();

            listBoxAvailable.Items.Add("Sobel邊緣檢測");
            listBoxAvailable.Items.Add("二值化");
            listBoxAvailable.Items.Add("QRCode檢測");
            listBoxAvailable.Items.Add("特徵角檢測");
            listBoxAvailable.Items.Add("BarCode檢測");
            listBoxAvailable.Items.Add("ROI設定");
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string? selected = listBoxAvailable.SelectedItem?.ToString();

            if (selected == null)
                return;

            switch (selected)
            {
                case "Sobel邊緣檢測":
                    pipeline.AddTool(new SobelTool());
                    break;

                case "QRCode檢測":
                    pipeline.AddTool(new QrCodeTool());
                    break;

                case "二值化":
                    pipeline.AddTool(new ThresholdTool(100));
                    break;

                case "特徵角檢測":
                    pipeline.AddTool(new CornerDetectTool());
                    break;

                case "BarCode檢測":
                    pipeline.AddTool(new BarCodeTool());
                    break;

                case "ROI設定":
                    pipeline.AddTool(new RoiTool(new Rect(50, 50, 200, 200)));
                    break;
            }

            RefreshPipelineList();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            int index = listBoxPipeline.SelectedIndex;

            if (index < 0)
                return;

            pipeline.RemoveAt(index);
            RefreshPipelineList();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void RefreshPipelineList()
        {
            listBoxPipeline.Items.Clear();

            foreach (var tool in pipeline.Tools)
            {
                string text = tool.Name;

                if (tool is ToolBase toolBase)
                {
                    if (toolBase.ROI != null)
                    {
                        Rect roi = toolBase.ROI.Value;
                        text += $" ROI({roi.X},{roi.Y},{roi.Width},{roi.Height})";
                    }
                    else
                    {
                        text += " ROI(整張圖)";
                    }
                }

                if (tool is ThresholdTool thresholdTool)
                {
                    text += $" TH={thresholdTool.ThresholdValue}";
                }

                if (tool is BarCodeTool barCodeTool)
                {
                    text += $" UseTH={barCodeTool.UseThreshold}, TH={barCodeTool.ThresholdValue}";
                }

                listBoxPipeline.Items.Add(text);
            }
        }

        private void btnSetting_Click(object sender, EventArgs e)
        {
            int index = listBoxPipeline.SelectedIndex;

            if (index < 0)
            {
                MessageBox.Show("請先選擇要設定的工具");
                return;
            }

            if (pipeline.Tools[index] is not ToolBase tool)
            {
                MessageBox.Show("這個工具不支援參數設定");
                return;
            }

            ToolSettingForm form = new ToolSettingForm(tool, sourceImage);

            if (form.ShowDialog() == DialogResult.OK)
            {
                RefreshPipelineList();
            }
        }
    }
}
