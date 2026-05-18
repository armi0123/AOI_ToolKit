

namespace AOI_Tool.Forms
{
    partial class PipelineForm
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
            listBoxAvailable = new ListBox();
            btnAdd = new Button();
            listBoxPipeline = new ListBox();
            btnRemove = new Button();
            btnClose = new Button();
            btnSetting = new Button();
            SuspendLayout();
            // 
            // listBoxAvailable
            // 
            listBoxAvailable.FormattingEnabled = true;
            listBoxAvailable.ItemHeight = 19;
            listBoxAvailable.Location = new Point(12, 73);
            listBoxAvailable.Name = "listBoxAvailable";
            listBoxAvailable.Size = new Size(249, 365);
            listBoxAvailable.TabIndex = 0;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(12, 12);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(90, 35);
            btnAdd.TabIndex = 2;
            btnAdd.Text = "新增";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // listBoxPipeline
            // 
            listBoxPipeline.FormattingEnabled = true;
            listBoxPipeline.ItemHeight = 19;
            listBoxPipeline.Location = new Point(412, 73);
            listBoxPipeline.Name = "listBoxPipeline";
            listBoxPipeline.Size = new Size(376, 365);
            listBoxPipeline.TabIndex = 3;
            // 
            // btnRemove
            // 
            btnRemove.Location = new Point(131, 12);
            btnRemove.Name = "btnRemove";
            btnRemove.Size = new Size(98, 35);
            btnRemove.TabIndex = 4;
            btnRemove.Text = "刪除";
            btnRemove.UseVisualStyleBackColor = true;
            btnRemove.Click += btnRemove_Click;
            // 
            // btnClose
            // 
            btnClose.Location = new Point(373, 11);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(93, 35);
            btnClose.TabIndex = 5;
            btnClose.Text = "關閉";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // btnSetting
            // 
            btnSetting.Location = new Point(258, 12);
            btnSetting.Name = "btnSetting";
            btnSetting.Size = new Size(91, 34);
            btnSetting.TabIndex = 6;
            btnSetting.Text = "參數設定";
            btnSetting.UseVisualStyleBackColor = true;
            btnSetting.Click += btnSetting_Click;
            // 
            // PipelineForm
            // 
            AutoScaleDimensions = new SizeF(9F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnSetting);
            Controls.Add(btnClose);
            Controls.Add(btnRemove);
            Controls.Add(listBoxPipeline);
            Controls.Add(btnAdd);
            Controls.Add(listBoxAvailable);
            Name = "PipelineForm";
            Text = "工具排程";
            ResumeLayout(false);
        }


        #endregion

        private ListBox listBoxAvailable;
        private Button btnAdd;
        private ListBox listBoxPipeline;
        private Button btnRemove;
        private Button btnClose;
        private Button btnSetting;
    }
}