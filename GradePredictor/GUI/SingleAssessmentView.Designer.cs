namespace GradePredictor.GUI
{
    partial class SingleAssessmentView
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
            this.lblType = new System.Windows.Forms.Label();
            this.lblWeight = new System.Windows.Forms.Label();
            this.lblResult = new System.Windows.Forms.Label();
            this.cbType = new System.Windows.Forms.ComboBox();
            this.tbWeight = new System.Windows.Forms.TextBox();
            this.tbResult = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.tbName = new System.Windows.Forms.TextBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblType.Location = new System.Drawing.Point(12, 13);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(44, 17);
            this.lblType.TabIndex = 0;
            this.lblType.Text = "Type:";
            // 
            // lblWeight
            // 
            this.lblWeight.AutoSize = true;
            this.lblWeight.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWeight.Location = new System.Drawing.Point(12, 63);
            this.lblWeight.Name = "lblWeight";
            this.lblWeight.Size = new System.Drawing.Size(56, 17);
            this.lblWeight.TabIndex = 1;
            this.lblWeight.Text = "Weight:";
            // 
            // lblResult
            // 
            this.lblResult.AutoSize = true;
            this.lblResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResult.Location = new System.Drawing.Point(12, 89);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(52, 17);
            this.lblResult.TabIndex = 2;
            this.lblResult.Text = "Result:";
            // 
            // cbType
            // 
            this.cbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbType.FormattingEnabled = true;
            this.cbType.Items.AddRange(new object[] {
            "Other",
            "Test",
            "Viva",
            "Exam",
            "Coursework"});
            this.cbType.Location = new System.Drawing.Point(74, 9);
            this.cbType.Name = "cbType";
            this.cbType.Size = new System.Drawing.Size(121, 21);
            this.cbType.TabIndex = 1;
            // 
            // tbWeight
            // 
            this.tbWeight.Location = new System.Drawing.Point(74, 62);
            this.tbWeight.Name = "tbWeight";
            this.tbWeight.Size = new System.Drawing.Size(121, 20);
            this.tbWeight.TabIndex = 3;
            // 
            // tbResult
            // 
            this.tbResult.Location = new System.Drawing.Point(74, 88);
            this.tbResult.Name = "tbResult";
            this.tbResult.Size = new System.Drawing.Size(121, 20);
            this.tbResult.TabIndex = 4;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(12, 37);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(49, 17);
            this.lblName.TabIndex = 6;
            this.lblName.Text = "Name:";
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(74, 36);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(121, 20);
            this.tbName.TabIndex = 2;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(15, 114);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(180, 23);
            this.btnOk.TabIndex = 5;
            this.btnOk.Text = "Save";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // SingleAssessmentView
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(211, 145);
            this.ControlBox = false;
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.tbResult);
            this.Controls.Add(this.tbWeight);
            this.Controls.Add(this.cbType);
            this.Controls.Add(this.lblResult);
            this.Controls.Add(this.lblWeight);
            this.Controls.Add(this.lblType);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SingleAssessmentView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Assessment";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SingleAssessmentView_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.Label lblWeight;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.ComboBox cbType;
        private System.Windows.Forms.TextBox tbWeight;
        private System.Windows.Forms.TextBox tbResult;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Button btnOk;
    }
}