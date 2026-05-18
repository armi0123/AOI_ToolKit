namespace AOI_Tool
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnLoad = new Button();
            btnRun = new Button();
            btnEditPipeline = new Button();
            pictureBoxSrc = new PictureBox();
            pictureBoxResult = new PictureBox();
            labelJudge = new Label();
            textBoxMessage = new TextBox();
            ((System.ComponentModel.ISupportInitialize)pictureBoxSrc).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxResult).BeginInit();
            SuspendLayout();
            // 
            // btnLoad
            // 
            btnLoad.Location = new Point(12, 6);
            btnLoad.Name = "btnLoad";
            btnLoad.Size = new Size(105, 30);
            btnLoad.TabIndex = 0;
            btnLoad.Text = "載入圖片";
            btnLoad.UseVisualStyleBackColor = true;
            btnLoad.Click += btnLoad_Click;
            // 
            // btnRun
            // 
            btnRun.Location = new Point(386, 6);
            btnRun.Name = "btnRun";
            btnRun.Size = new Size(105, 30);
            btnRun.TabIndex = 1;
            btnRun.Text = "執行";
            btnRun.UseVisualStyleBackColor = true;
            btnRun.Click += btnRun_Click;
            // 
            // btnEditPipeline
            // 
            btnEditPipeline.Location = new Point(669, 6);
            btnEditPipeline.Name = "btnEditPipeline";
            btnEditPipeline.Size = new Size(119, 30);
            btnEditPipeline.TabIndex = 2;
            btnEditPipeline.Text = "編輯流程";
            btnEditPipeline.UseVisualStyleBackColor = true;
            btnEditPipeline.Click += btnEditPipeline_Click;
            // 
            // pictureBoxSrc
            // 
            pictureBoxSrc.Location = new Point(3, 43);
            pictureBoxSrc.Name = "pictureBoxSrc";
            pictureBoxSrc.Size = new Size(382, 409);
            pictureBoxSrc.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxSrc.TabIndex = 3;
            pictureBoxSrc.TabStop = false;
            // 
            // pictureBoxResult
            // 
            pictureBoxResult.Location = new Point(386, 42);
            pictureBoxResult.Name = "pictureBoxResult";
            pictureBoxResult.Size = new Size(415, 409);
            pictureBoxResult.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxResult.TabIndex = 4;
            pictureBoxResult.TabStop = false;
            pictureBoxResult.Click += pictureBoxResult_Click;
            // 
            // labelJudge
            // 
            labelJudge.AutoSize = true;
            labelJudge.Location = new Point(510, 12);
            labelJudge.Name = "labelJudge";
            labelJudge.Size = new Size(48, 19);
            labelJudge.TabIndex = 5;
            labelJudge.Text = "NULL";
            // 
            // textBoxMessage
            // 
            textBoxMessage.Location = new Point(807, 12);
            textBoxMessage.Multiline = true;
            textBoxMessage.Name = "textBoxMessage";
            textBoxMessage.Size = new Size(167, 439);
            textBoxMessage.TabIndex = 6;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(9F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(982, 452);
            Controls.Add(textBoxMessage);
            Controls.Add(labelJudge);
            Controls.Add(pictureBoxResult);
            Controls.Add(pictureBoxSrc);
            Controls.Add(btnEditPipeline);
            Controls.Add(btnRun);
            Controls.Add(btnLoad);
            Name = "MainForm";
            Text = "要你命4000";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBoxSrc).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxResult).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnLoad;
        private Button btnRun;
        private Button btnEditPipeline;
        private PictureBox pictureBoxSrc;
        private PictureBox pictureBoxResult;
        private Label labelJudge;
        private TextBox textBoxMessage;
    }
}
