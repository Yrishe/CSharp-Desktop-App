namespace Extract_Mc_Results.Frontend
{
    partial class View
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
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.elementLabel = new System.Windows.Forms.Label();
            this.timeLabel = new System.Windows.Forms.Label();
            this.sourceLabel = new System.Windows.Forms.Label();
            this.sourceTxtBox = new System.Windows.Forms.TextBox();
            this.targetLabel = new System.Windows.Forms.Label();
            this.targetTxtBox = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnTargetBrowser = new System.Windows.Forms.Button();
            this.btnSourceBrowser = new System.Windows.Forms.Button();
            this.runBtn = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.checkedListBox2 = new System.Windows.Forms.CheckedListBox();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.progressLabel = new System.Windows.Forms.Label();
            this.percent = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.Checked = false;
            this.dateTimePicker1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dateTimePicker1.Location = new System.Drawing.Point(318, 86);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(171, 24);
            this.dateTimePicker1.TabIndex = 2;
            this.dateTimePicker1.Value = new System.DateTime(2024, 10, 18, 0, 0, 0, 0);
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // elementLabel
            // 
            this.elementLabel.AutoSize = true;
            this.elementLabel.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.elementLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.elementLabel.Location = new System.Drawing.Point(65, 23);
            this.elementLabel.Name = "elementLabel";
            this.elementLabel.Size = new System.Drawing.Size(121, 24);
            this.elementLabel.TabIndex = 3;
            this.elementLabel.Text = "ELEMENTS";
            // 
            // timeLabel
            // 
            this.timeLabel.AutoSize = true;
            this.timeLabel.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.timeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timeLabel.Location = new System.Drawing.Point(342, 41);
            this.timeLabel.Name = "timeLabel";
            this.timeLabel.Size = new System.Drawing.Size(129, 24);
            this.timeLabel.TabIndex = 4;
            this.timeLabel.Text = "TIMESTAMP";
            // 
            // sourceLabel
            // 
            this.sourceLabel.AutoSize = true;
            this.sourceLabel.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.sourceLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sourceLabel.Location = new System.Drawing.Point(65, 259);
            this.sourceLabel.Name = "sourceLabel";
            this.sourceLabel.Size = new System.Drawing.Size(222, 24);
            this.sourceLabel.TabIndex = 6;
            this.sourceLabel.Text = "Source Path (Optional)";
            // 
            // sourceTxtBox
            // 
            this.sourceTxtBox.BackColor = System.Drawing.SystemColors.Window;
            this.sourceTxtBox.Location = new System.Drawing.Point(71, 294);
            this.sourceTxtBox.Name = "sourceTxtBox";
            this.sourceTxtBox.Size = new System.Drawing.Size(402, 24);
            this.sourceTxtBox.TabIndex = 7;
            this.sourceTxtBox.TextChanged += new System.EventHandler(this.sourceTxtBox_TextChanged);
            // 
            // targetLabel
            // 
            this.targetLabel.AutoSize = true;
            this.targetLabel.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.targetLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.targetLabel.Location = new System.Drawing.Point(66, 357);
            this.targetLabel.Name = "targetLabel";
            this.targetLabel.Size = new System.Drawing.Size(215, 24);
            this.targetLabel.TabIndex = 8;
            this.targetLabel.Text = "Target Path (Optional)";
            // 
            // targetTxtBox
            // 
            this.targetTxtBox.Location = new System.Drawing.Point(70, 392);
            this.targetTxtBox.Name = "targetTxtBox";
            this.targetTxtBox.Size = new System.Drawing.Size(403, 24);
            this.targetTxtBox.TabIndex = 9;
            this.targetTxtBox.TextChanged += new System.EventHandler(this.targetTxtBox_TextChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.panel1.Controls.Add(this.btnTargetBrowser);
            this.panel1.Controls.Add(this.btnSourceBrowser);
            this.panel1.Location = new System.Drawing.Point(46, 239);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(556, 219);
            this.panel1.TabIndex = 10;
            // 
            // btnTargetBrowser
            // 
            this.btnTargetBrowser.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTargetBrowser.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTargetBrowser.Location = new System.Drawing.Point(447, 157);
            this.btnTargetBrowser.Name = "btnTargetBrowser";
            this.btnTargetBrowser.Size = new System.Drawing.Size(38, 20);
            this.btnTargetBrowser.TabIndex = 1;
            this.btnTargetBrowser.Text = "...";
            this.btnTargetBrowser.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnTargetBrowser.UseVisualStyleBackColor = true;
            this.btnTargetBrowser.Click += new System.EventHandler(this.btnTargetBrowser_Click);
            // 
            // btnSourceBrowser
            // 
            this.btnSourceBrowser.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSourceBrowser.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSourceBrowser.Location = new System.Drawing.Point(447, 58);
            this.btnSourceBrowser.Name = "btnSourceBrowser";
            this.btnSourceBrowser.Size = new System.Drawing.Size(38, 20);
            this.btnSourceBrowser.TabIndex = 0;
            this.btnSourceBrowser.Text = "...";
            this.btnSourceBrowser.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSourceBrowser.UseVisualStyleBackColor = true;
            this.btnSourceBrowser.Click += new System.EventHandler(this.btnSourceBrowser_Click);
            // 
            // runBtn
            // 
            this.runBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.runBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.runBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.runBtn.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.runBtn.Location = new System.Drawing.Point(46, 501);
            this.runBtn.Name = "runBtn";
            this.runBtn.Size = new System.Drawing.Size(115, 50);
            this.runBtn.TabIndex = 11;
            this.runBtn.Text = "RUN";
            this.runBtn.UseVisualStyleBackColor = false;
            this.runBtn.Click += new System.EventHandler(this.runBtn_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.panel2.Controls.Add(this.checkedListBox2);
            this.panel2.Location = new System.Drawing.Point(12, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(603, 471);
            this.panel2.TabIndex = 11;
            // 
            // checkedListBox2
            // 
            this.checkedListBox2.AccessibleRole = System.Windows.Forms.AccessibleRole.Cursor;
            this.checkedListBox2.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.checkedListBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.checkedListBox2.CausesValidation = false;
            this.checkedListBox2.CheckOnClick = true;
            this.checkedListBox2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.checkedListBox2.FormattingEnabled = true;
            this.checkedListBox2.ImeMode = System.Windows.Forms.ImeMode.On;
            this.checkedListBox2.Items.AddRange(new object[] {
            "CHRs",
            "HDRs",
            "FETs",
            "PDFs",
            "Points",
            "Process Data"});
            this.checkedListBox2.Location = new System.Drawing.Point(34, 57);
            this.checkedListBox2.Name = "checkedListBox2";
            this.checkedListBox2.Size = new System.Drawing.Size(241, 133);
            this.checkedListBox2.TabIndex = 0;
            this.checkedListBox2.Click += new System.EventHandler(this.CheckedListBox2_SelectedIndexChanged);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(385, 519);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(230, 32);
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar.TabIndex = 12;
            this.progressBar.Click += new System.EventHandler(this.progressBar_Click);
            // 
            // progressLabel
            // 
            this.progressLabel.AutoSize = true;
            this.progressLabel.Location = new System.Drawing.Point(406, 490);
            this.progressLabel.Name = "progressLabel";
            this.progressLabel.Size = new System.Drawing.Size(69, 18);
            this.progressLabel.TabIndex = 13;
            this.progressLabel.Text = "Progress";
            // 
            // percent
            // 
            this.percent.AutoSize = true;
            this.percent.Location = new System.Drawing.Point(403, 554);
            this.percent.Name = "percent";
            this.percent.Size = new System.Drawing.Size(16, 18);
            this.percent.TabIndex = 14;
            this.percent.Text = "0";
            // 
            // folderBrowserDialog1
            // 
            this.folderBrowserDialog1.SelectedPath = "\"\\\\Public\\Documents\\Mc\\CAL\\work\\results\\-N" + "PI\"";
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip1.Location = new System.Drawing.Point(0, 558);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(627, 22);
            this.statusStrip1.TabIndex = 15;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // View
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(627, 580);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.percent);
            this.Controls.Add(this.progressLabel);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.runBtn);
            this.Controls.Add(this.targetTxtBox);
            this.Controls.Add(this.targetLabel);
            this.Controls.Add(this.sourceTxtBox);
            this.Controls.Add(this.sourceLabel);
            this.Controls.Add(this.timeLabel);
            this.Controls.Add(this.elementLabel);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "View";
            this.Text = "Mc RESULTS COLLECTOR";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label elementLabel;
        private System.Windows.Forms.Label timeLabel;
        private System.Windows.Forms.Label sourceLabel;
        private System.Windows.Forms.TextBox sourceTxtBox;
        private System.Windows.Forms.Label targetLabel;
        private System.Windows.Forms.TextBox targetTxtBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button runBtn;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label progressLabel;
        private System.Windows.Forms.Button btnSourceBrowser;
        private System.Windows.Forms.Button btnTargetBrowser;
        private System.Windows.Forms.Label percent;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.CheckedListBox checkedListBox2;
        private System.Windows.Forms.StatusStrip statusStrip1;
    }
}
