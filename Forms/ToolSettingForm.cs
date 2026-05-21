using AOI_Tool.Tools;
using OpenCvSharp;
using OpenCvSharp.Extensions;
using DrawingPoint = System.Drawing.Point;
using DrawingRectangle = System.Drawing.Rectangle;

namespace AOI_Tool.Forms
{
    public partial class ToolSettingForm : Form
    {
        private ToolBase tool;
        private Mat? sourceImage;
        private Bitmap? displayBitmap;

        private bool isDrawing = false;
        private DrawingPoint startPoint;
        private DrawingRectangle roiRect = DrawingRectangle.Empty;

        public ToolSettingForm(ToolBase tool, Mat? sourceImage)
        {
            InitializeComponent();

            this.tool = tool;
            this.sourceImage = sourceImage;

            Text = $"{tool.Name} 參數設定";

            LoadImage();
            LoadSetting();
            pictureBoxImage.Invalidate();

            pictureBoxImage.MouseDown += pictureBoxImage_MouseDown;
            pictureBoxImage.MouseMove += pictureBoxImage_MouseMove;
            pictureBoxImage.MouseUp += pictureBoxImage_MouseUp;
            pictureBoxImage.Paint += pictureBoxImage_Paint;
        }
        private void LoadImage()
        {
            if (sourceImage == null)
                return;

            displayBitmap = BitmapConverter.ToBitmap(sourceImage);
            pictureBoxImage.Image = displayBitmap;
        }
        private Rect ConvertPictureBoxRectToImageRect(DrawingRectangle rect)
        {
            if (sourceImage == null)
                return new Rect(0, 0, 0, 0);

            float imageRatio = (float)sourceImage.Width / sourceImage.Height;
            float boxRatio = (float)pictureBoxImage.Width / pictureBoxImage.Height;

            int displayWidth;
            int displayHeight;
            int offsetX;
            int offsetY;

            if (imageRatio > boxRatio)
            {
                displayWidth = pictureBoxImage.Width;
                displayHeight = (int)(pictureBoxImage.Width / imageRatio);
                offsetX = 0;
                offsetY = (pictureBoxImage.Height - displayHeight) / 2;
            }
            else
            {
                displayHeight = pictureBoxImage.Height;
                displayWidth = (int)(pictureBoxImage.Height * imageRatio);
                offsetX = (pictureBoxImage.Width - displayWidth) / 2;
                offsetY = 0;
            }

            int x = (int)((rect.X - offsetX) * sourceImage.Width / (float)displayWidth);
            int y = (int)((rect.Y - offsetY) * sourceImage.Height / (float)displayHeight);
            int w = (int)(rect.Width * sourceImage.Width / (float)displayWidth);
            int h = (int)(rect.Height * sourceImage.Height / (float)displayHeight);

            x = Math.Clamp(x, 0, sourceImage.Width - 1);
            y = Math.Clamp(y, 0, sourceImage.Height - 1);
            w = Math.Clamp(w, 1, sourceImage.Width - x);
            h = Math.Clamp(h, 1, sourceImage.Height - y);

            return new Rect(x, y, w, h);
        }
        private DrawingRectangle ConvertImageRectToPictureBoxRect(Rect roi)
        {
            if (sourceImage == null)
                return DrawingRectangle.Empty;

            float imageRatio = (float)sourceImage.Width / sourceImage.Height;
            float boxRatio = (float)pictureBoxImage.Width / pictureBoxImage.Height;

            int displayWidth;
            int displayHeight;
            int offsetX;
            int offsetY;

            if (imageRatio > boxRatio)
            {
                displayWidth = pictureBoxImage.Width;
                displayHeight = (int)(pictureBoxImage.Width / imageRatio);
                offsetX = 0;
                offsetY = (pictureBoxImage.Height - displayHeight) / 2;
            }
            else
            {
                displayHeight = pictureBoxImage.Height;
                displayWidth = (int)(pictureBoxImage.Height * imageRatio);
                offsetX = (pictureBoxImage.Width - displayWidth) / 2;
                offsetY = 0;
            }

            int x = (int)(roi.X * displayWidth / (float)sourceImage.Width) + offsetX;
            int y = (int)(roi.Y * displayHeight / (float)sourceImage.Height) + offsetY;
            int w = (int)(roi.Width * displayWidth / (float)sourceImage.Width);
            int h = (int)(roi.Height * displayHeight / (float)sourceImage.Height);

            return new DrawingRectangle(x, y, w, h);
        }
        //==滑鼠選框==
        private void pictureBoxImage_MouseDown(object? sender, MouseEventArgs e)
        {
            if (sourceImage == null) return;

            isDrawing = true;
            startPoint = e.Location;
            roiRect = new DrawingRectangle(e.X, e.Y, 0, 0);
        }

