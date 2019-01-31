namespace English_Learning_Application.Boundary
{
    partial class FormRun
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormRun));
            this.lblTitle = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblDuration = new System.Windows.Forms.Label();
            this.gbQuestion = new System.Windows.Forms.GroupBox();
            this.txtQuestion = new System.Windows.Forms.TextBox();
            this.cbAnswer = new System.Windows.Forms.ComboBox();
            this.btnYes = new System.Windows.Forms.Button();
            this.txtQuestion2 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.gbChoice = new System.Windows.Forms.GroupBox();
            this.rbChoice7 = new System.Windows.Forms.RadioButton();
            this.rbChoice6 = new System.Windows.Forms.RadioButton();
            this.rbChoice5 = new System.Windows.Forms.RadioButton();
            this.rbChoice4 = new System.Windows.Forms.RadioButton();
            this.rbChoice3 = new System.Windows.Forms.RadioButton();
            this.rbChoice2 = new System.Windows.Forms.RadioButton();
            this.rbChoice1 = new System.Windows.Forms.RadioButton();
            this.txtID = new System.Windows.Forms.TextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.dgTemp = new System.Windows.Forms.DataGridView();
            this.txtTemp = new System.Windows.Forms.TextBox();
            this.lblPoin = new System.Windows.Forms.Label();
            this.txtTempPoin = new System.Windows.Forms.TextBox();
            this.txtRow = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lblTempH = new System.Windows.Forms.Label();
            this.lblTempM = new System.Windows.Forms.Label();
            this.lblTempS = new System.Windows.Forms.Label();
            this.lblSecond = new System.Windows.Forms.Label();
            this.lblMinutes = new System.Windows.Forms.Label();
            this.lblHours = new System.Windows.Forms.Label();
            this.gbQuestion.SuspendLayout();
            this.txtQuestion2.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.gbChoice.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgTemp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Cambria", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(134, 51);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(77, 28);
            this.lblTitle.TabIndex = 2;
            this.lblTitle.Text = "TITLE";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(647, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Duration";
            // 
            // lblDuration
            // 
            this.lblDuration.AutoSize = true;
            this.lblDuration.Font = new System.Drawing.Font("Cambria", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDuration.Location = new System.Drawing.Point(813, 9);
            this.lblDuration.Name = "lblDuration";
            this.lblDuration.Size = new System.Drawing.Size(81, 28);
            this.lblDuration.TabIndex = 4;
            this.lblDuration.Text = ":           :";
            // 
            // gbQuestion
            // 
            this.gbQuestion.Controls.Add(this.txtQuestion);
            this.gbQuestion.Controls.Add(this.cbAnswer);
            this.gbQuestion.Location = new System.Drawing.Point(6, 20);
            this.gbQuestion.Name = "gbQuestion";
            this.gbQuestion.Size = new System.Drawing.Size(456, 250);
            this.gbQuestion.TabIndex = 5;
            this.gbQuestion.TabStop = false;
            this.gbQuestion.Text = "Questions";
            // 
            // txtQuestion
            // 
            this.txtQuestion.Location = new System.Drawing.Point(6, 18);
            this.txtQuestion.Multiline = true;
            this.txtQuestion.Name = "txtQuestion";
            this.txtQuestion.ReadOnly = true;
            this.txtQuestion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtQuestion.Size = new System.Drawing.Size(444, 196);
            this.txtQuestion.TabIndex = 9;
            // 
            // cbAnswer
            // 
            this.cbAnswer.FormattingEnabled = true;
            this.cbAnswer.Items.AddRange(new object[] {
            "True",
            "False"});
            this.cbAnswer.Location = new System.Drawing.Point(329, 220);
            this.cbAnswer.Name = "cbAnswer";
            this.cbAnswer.Size = new System.Drawing.Size(121, 21);
            this.cbAnswer.TabIndex = 10;
            this.cbAnswer.Text = "Choose";
            // 
            // btnYes
            // 
            this.btnYes.Enabled = false;
            this.btnYes.Location = new System.Drawing.Point(885, 426);
            this.btnYes.Name = "btnYes";
            this.btnYes.Size = new System.Drawing.Size(75, 23);
            this.btnYes.TabIndex = 6;
            this.btnYes.Text = "Yes";
            this.btnYes.UseVisualStyleBackColor = true;
            this.btnYes.Click += new System.EventHandler(this.btnYes_Click);
            // 
            // txtQuestion2
            // 
            this.txtQuestion2.Controls.Add(this.tabPage1);
            this.txtQuestion2.Location = new System.Drawing.Point(139, 91);
            this.txtQuestion2.Name = "txtQuestion2";
            this.txtQuestion2.SelectedIndex = 0;
            this.txtQuestion2.Size = new System.Drawing.Size(821, 313);
            this.txtQuestion2.TabIndex = 7;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.gbChoice);
            this.tabPage1.Controls.Add(this.gbQuestion);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(813, 287);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // gbChoice
            // 
            this.gbChoice.Controls.Add(this.rbChoice7);
            this.gbChoice.Controls.Add(this.rbChoice6);
            this.gbChoice.Controls.Add(this.rbChoice5);
            this.gbChoice.Controls.Add(this.rbChoice4);
            this.gbChoice.Controls.Add(this.rbChoice3);
            this.gbChoice.Controls.Add(this.rbChoice2);
            this.gbChoice.Controls.Add(this.rbChoice1);
            this.gbChoice.Location = new System.Drawing.Point(468, 20);
            this.gbChoice.Name = "gbChoice";
            this.gbChoice.Size = new System.Drawing.Size(339, 250);
            this.gbChoice.TabIndex = 6;
            this.gbChoice.TabStop = false;
            this.gbChoice.Text = "Choices";
            // 
            // rbChoice7
            // 
            this.rbChoice7.AutoSize = true;
            this.rbChoice7.Location = new System.Drawing.Point(16, 157);
            this.rbChoice7.Name = "rbChoice7";
            this.rbChoice7.Size = new System.Drawing.Size(67, 17);
            this.rbChoice7.TabIndex = 6;
            this.rbChoice7.TabStop = true;
            this.rbChoice7.Text = "Choice 7";
            this.rbChoice7.UseVisualStyleBackColor = true;
            this.rbChoice7.Visible = false;
            // 
            // rbChoice6
            // 
            this.rbChoice6.AutoSize = true;
            this.rbChoice6.Location = new System.Drawing.Point(16, 134);
            this.rbChoice6.Name = "rbChoice6";
            this.rbChoice6.Size = new System.Drawing.Size(67, 17);
            this.rbChoice6.TabIndex = 5;
            this.rbChoice6.TabStop = true;
            this.rbChoice6.Text = "Choice 6";
            this.rbChoice6.UseVisualStyleBackColor = true;
            this.rbChoice6.Visible = false;
            // 
            // rbChoice5
            // 
            this.rbChoice5.AutoSize = true;
            this.rbChoice5.Location = new System.Drawing.Point(16, 111);
            this.rbChoice5.Name = "rbChoice5";
            this.rbChoice5.Size = new System.Drawing.Size(67, 17);
            this.rbChoice5.TabIndex = 4;
            this.rbChoice5.TabStop = true;
            this.rbChoice5.Text = "Choice 5";
            this.rbChoice5.UseVisualStyleBackColor = true;
            this.rbChoice5.Visible = false;
            // 
            // rbChoice4
            // 
            this.rbChoice4.AutoSize = true;
            this.rbChoice4.Location = new System.Drawing.Point(16, 88);
            this.rbChoice4.Name = "rbChoice4";
            this.rbChoice4.Size = new System.Drawing.Size(67, 17);
            this.rbChoice4.TabIndex = 3;
            this.rbChoice4.TabStop = true;
            this.rbChoice4.Text = "Choice 4";
            this.rbChoice4.UseVisualStyleBackColor = true;
            this.rbChoice4.Visible = false;
            // 
            // rbChoice3
            // 
            this.rbChoice3.AutoSize = true;
            this.rbChoice3.Location = new System.Drawing.Point(16, 65);
            this.rbChoice3.Name = "rbChoice3";
            this.rbChoice3.Size = new System.Drawing.Size(67, 17);
            this.rbChoice3.TabIndex = 2;
            this.rbChoice3.TabStop = true;
            this.rbChoice3.Text = "Choice 3";
            this.rbChoice3.UseVisualStyleBackColor = true;
            this.rbChoice3.Visible = false;
            // 
            // rbChoice2
            // 
            this.rbChoice2.AutoSize = true;
            this.rbChoice2.Location = new System.Drawing.Point(16, 42);
            this.rbChoice2.Name = "rbChoice2";
            this.rbChoice2.Size = new System.Drawing.Size(67, 17);
            this.rbChoice2.TabIndex = 1;
            this.rbChoice2.TabStop = true;
            this.rbChoice2.Text = "Choice 2";
            this.rbChoice2.UseVisualStyleBackColor = true;
            this.rbChoice2.Visible = false;
            // 
            // rbChoice1
            // 
            this.rbChoice1.AutoSize = true;
            this.rbChoice1.Location = new System.Drawing.Point(16, 19);
            this.rbChoice1.Name = "rbChoice1";
            this.rbChoice1.Size = new System.Drawing.Size(67, 17);
            this.rbChoice1.TabIndex = 0;
            this.rbChoice1.TabStop = true;
            this.rbChoice1.Text = "Choice 1";
            this.rbChoice1.UseVisualStyleBackColor = true;
            this.rbChoice1.Visible = false;
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(952, 2);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(31, 20);
            this.txtID.TabIndex = 9;
            this.txtID.Visible = false;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(17, 426);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 10;
            this.btnClose.Text = "End";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.dgTemp);
            this.groupBox4.Location = new System.Drawing.Point(17, 91);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(116, 313);
            this.groupBox4.TabIndex = 12;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Number";
            // 
            // dgTemp
            // 
            this.dgTemp.AllowUserToAddRows = false;
            this.dgTemp.AllowUserToDeleteRows = false;
            this.dgTemp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgTemp.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgTemp.Location = new System.Drawing.Point(6, 19);
            this.dgTemp.MultiSelect = false;
            this.dgTemp.Name = "dgTemp";
            this.dgTemp.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgTemp.Size = new System.Drawing.Size(104, 280);
            this.dgTemp.TabIndex = 11;
            this.dgTemp.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgTemp_CellClick);
            // 
            // txtTemp
            // 
            this.txtTemp.Location = new System.Drawing.Point(952, 23);
            this.txtTemp.Name = "txtTemp";
            this.txtTemp.Size = new System.Drawing.Size(31, 20);
            this.txtTemp.TabIndex = 13;
            this.txtTemp.Visible = false;
            // 
            // lblPoin
            // 
            this.lblPoin.AutoSize = true;
            this.lblPoin.Location = new System.Drawing.Point(152, 416);
            this.lblPoin.Name = "lblPoin";
            this.lblPoin.Size = new System.Drawing.Size(43, 13);
            this.lblPoin.TabIndex = 14;
            this.lblPoin.Text = "Poin : 0";
            // 
            // txtTempPoin
            // 
            this.txtTempPoin.Location = new System.Drawing.Point(952, 45);
            this.txtTempPoin.Name = "txtTempPoin";
            this.txtTempPoin.Size = new System.Drawing.Size(31, 20);
            this.txtTempPoin.TabIndex = 15;
            this.txtTempPoin.Text = "0";
            this.txtTempPoin.Visible = false;
            // 
            // txtRow
            // 
            this.txtRow.Location = new System.Drawing.Point(952, 66);
            this.txtRow.Name = "txtRow";
            this.txtRow.Size = new System.Drawing.Size(31, 20);
            this.txtRow.TabIndex = 16;
            this.txtRow.Text = "0";
            this.txtRow.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(17, 6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(107, 73);
            this.pictureBox1.TabIndex = 18;
            this.pictureBox1.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Cambria", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(129, 6);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(368, 32);
            this.label4.TabIndex = 17;
            this.label4.Text = "English Learning Application";
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lblTempH
            // 
            this.lblTempH.AutoSize = true;
            this.lblTempH.Location = new System.Drawing.Point(802, 45);
            this.lblTempH.Name = "lblTempH";
            this.lblTempH.Size = new System.Drawing.Size(35, 13);
            this.lblTempH.TabIndex = 19;
            this.lblTempH.Text = "Hours";
            this.lblTempH.Visible = false;
            // 
            // lblTempM
            // 
            this.lblTempM.AutoSize = true;
            this.lblTempM.Location = new System.Drawing.Point(852, 45);
            this.lblTempM.Name = "lblTempM";
            this.lblTempM.Size = new System.Drawing.Size(44, 13);
            this.lblTempM.TabIndex = 20;
            this.lblTempM.Text = "Minutes";
            this.lblTempM.Visible = false;
            // 
            // lblTempS
            // 
            this.lblTempS.AutoSize = true;
            this.lblTempS.Location = new System.Drawing.Point(902, 45);
            this.lblTempS.Name = "lblTempS";
            this.lblTempS.Size = new System.Drawing.Size(44, 13);
            this.lblTempS.TabIndex = 21;
            this.lblTempS.Text = "Second";
            this.lblTempS.Visible = false;
            // 
            // lblSecond
            // 
            this.lblSecond.AutoSize = true;
            this.lblSecond.Font = new System.Drawing.Font("Cambria", 18F, System.Drawing.FontStyle.Bold);
            this.lblSecond.Location = new System.Drawing.Point(893, 10);
            this.lblSecond.Name = "lblSecond";
            this.lblSecond.Size = new System.Drawing.Size(40, 28);
            this.lblSecond.TabIndex = 24;
            this.lblSecond.Text = "00";
            // 
            // lblMinutes
            // 
            this.lblMinutes.AutoSize = true;
            this.lblMinutes.Font = new System.Drawing.Font("Cambria", 18F, System.Drawing.FontStyle.Bold);
            this.lblMinutes.Location = new System.Drawing.Point(834, 9);
            this.lblMinutes.Name = "lblMinutes";
            this.lblMinutes.Size = new System.Drawing.Size(40, 28);
            this.lblMinutes.TabIndex = 23;
            this.lblMinutes.Text = "00";
            // 
            // lblHours
            // 
            this.lblHours.AutoSize = true;
            this.lblHours.Font = new System.Drawing.Font("Cambria", 18F, System.Drawing.FontStyle.Bold);
            this.lblHours.Location = new System.Drawing.Point(776, 10);
            this.lblHours.Name = "lblHours";
            this.lblHours.Size = new System.Drawing.Size(40, 28);
            this.lblHours.TabIndex = 22;
            this.lblHours.Text = "00";
            // 
            // FormRun
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 461);
            this.ControlBox = false;
            this.Controls.Add(this.lblSecond);
            this.Controls.Add(this.lblMinutes);
            this.Controls.Add(this.lblHours);
            this.Controls.Add(this.lblTempS);
            this.Controls.Add(this.lblTempM);
            this.Controls.Add(this.lblTempH);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtRow);
            this.Controls.Add(this.txtTempPoin);
            this.Controls.Add(this.lblPoin);
            this.Controls.Add(this.txtTemp);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.txtQuestion2);
            this.Controls.Add(this.btnYes);
            this.Controls.Add(this.lblDuration);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblTitle);
            this.Name = "FormRun";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Run";
            this.Load += new System.EventHandler(this.FormRun_Load);
            this.gbQuestion.ResumeLayout(false);
            this.gbQuestion.PerformLayout();
            this.txtQuestion2.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.gbChoice.ResumeLayout(false);
            this.gbChoice.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgTemp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblDuration;
        private System.Windows.Forms.GroupBox gbQuestion;
        private System.Windows.Forms.Button btnYes;
        private System.Windows.Forms.TabControl txtQuestion2;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox gbChoice;
        private System.Windows.Forms.RadioButton rbChoice7;
        private System.Windows.Forms.RadioButton rbChoice6;
        private System.Windows.Forms.RadioButton rbChoice5;
        private System.Windows.Forms.RadioButton rbChoice4;
        private System.Windows.Forms.RadioButton rbChoice3;
        private System.Windows.Forms.RadioButton rbChoice2;
        private System.Windows.Forms.RadioButton rbChoice1;
        private System.Windows.Forms.TextBox txtQuestion;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ComboBox cbAnswer;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.DataGridView dgTemp;
        private System.Windows.Forms.TextBox txtTemp;
        private System.Windows.Forms.Label lblPoin;
        private System.Windows.Forms.TextBox txtTempPoin;
        private System.Windows.Forms.TextBox txtRow;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lblTempH;
        private System.Windows.Forms.Label lblTempM;
        private System.Windows.Forms.Label lblTempS;
        private System.Windows.Forms.Label lblSecond;
        private System.Windows.Forms.Label lblMinutes;
        private System.Windows.Forms.Label lblHours;
    }
}