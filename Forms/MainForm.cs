using AOI_Tool.Core;
using AOI_Tool.Forms;
using OpenCvSharp;
using OpenCvSharp.Extensions;

namespace AOI_Tool
{
    public partial class MainForm : Form
    {
        private Mat? src;
        private Pipeline pipeline = new Pipeline();  // 初始化 Pipeline

        public MainForm()
        {
            InitializeComponent();
        }
        // 讀取圖片按鈕事件
        private void btnLoad_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                src = Cv2.ImRead(ofd.FileName);

                pictureBoxSrc.Image = BitmapConverter.ToBitmap(src);
                pictureBoxResult.Image = null;

                labelJudge.Text = "尚未檢測";
                textBoxMessage.Text = "";
            }
        }
        // 編輯 Pipeline 按鈕事件
        private void btnEditPipeline_Click(object sender, EventArgs e)
        {
            PipelineForm form = new PipelineForm(pipeline, src);
            form.ShowDialog();
        }
        // 執行檢測按鈕事件
        private void btnRun_Click(object sender, EventArgs e)
        {
            if (src == null)
            {
                MessageBox.Show("請先載入圖片");
                return;
            }

            if (pipeline.Tools.Count == 0)
            {
                MessageBox.Show("請先設定 Pipeline");
                return;
            }
            // 執行 Pipeline
            InspectionContext context = pipeline.Run(src);
            // 顯示檢測結果
            pictureBoxResult.Image = BitmapConverter.ToBitmap(context.CurrentImage);
            labelJudge.Text = context.IsOK ? "OK" : "NG";
            labelJudge.ForeColor = context.IsOK ? Color.Green : Color.Red;
            // 顯示檢測訊息
            textBoxMessage.Text = context.Message;
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBoxResult_Click(object sender, EventArgs e)
        {

        }
    }
}
