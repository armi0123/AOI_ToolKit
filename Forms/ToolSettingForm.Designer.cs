namespace AOI_Tool.Forms
{
    partial class ToolSettingForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            labelX = new Label();
            numX = new NumericUpDown();
            labelY = new Label();
            labelW = new Label();
            labelH = new Label();
            numY = new NumericUpDown();
            numW = new NumericUpDown();
            numH = new NumericUpDown();
            btnSave = new Button();
            btnCancel = new Button();
            labelThreshold = new Label();
            numThreshold = new NumericUpDown();
            checkUseThreshold = new CheckBox();
            checkUseROI = new CheckBox();
            pictureBoxImage = new PictureBox();
            labelFeatureName = new Label();
            textFeatureName = new TextBox();
            labelCanny1 = new Label();
            numCanny1 = new NumericUpDown();
            labelCanny2 = new Label();
            numCanny2 = new NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)numX).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numY).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numW).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numH).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numThreshold).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxImage).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numCanny1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numCanny2).BeginInit();
            SuspendLayout();
            // 
            // labelX
            // 
            labelX.AutoSize = true;
            labelX.Location = new Point(10, 15);
            labelX.Name = "labelX";
            labelX.Size = new Size(19, 19);
            labelX.TabIndex = 0;
            labelX.Text = "X";
            // 
            // numX
            // 
            numX.Location = new Point(38, 10);
            numX.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            numX.Name = "numX";
            numX.Size = new Size(159, 27);
            numX.TabIndex = 1;
            // 
            // labelY
            // 
            labelY.AutoSize = true;
            labelY.Location = new Point(10, 50);
            labelY.Name = "labelY";
            labelY.Size = new Size(18, 19);
            labelY.TabIndex = 2;
            labelY.Text = "Y";
            // 
            // labelW
            // 
            labelW.AutoSize = true;
            labelW.Location = new Point(6, 93);
            labelW.Name = "labelW";
            labelW.Size = new Size(24, 19);
            labelW.TabIndex = 3;
            labelW.Text = "W";
            // 
            // labelH
            // 
            labelH.AutoSize = true;
            labelH.Location = new Point(10, 135);
            labelH.Name = "labelH";
            labelH.Size = new Size(20, 19);
            labelH.TabIndex = 4;
            labelH.Text = "H";
            // 
            // numY
            // 
            numY.Location = new Point(37, 49);
            numY.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            numY.Name = "numY";
            numY.Size = new Size(160, 27);
            numY.TabIndex = 5;
            // 
            // numW
            // 
            numW.Location = new Point(37, 91);
            numW.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            numW.Name = "numW";
            numW.Size = new Size(160, 27);
            numW.TabIndex = 6;
            numW.ValueChanged += numW_ValueChanged;
            // 
            // numH
            // 
            numH.Location = new Point(38, 133);
            numH.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            numH.Name = "numH";
            numH.Size = new Size(159, 27);
            numH.TabIndex = 7;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(6, 487);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(82, 31);
            btnSave.TabIndex = 8;
            btnSave.Text = "儲存";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(117, 487);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(80, 30);
            btnCancel.TabIndex = 9;
            btnCancel.Text = "取消";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // labelThreshold
            // 
            labelThreshold.AutoSize = true;
            labelThreshold.Location = new Point(6, 208);
            labelThreshold.Name = "labelThreshold";
            labelThreshold.Size = new Size(54, 19);
            labelThreshold.TabIndex = 10;
            labelThreshold.Text = "二值化";
            // 
            // numThreshold
            // 
            numThreshold.Location = new Point(66, 206);
            numThreshold.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            numThreshold.Name = "numThreshold";
            numThreshold.Size = new Size(125, 27);
            numThreshold.TabIndex = 11;
            // 
            // checkUseThreshold
            // 
            checkUseThreshold.AutoSize = true;
            checkUseThreshold.Location = new Point(12, 241);
            checkUseThreshold.Name = "checkUseThreshold";
            checkUseThreshold.Size = new Size(136, 23);
            checkUseThreshold.TabIndex = 12;
            checkUseThreshold.Text = "是否調整二值化";
            checkUseThreshold.UseVisualStyleBackColor = true;
            // 
            // checkUseROI
            // 
            checkUseROI.AutoSize = true;
            checkUseROI.Location = new Point(12, 177);
            checkUseROI.Name = "checkUseROI";
            checkUseROI.Size = new Size(117, 23);
            checkUseROI.TabIndex = 13;
            checkUseROI.Text = "是否調整ROI";
            checkUseROI.UseVisualStyleBackColor = true;
            // 
            // pictureBoxImage
            // 
            pictureBoxImage.Location = new Point(320, 6);
            pictureBoxImage.Name = "pictureBoxImage";
            pictureBoxImage.Size = new Size(562, 522);
            pictureBoxImage.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxImage.TabIndex = 14;
            pictureBoxImage.TabStop = false;
            // 
            // labelFeatureName
            // 
            labelFeatureName.AutoSize = true;
            labelFeatureName.Location = new Point(6, 276);
            labelFeatureName.Name = "labelFeatureName";
            labelFeatureName.Size = new Size(103, 19);
            labelFeatureName.TabIndex = 15;
            labelFeatureName.Text = "FeatureName";
            // 
            // textFeatureName
            // 
            textFeatureName.Location = new Point(117, 270);
            textFeatureName.Name = "textFeatureName";
            textFeatureName.Size = new Size(156, 27);
            textFeatureName.TabIndex = 16;
            // 
            // labelCanny1
            // 
            labelCanny1.AutoSize = true;
            labelCanny1.Location = new Point(14, 308);
            labelCanny1.Name = "labelCanny1";
            labelCanny1.Size = new Size(62, 19);
            labelCanny1.TabIndex = 17;
            labelCanny1.Text = "Canny1";
            // 
            // numCanny1
            // 
            numCanny1.Location = new Point(93, 305);
            numCanny1.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            numCanny1.Name = "numCanny1";
            numCanny1.Size = new Size(104, 27);
            numCanny1.TabIndex = 18;
            numCanny1.Value = new decimal(new int[] { 50, 0, 0, 0 });
            // 
            // labelCanny2
            // 
            labelCanny2.AutoSize = true;
            labelCanny2.Location = new Point(14, 344);
            labelCanny2.Name = "labelCanny2";
            labelCanny2.Size = new Size(62, 19);
            labelCanny2.TabIndex = 19;
            labelCanny2.Text = "Canny2";
            // 
            // numCanny2
            // 
            numCanny2.Location = new Point(93, 341);
            numCanny2.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            numCanny2.Name = "numCanny2";
            numCanny2.Size = new Size(104, 27);
            numCanny2.TabIndex = 20;
            numCanny2.Value = new decimal(new int[] { 150, 0, 0, 0 });
            // 
            // ToolSettingForm
            // 
            AutoScaleDimensions = new SizeF(9F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(884, 529);
            Controls.Add(numCanny2);
            Controls.Add(labelCanny2);
            Controls.Add(numCanny1);
            Controls.Add(labelCanny1);
            Controls.Add(textFeatureName);
            Controls.Add(labelFeatureName);
            Controls.Add(pictureBoxImage);
            Controls.Add(checkUseROI);
            Controls.Add(checkUseThreshold);
            Controls.Add(numThreshold);
            Controls.Add(labelThreshold);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(numH);
            Controls.Add(numW);
            Controls.Add(numY);
            Controls.Add(labelH);
            Controls.Add(labelW);
            Controls.Add(labelY);
            Controls.Add(numX);
            Controls.Add(labelX);
            Name = "ToolSettingForm";
            Text = "參數設定";
            ((System.ComponentModel.ISupportInitialize)numX).EndInit();
            ((System.ComponentModel.ISupportInitialize)numY).EndInit();
            ((System.ComponentModel.ISupportInitialize)numW).EndInit();
            ((System.ComponentModel.ISupportInitialize)numH).EndInit();
            ((System.ComponentModel.ISupportInitialize)numThreshold).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxImage).EndInit();
            ((System.ComponentModel.ISupportInitialize)numCanny1).EndInit();
            ((System.ComponentModel.ISupportInitialize)numCanny2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelX;
        private NumericUpDown numX;
        private Label labelY;
        private Label labelW;
        private Label labelH;
        private NumericUpDown numY;
        private NumericUpDown numW;
        private NumericUpDown numH;
        private Button btnSave;
        private Button btnCancel;
        private Label labelThreshold;
        private NumericUpDown numThreshold;
        private CheckBox checkUseThreshold;
        private CheckBox checkUseROI;
        private PictureBox pictureBoxImage;
        private Label labelFeatureName;
        private TextBox textFeatureName;
        private Label labelCanny1;
        private NumericUpDown numCanny1;
        private Label labelCanny2;
        private NumericUpDown numCanny2;
    }
}