        private void pictureBoxImage_MouseMove(object? sender, MouseEventArgs e)
        {
            if (!isDrawing) return;

            int x = Math.Min(startPoint.X, e.X);
            int y = Math.Min(startPoint.Y, e.Y);
            int w = Math.Abs(e.X - startPoint.X);
            int h = Math.Abs(e.Y - startPoint.Y);

            roiRect = new DrawingRectangle(x, y, w, h);
            pictureBoxImage.Invalidate();
        }

        private void pictureBoxImage_MouseUp(object? sender, MouseEventArgs e)
        {
            isDrawing = false;

            Rect imageRoi = ConvertPictureBoxRectToImageRect(roiRect);

            numX.Value = imageRoi.X;
            numY.Value = imageRoi.Y;
            numW.Value = imageRoi.Width;
            numH.Value = imageRoi.Height;

            checkUseROI.Checked = true;

            pictureBoxImage.Invalidate();
        }

        private void pictureBoxImage_Paint(object? sender, PaintEventArgs e)
        {
            if (roiRect.Width > 0 && roiRect.Height > 0)
            {
                using Pen pen = new Pen(Color.Red, 2);
                e.Graphics.DrawRectangle(pen, roiRect);
            }
        }
        //==滑鼠選框(結束)==

        private void LoadSetting()
        {
            // ROI
            if (tool.ROI != null)
            {
                checkUseROI.Checked = true;

                Rect roi = tool.ROI.Value;

                numX.Value = roi.X;
                numY.Value = roi.Y;
                numW.Value = roi.Width;
                numH.Value = roi.Height;

                if (sourceImage != null)
                {
                    roiRect = ConvertImageRectToPictureBoxRect(roi);
                }
            }
            else
            {
                checkUseROI.Checked = false;

                numX.Value = 0;
                numY.Value = 0;
                numW.Value = 200;
                numH.Value = 200;

                roiRect = DrawingRectangle.Empty;
            }

            // 預設先隱藏 Threshold 設定
            labelThreshold.Visible = false;
            numThreshold.Visible = false;
            checkUseThreshold.Visible = false;

            // ThresholdTool 參數
            if (tool is ThresholdTool thresholdTool)
            {
                labelThreshold.Visible = true;
                numThreshold.Visible = true;

                numThreshold.Value = thresholdTool.ThresholdValue;
            }

            // BarCodeTool 參數
            if (tool is BarCodeTool barCodeTool)
            {
                labelThreshold.Visible = true;
                numThreshold.Visible = true;
                checkUseThreshold.Visible = true;

                checkUseThreshold.Checked = barCodeTool.UseThreshold;
                numThreshold.Value = barCodeTool.ThresholdValue;
            }

            // 先隱藏 LineFit 參數
            labelFeatureName.Visible = false;
            textFeatureName.Visible = false;
            labelCanny1.Visible = false;
            numCanny1.Visible = false;
            labelCanny2.Visible = false;
            numCanny2.Visible = false;

            // LineFitTool 參數
            if (tool is LineFitTool lineFitTool)
            {
                labelFeatureName.Visible = true;
                textFeatureName.Visible = true;
                labelCanny1.Visible = true;
                numCanny1.Visible = true;
                labelCanny2.Visible = true;
                numCanny2.Visible = true;

                textFeatureName.Text = lineFitTool.FeatureName;
                numCanny1.Value = lineFitTool.CannyThreshold1;
                numCanny2.Value = lineFitTool.CannyThreshold2;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // ROI 儲存
            if (checkUseROI.Checked)
            {
                int x = (int)numX.Value;
                int y = (int)numY.Value;
                int w = (int)numW.Value;
                int h = (int)numH.Value;

                tool.ROI = new Rect(x, y, w, h);
            }
            else
            {
                tool.ROI = null;
            }

            // ThresholdTool 儲存
            if (tool is ThresholdTool thresholdTool)
            {
                thresholdTool.ThresholdValue = (int)numThreshold.Value;
            }

            // BarCodeTool 儲存
            if (tool is BarCodeTool barCodeTool)
            {
                barCodeTool.UseThreshold = checkUseThreshold.Checked;
                barCodeTool.ThresholdValue = (int)numThreshold.Value;
            }

            if (tool is LineFitTool lineFitTool)
            {
                lineFitTool.FeatureName = textFeatureName.Text;
                lineFitTool.CannyThreshold1 = (int)numCanny1.Value;
                lineFitTool.CannyThreshold2 = (int)numCanny2.Value;
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void numW_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}