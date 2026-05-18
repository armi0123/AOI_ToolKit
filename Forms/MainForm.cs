using AOI_Tool.Core;
using AOI_Tool.Forms;
using OpenCvSharp;
using OpenCvSharp.Extensions;

namespace AOI_Tool
{
    public partial class MainForm : Form
    {
        private Mat? src;
        private Pipeline pipeline = new Pipeline();

        public MainForm()
        {
            InitializeComponent();
        }
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
        private void btnEditPipeline_Click(object sender, EventArgs e)
        {
            PipelineForm form = new PipelineForm(pipeline, src);
            form.ShowDialog();
        }
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

            InspectionContext context = pipeline.Run(src);

            pictureBoxResult.Image = BitmapConverter.ToBitmap(context.CurrentImage);

            labelJudge.Text = context.IsOK ? "OK" : "NG";
            labelJudge.ForeColor = context.IsOK ? Color.Green : Color.Red;

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
