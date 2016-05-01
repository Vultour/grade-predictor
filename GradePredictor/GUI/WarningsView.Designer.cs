namespace GradePredictor.GUI
{
    partial class WarningsView
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
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem(new string[] {
            "Object1",
            "Level1",
            "Message1"}, -1);
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem(new string[] {
            "Object2",
            "Level2",
            "Message2"}, -1);
            this.courseWarningBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lvWarnings = new System.Windows.Forms.ListView();
            this.clObject = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clLevel = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clMessage = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            ((System.ComponentModel.ISupportInitialize)(this.courseWarningBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // lvWarnings
            // 
            this.lvWarnings.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clObject,
            this.clLevel,
            this.clMessage});
            this.lvWarnings.Dock = System.Windows.Forms.DockStyle.Fill;
            listViewItem1.StateImageIndex = 0;
            listViewItem2.StateImageIndex = 0;
            this.lvWarnings.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2});
            this.lvWarnings.Location = new System.Drawing.Point(0, 0);
            this.lvWarnings.MultiSelect = false;
            this.lvWarnings.Name = "lvWarnings";
            this.lvWarnings.ShowGroups = false;
            this.lvWarnings.Size = new System.Drawing.Size(754, 325);
            this.lvWarnings.TabIndex = 0;
            this.lvWarnings.UseCompatibleStateImageBehavior = false;
            this.lvWarnings.View = System.Windows.Forms.View.Details;
            // 
            // clObject
            // 
            this.clObject.Text = "Object";
            this.clObject.Width = 180;
            // 
            // clLevel
            // 
            this.clLevel.Text = "Level";
            this.clLevel.Width = 93;
            // 
            // clMessage
            // 
            this.clMessage.Text = "Message";
            this.clMessage.Width = 449;
            // 
            // WarningsView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(754, 325);
            this.Controls.Add(this.lvWarnings);
            this.Name = "WarningsView";
            this.Text = "Messages";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.WarningsView_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.courseWarningBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource courseWarningBindingSource;
        private System.Windows.Forms.ListView lvWarnings;
        private System.Windows.Forms.ColumnHeader clObject;
        private System.Windows.Forms.ColumnHeader clMessage;
        private System.Windows.Forms.ColumnHeader clLevel;

    }
}