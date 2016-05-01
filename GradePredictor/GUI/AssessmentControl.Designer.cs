namespace GradePredictor.GUI
{
    partial class AssessmentControl
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
            this.assessment.Change -= this.assessmentChangedHandler;
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblType = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.pnlData = new System.Windows.Forms.Panel();
            this.lblWeight = new System.Windows.Forms.Label();
            this.lblWeightTitle = new System.Windows.Forms.Label();
            this.lblResult = new System.Windows.Forms.Label();
            this.lblResultTitle = new System.Windows.Forms.Label();
            this.btnRemove = new System.Windows.Forms.Button();
            this.pnlData.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblType
            // 
            this.lblType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lblType.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblType.Location = new System.Drawing.Point(3, 0);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(105, 48);
            this.lblType.TabIndex = 0;
            this.lblType.Text = "<OTHER>";
            this.lblType.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblName
            // 
            this.lblName.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblName.AutoEllipsis = true;
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(114, 0);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(147, 48);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "Coursework 2";
            this.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlData
            // 
            this.pnlData.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlData.Controls.Add(this.lblWeight);
            this.pnlData.Controls.Add(this.lblWeightTitle);
            this.pnlData.Controls.Add(this.lblResult);
            this.pnlData.Controls.Add(this.lblResultTitle);
            this.pnlData.Location = new System.Drawing.Point(267, 0);
            this.pnlData.Name = "pnlData";
            this.pnlData.Size = new System.Drawing.Size(130, 48);
            this.pnlData.TabIndex = 2;
            // 
            // lblWeight
            // 
            this.lblWeight.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblWeight.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWeight.Location = new System.Drawing.Point(14, 23);
            this.lblWeight.Name = "lblWeight";
            this.lblWeight.Size = new System.Drawing.Size(44, 17);
            this.lblWeight.TabIndex = 3;
            this.lblWeight.Text = "100%";
            this.lblWeight.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblWeightTitle
            // 
            this.lblWeightTitle.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblWeightTitle.AutoSize = true;
            this.lblWeightTitle.Location = new System.Drawing.Point(14, 10);
            this.lblWeightTitle.Name = "lblWeightTitle";
            this.lblWeightTitle.Size = new System.Drawing.Size(44, 13);
            this.lblWeightTitle.TabIndex = 2;
            this.lblWeightTitle.Text = "Weight:";
            // 
            // lblResult
            // 
            this.lblResult.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResult.Location = new System.Drawing.Point(64, 23);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(63, 17);
            this.lblResult.TabIndex = 1;
            this.lblResult.Text = "100.0%";
            this.lblResult.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblResultTitle
            // 
            this.lblResultTitle.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblResultTitle.AutoSize = true;
            this.lblResultTitle.Location = new System.Drawing.Point(75, 10);
            this.lblResultTitle.Name = "lblResultTitle";
            this.lblResultTitle.Size = new System.Drawing.Size(40, 13);
            this.lblResultTitle.TabIndex = 0;
            this.lblResultTitle.Text = "Result:";
            // 
            // btnRemove
            // 
            this.btnRemove.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnRemove.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.btnRemove.Image = global::GradePredictor.Properties.Resources.IconDeleteMedium;
            this.btnRemove.Location = new System.Drawing.Point(403, 2);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(44, 44);
            this.btnRemove.TabIndex = 3;
            this.btnRemove.UseVisualStyleBackColor = true;
            // 
            // AssessmentControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.pnlData);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblType);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.MaximumSize = new System.Drawing.Size(1920, 50);
            this.MinimumSize = new System.Drawing.Size(300, 50);
            this.Name = "AssessmentControl";
            this.Size = new System.Drawing.Size(450, 48);
            this.pnlData.ResumeLayout(false);
            this.pnlData.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Panel pnlData;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Label lblWeight;
        private System.Windows.Forms.Label lblWeightTitle;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.Label lblResultTitle;
    }
}
