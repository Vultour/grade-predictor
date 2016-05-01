namespace GradePredictor.GUI
{
    partial class ModuleControl
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
            this.module.Change -= this.moduleChangedHandler;
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
            this.lblModuleName = new System.Windows.Forms.Label();
            this.lblModuleCode = new System.Windows.Forms.Label();
            this.lblResultPercentage = new System.Windows.Forms.Label();
            this.lblResultText = new System.Windows.Forms.Label();
            this.btnRemove = new System.Windows.Forms.Button();
            this.lblModuleCredits = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblModuleName
            // 
            this.lblModuleName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblModuleName.AutoEllipsis = true;
            this.lblModuleName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblModuleName.Location = new System.Drawing.Point(3, 19);
            this.lblModuleName.Name = "lblModuleName";
            this.lblModuleName.Size = new System.Drawing.Size(145, 25);
            this.lblModuleName.TabIndex = 0;
            this.lblModuleName.Text = "Module Name";
            // 
            // lblModuleCode
            // 
            this.lblModuleCode.AutoEllipsis = true;
            this.lblModuleCode.AutoSize = true;
            this.lblModuleCode.Location = new System.Drawing.Point(6, 9);
            this.lblModuleCode.MaximumSize = new System.Drawing.Size(100, 13);
            this.lblModuleCode.Name = "lblModuleCode";
            this.lblModuleCode.Size = new System.Drawing.Size(37, 13);
            this.lblModuleCode.TabIndex = 1;
            this.lblModuleCode.Text = "CODE";
            // 
            // lblResultPercentage
            // 
            this.lblResultPercentage.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblResultPercentage.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResultPercentage.Location = new System.Drawing.Point(158, 14);
            this.lblResultPercentage.Name = "lblResultPercentage";
            this.lblResultPercentage.Size = new System.Drawing.Size(79, 25);
            this.lblResultPercentage.TabIndex = 2;
            this.lblResultPercentage.Text = "100.0%";
            this.lblResultPercentage.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblResultText
            // 
            this.lblResultText.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblResultText.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResultText.Location = new System.Drawing.Point(237, 14);
            this.lblResultText.Name = "lblResultText";
            this.lblResultText.Size = new System.Drawing.Size(67, 25);
            this.lblResultText.TabIndex = 4;
            this.lblResultText.Text = "???";
            this.lblResultText.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnRemove
            // 
            this.btnRemove.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnRemove.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.btnRemove.Image = global::GradePredictor.Properties.Resources.IconDeleteMedium;
            this.btnRemove.Location = new System.Drawing.Point(306, 7);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(41, 35);
            this.btnRemove.TabIndex = 3;
            this.btnRemove.UseVisualStyleBackColor = true;
            // 
            // lblModuleCredits
            // 
            this.lblModuleCredits.AutoEllipsis = true;
            this.lblModuleCredits.AutoSize = true;
            this.lblModuleCredits.Location = new System.Drawing.Point(49, 9);
            this.lblModuleCredits.MaximumSize = new System.Drawing.Size(60, 13);
            this.lblModuleCredits.Name = "lblModuleCredits";
            this.lblModuleCredits.Size = new System.Drawing.Size(19, 13);
            this.lblModuleCredits.TabIndex = 5;
            this.lblModuleCredits.Text = "15";
            this.lblModuleCredits.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ModuleControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.lblModuleCredits);
            this.Controls.Add(this.lblResultText);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.lblResultPercentage);
            this.Controls.Add(this.lblModuleCode);
            this.Controls.Add(this.lblModuleName);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.MinimumSize = new System.Drawing.Size(350, 50);
            this.Name = "ModuleControl";
            this.Size = new System.Drawing.Size(350, 50);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblModuleName;
        private System.Windows.Forms.Label lblModuleCode;
        private System.Windows.Forms.Label lblResultPercentage;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Label lblResultText;
        private System.Windows.Forms.Label lblModuleCredits;
    }
}
