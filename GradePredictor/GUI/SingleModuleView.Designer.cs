namespace GradePredictor.GUI
{
    partial class SingleModuleView
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
            this.divider1 = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.lblCode = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblResult = new System.Windows.Forms.Label();
            this.lblResultText = new System.Windows.Forms.Label();
            this.pnlAssessments = new System.Windows.Forms.Panel();
            this.lblHelp = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.lblCredits = new System.Windows.Forms.Label();
            this.pbName = new System.Windows.Forms.PictureBox();
            this.pbCode = new System.Windows.Forms.PictureBox();
            this.pbCredits = new System.Windows.Forms.PictureBox();
            this.pnlAssessments.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCredits)).BeginInit();
            this.SuspendLayout();
            // 
            // divider1
            // 
            this.divider1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.divider1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.divider1.Location = new System.Drawing.Point(-40, 77);
            this.divider1.Name = "divider1";
            this.divider1.Size = new System.Drawing.Size(1084, 2);
            this.divider1.TabIndex = 0;
            // 
            // lblName
            // 
            this.lblName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblName.AutoEllipsis = true;
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblName.Location = new System.Drawing.Point(241, 31);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(279, 46);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "Module Name";
            this.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCode
            // 
            this.lblCode.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblCode.AutoEllipsis = true;
            this.lblCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblCode.Location = new System.Drawing.Point(317, 9);
            this.lblCode.Name = "lblCode";
            this.lblCode.Size = new System.Drawing.Size(130, 22);
            this.lblCode.TabIndex = 2;
            this.lblCode.Text = "[MCODE000]";
            this.lblCode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Location = new System.Drawing.Point(142, -71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(2, 150);
            this.label1.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Result:";
            // 
            // lblResult
            // 
            this.lblResult.AutoSize = true;
            this.lblResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblResult.Location = new System.Drawing.Point(44, 31);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(38, 20);
            this.lblResult.TabIndex = 5;
            this.lblResult.Text = "---%";
            // 
            // lblResultText
            // 
            this.lblResultText.AutoSize = true;
            this.lblResultText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblResultText.Location = new System.Drawing.Point(45, 52);
            this.lblResultText.Name = "lblResultText";
            this.lblResultText.Size = new System.Drawing.Size(91, 20);
            this.lblResultText.TabIndex = 6;
            this.lblResultText.Text = "UNKNOWN";
            // 
            // pnlAssessments
            // 
            this.pnlAssessments.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlAssessments.AutoScroll = true;
            this.pnlAssessments.Controls.Add(this.lblHelp);
            this.pnlAssessments.Controls.Add(this.btnAdd);
            this.pnlAssessments.Location = new System.Drawing.Point(12, 82);
            this.pnlAssessments.Name = "pnlAssessments";
            this.pnlAssessments.Size = new System.Drawing.Size(590, 270);
            this.pnlAssessments.TabIndex = 7;
            // 
            // lblHelp
            // 
            this.lblHelp.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblHelp.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblHelp.Location = new System.Drawing.Point(102, 84);
            this.lblHelp.Name = "lblHelp";
            this.lblHelp.Size = new System.Drawing.Size(406, 48);
            this.lblHelp.TabIndex = 1;
            this.lblHelp.Text = "There are no assessments in this module yet. Add the first one by clicking on the" +
    " button below:";
            this.lblHelp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAdd.Image = global::GradePredictor.Properties.Resources.IconPlusMedium;
            this.btnAdd.Location = new System.Drawing.Point(284, 135);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(36, 36);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.TabStop = false;
            this.btnAdd.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(560, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Credits:";
            // 
            // lblCredits
            // 
            this.lblCredits.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCredits.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCredits.Location = new System.Drawing.Point(562, 31);
            this.lblCredits.Name = "lblCredits";
            this.lblCredits.Size = new System.Drawing.Size(32, 17);
            this.lblCredits.TabIndex = 9;
            this.lblCredits.Text = "15";
            this.lblCredits.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pbName
            // 
            this.pbName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pbName.Image = global::GradePredictor.Properties.Resources.IconPencilMedium;
            this.pbName.InitialImage = null;
            this.pbName.Location = new System.Drawing.Point(526, 42);
            this.pbName.Name = "pbName";
            this.pbName.Size = new System.Drawing.Size(30, 30);
            this.pbName.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbName.TabIndex = 10;
            this.pbName.TabStop = false;
            this.pbName.Click += new System.EventHandler(this.textEditButtonClickHandler);
            // 
            // pbCode
            // 
            this.pbCode.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pbCode.Image = global::GradePredictor.Properties.Resources.IconPencilSmall;
            this.pbCode.Location = new System.Drawing.Point(453, 12);
            this.pbCode.Name = "pbCode";
            this.pbCode.Size = new System.Drawing.Size(20, 20);
            this.pbCode.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbCode.TabIndex = 11;
            this.pbCode.TabStop = false;
            this.pbCode.Click += new System.EventHandler(this.textEditButtonClickHandler);
            // 
            // pbCredits
            // 
            this.pbCredits.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pbCredits.Image = global::GradePredictor.Properties.Resources.IconPencilSmall;
            this.pbCredits.Location = new System.Drawing.Point(595, 32);
            this.pbCredits.Name = "pbCredits";
            this.pbCredits.Size = new System.Drawing.Size(16, 16);
            this.pbCredits.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbCredits.TabIndex = 12;
            this.pbCredits.TabStop = false;
            this.pbCredits.Click += new System.EventHandler(this.textEditButtonClickHandler);
            // 
            // SingleModuleView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(614, 364);
            this.Controls.Add(this.pbCredits);
            this.Controls.Add(this.pbCode);
            this.Controls.Add(this.pbName);
            this.Controls.Add(this.lblCredits);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.pnlAssessments);
            this.Controls.Add(this.lblResultText);
            this.Controls.Add(this.lblResult);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblCode);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.divider1);
            this.DoubleBuffered = true;
            this.MinimumSize = new System.Drawing.Size(600, 250);
            this.Name = "SingleModuleView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Module: ?";
            this.pnlAssessments.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCredits)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label divider1;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblCode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.Label lblResultText;
        private System.Windows.Forms.Panel pnlAssessments;
        private System.Windows.Forms.Label lblHelp;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblCredits;
        private System.Windows.Forms.PictureBox pbName;
        private System.Windows.Forms.PictureBox pbCode;
        private System.Windows.Forms.PictureBox pbCredits;
    }
}