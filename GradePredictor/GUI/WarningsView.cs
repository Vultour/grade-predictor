using System.Drawing;
using System.Windows.Forms;

using GradePredictor.CourseCore;
using GradePredictor.Util;


/// <copyright file="WarningsView.cs">
///  Copyright (c) All Rights Reserved
///  <author>Martin Kukura</author>
/// </copyright>

namespace GradePredictor.GUI
{
    public partial class WarningsView : Form
    {
        private Panel loader;
        public WarningsView()
        {
            InitializeComponent();
            this.CreateHandle();

            this.loader = new Panel();
            this.Controls.Add(this.loader);
            this.loader.Visible = false;
            this.loader.Location = new Point(0, 0);
            this.loader.Size = this.ClientSize;
            this.loader.BackColor = this.BackColor;
            this.loader.BringToFront();
            Label tmp = new Label();
            tmp.AutoSize = true;
            tmp.Text = "Wait...";
            tmp.Font = new Font(FontFamily.GenericSerif, 25);
            this.loader.Controls.Add(tmp);
            tmp.Center(this.loader);
        }


        public void BeginLoading() { this.loader.Visible = true; }

        public void EndLoading() { this.loader.Visible = false; }


        public void Clear()
        {
            this.lvWarnings.Items.Clear();
        }

        public void AddWarning(CourseWarning w)
        {
            ListViewItem tmp = new ListViewItem(w.Reference);
            tmp.SubItems.Add(new ListViewItem.ListViewSubItem(tmp, w.Level.ToString()));
            tmp.SubItems.Add(new ListViewItem.ListViewSubItem(tmp, w.Message));
            this.lvWarnings.Items.Add(tmp);
        }

        private void WarningsView_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }
    }
}
