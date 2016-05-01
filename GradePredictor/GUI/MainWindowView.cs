using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using GradePredictor.CourseCore;
using GradePredictor.CourseUtil;
using GradePredictor.Util;


/// <copyright file="MainWindowView.cs">
///  Copyright (c) All Rights Reserved
///  <author>Martin Kukura</author>
/// </copyright>

namespace GradePredictor.GUI
{
    public partial class MainWindowView : Form
    {
        public event IntegerDelegate YearChanged;
        public event VoidDelegate CourseDataUpdated;

        private Label[] ctrlHelpText;
        private Button[] ctrlAddButton;
        private Panel loader;

        public Course.Degree Result
        {
            set { this.lblDegree.Text = CourseTextHelper.Degree(value); }
        }

        public double YearOne
        {
            set { this.lblYearOne.Text = CourseTextHelper.Percentage(value); }
        }

        public double YearTwo
        {
            set { this.lblYearTwo.Text = CourseTextHelper.Percentage(value); }
        }

        public double YearThree
        {
            set { this.lblYearThree.Text = CourseTextHelper.Percentage(value); }
        }

        public string Title
        {
            get { return this.lblTitle.Text; }
            set { this.lblTitle.Text = value; }
        }

        public int Warnings
        {
            set { this.lblMessages.Text = String.Format("Messages: {0}", value); }
        }

        public MainWindowView(
            System.EventHandler callbackNew,
            System.EventHandler callbackLoadAuto,
            System.EventHandler callbackLoad,
            System.EventHandler callbackAdd,
            System.EventHandler callbackSave,
            System.EventHandler callbackShowMessages,
            DragEventHandler callbackDrop
        )
        {
            InitializeComponent();
            this.btnStartNew.Click += callbackNew;
            this.btnStartLoad.Click += callbackLoad;
            this.btnStartLoadAuto.Click += callbackLoadAuto;
            this.btnAddOne.Click += callbackAdd;
            this.btnAddTwo.Click += callbackAdd;
            this.btnAddThree.Click += callbackAdd;
            this.btnSave.Click += callbackSave;
            this.btnLoad.Click += callbackLoad;
            this.lblMessages.Click += callbackShowMessages;
            this.DragDrop += callbackDrop;

            this.ctrlHelpText = new Label[3];
            this.ctrlHelpText[0] = this.lblHelpOne;
            this.ctrlHelpText[1] = this.lblHelpTwo;
            this.ctrlHelpText[2] = this.lblHelpThree;

            this.ctrlAddButton = new Button[3];
            this.ctrlAddButton[0] = this.btnAddOne;
            this.ctrlAddButton[1] = this.btnAddTwo;
            this.ctrlAddButton[2] = this.btnAddThree;

            this.loader = new Panel();
            this.Controls.Add(this.loader);
            this.loader.Visible = false;
            this.loader.Location = new Point(this.tcMain.Location.X + 3, this.tcMain.Location.Y + 3);
            this.loader.Size = new Size(this.tcMain.Size.Width - 6, this.tcMain.Size.Height - 6);
            this.loader.Anchor = (AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom);
            this.loader.BackColor = this.BackColor;
            ProgressBar tmpP = new ProgressBar();
            Label tmpL = new Label();
            tmpL.AutoSize = true;
            tmpL.Text = "LOADING";
            tmpL.Font = new System.Drawing.Font(FontFamily.GenericSansSerif, 15, FontStyle.Bold);
            tmpL.ForeColor = Color.Black;
            tmpP.Style = ProgressBarStyle.Marquee;
            tmpP.MarqueeAnimationSpeed = 25;
            tmpL.Center(this.loader, 0, -25);
            tmpP.Center(this.loader);
            this.loader.Controls.Add(tmpP);
            this.loader.Controls.Add(tmpL);
            this.loader.BringToFront();

            this.reset();
        }


        public void reset()
        {
            this.rbOne.Enabled = false;
            this.rbTwo.Enabled = false;
            this.rbThree.Enabled = false;
            this.rbSummary.Enabled = false;

            this.lblTitle.Text = "";
            this.btnSave.Enabled = false;
            this.btnLoad.Enabled = false;
            this.btnRestart.Enabled = false;
            this.pbEditTitle.Visible = false;
            this.mainStatus.Visible = false;

            // Reset window

            this.rbOne.Checked = false;
            this.rbTwo.Checked = false;
            this.rbThree.Checked = false;
            this.rbSummary.Checked = false;
            this.tcMain.SelectedIndex = 0;

            for (int i = (this.tpOne.Controls.Count - 1); i > 1; i--) { Control tmp = this.tpOne.Controls[i]; this.tpOne.Controls.RemoveAt(i); tmp.Dispose(); }
            for (int i = (this.tpTwo.Controls.Count - 1); i > 1; i--) { Control tmp = this.tpTwo.Controls[i]; this.tpTwo.Controls.RemoveAt(i); tmp.Dispose(); }
            for (int i = (this.tpThree.Controls.Count - 1); i > 1; i--) { Control tmp = this.tpThree.Controls[i]; this.tpThree.Controls.RemoveAt(i); tmp.Dispose(); }
            this.updateControls(1);
            this.updateControls(2);
            this.updateControls(3);
        }

        public void startNew(){
            this.rbOne.Enabled = true;
            this.rbTwo.Enabled = true;
            this.rbThree.Enabled = true;
            this.rbSummary.Enabled = true;

            this.btnSave.Enabled = true;
            this.btnLoad.Enabled = true;
            this.btnRestart.Enabled = true;
            this.pbEditTitle.Visible = true;
            this.mainStatus.Visible = true;

            // Reset window

            this.rbOne.Checked = false;
            this.rbTwo.Checked = false;
            this.rbThree.Checked = false;
            this.rbSummary.Checked = false;
            this.rbOne.PerformClick();
        }


        public void BeginLoading() { this.loader.Visible = true; }
        public void EndLoading() { this.loader.Visible = false; }


        public void createModule(int year, System.EventHandler callbackOpen, System.EventHandler callbackRemove, Module module)
        {
            ModuleControl tmp = new ModuleControl(module);
            tmp.Anchor = (AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top);
            tmp.hookFaceClick(callbackOpen);
            tmp.hookRemoveClick(callbackRemove);
            //tmp.Width = this.tcMain.TabPages[year].Width - 2 - ((this.tcMain.TabPages[year].VerticalScroll.Visible) ? (System.Windows.Forms.SystemInformation.VerticalScrollBarWidth) : (0));
            //tmp.Width = this.tcMain.TabPages[year].Width;
            //tmp.Margin = new Padding(5);
            //tmp.Location =  new Point(0, this.tcMain.TabPages[year].AutoScrollPosition.Y + ((this.tcMain.TabPages[year].Controls.Count - 2) * 55) + Int32.Parse(Properties.Resources.MODULE_POSITION_OFFSET));

            if (this.InvokeRequired)
            {
                this.Invoke((MethodInvoker)delegate
                {
                    this.tcMain.TabPages[year].Controls.Add(tmp);
                    this.ResetModuleControlPositions(year);
                    this.updateControls(year);
                });
            }
            else
            {
                this.tcMain.TabPages[year].Controls.Add(tmp);
                this.ResetModuleControlPositions(year);
                this.updateControls(year);
            }
        }

        public void createModule(System.EventHandler callbackOpen, System.EventHandler callbackRemove, Module module)
        {
            this.createModule(
                this.tcMain.SelectedIndex,
                callbackOpen,
                callbackRemove,
                module
            );
        }

        public void editCourseValues(string title, double yearOne, double yearTwo, double yearThree, Course.Degree result)
        {
            this.Invoke((MethodInvoker)delegate
            {
                this.Title = title;
                this.YearOne = yearOne;
                this.YearTwo = yearTwo;
                this.YearThree = yearThree;
                this.Result = result;
            });
        }

        private void mainTabSelectionChanged(object sender, EventArgs e)
        {
            if (!((RadioButton)sender).Checked){ return; }
            switch (((RadioButton)sender).Name)
            {
                case "rbOne":
                    this.tcMain.SelectedIndex = 1;
                    this.onYearChanged();
                    break;
                case "rbTwo":
                    this.tcMain.SelectedIndex = 2;
                    this.onYearChanged();
                    break;
                case "rbThree":
                    this.tcMain.SelectedIndex = 3;
                    this.onYearChanged();
                    break;
                case "rbSummary":
                default:
                    this.tcMain.SelectedIndex = 4;
                    this.onYearChanged();
                    break;
            }
            this.tcMain.SelectedTab.PerformLayout();
        }

        private void onYearChanged()
        {
            if (this.YearChanged != null)
            {
                this.YearChanged(this.tcMain.SelectedIndex);
            }
        }

        public void removeModule(ModuleControl module)
        {
            this.tcMain.SelectedTab.Controls.Remove(module);
            module.Dispose();
            this.ResetModuleControlPositions();
            this.updateControls(this.tcMain.SelectedIndex);
        }

        public void updateControls(int year)
        {
            if ((year < 1) || (year > (this.tcMain.TabPages.Count - 2))) { return; }
            if (this.tcMain.TabPages[year].Controls.Count < 3)
            {
                this.ctrlHelpText[year - 1].Visible = true;
                this.ctrlAddButton[year - 1].Anchor = (AnchorStyles.None);
                this.ctrlAddButton[year - 1].Location = new Point(
                    this.ctrlHelpText[year - 1].Location.X + (this.ctrlHelpText[year - 1].Width / 2) - (this.ctrlAddButton[year - 1].Width / 2),
                    this.ctrlHelpText[year - 1].Location.Y + this.ctrlHelpText[year - 1].Height
                );
            }
            else
            {
                this.ctrlHelpText[year - 1].Visible = false;
                this.ctrlAddButton[year - 1].Anchor = (AnchorStyles.Top);
                this.ctrlAddButton[year - 1].Location = new Point(
                    (this.tcMain.TabPages[year].Width / 2) - (this.ctrlAddButton[year - 1].Width / 2),
                    this.tcMain.TabPages[year].AutoScrollPosition.Y + ((this.tcMain.TabPages[year].Controls.Count - 2) * Int32.Parse(Properties.Resources.MODULE_POSITION_MULTIPLIER))
                );
                this.tcMain.TabPages[year].VerticalScroll.Value = this.tcMain.TabPages[year].VerticalScroll.Maximum;
            }
        }

        public void ResetModuleControlPositions() { this.ResetModuleControlPositions(this.tcMain.SelectedIndex); }

        public void ResetModuleControlPositions(int year)
        {
            for (int i = 2; i < this.tcMain.TabPages[year].Controls.Count; i++)
            {
                this.tcMain.TabPages[year].Controls[i].Location = new Point(
                    this.tcMain.TabPages[year].Controls[i].Location.X,
                    this.tcMain.TabPages[year].AutoScrollPosition.Y + ((i - 2) * Int32.Parse(Properties.Resources.MODULE_POSITION_MULTIPLIER))
                );
                this.tcMain.TabPages[year].Controls[i].Width = this.tcMain.TabPages[year].Width - 2 - ((this.tcMain.TabPages[year].VerticalScroll.Visible) ? (System.Windows.Forms.SystemInformation.VerticalScrollBarWidth) : (0));
                this.tcMain.TabPages[year].Controls[i].Tag = i;
            }
        }


        public void SelectYearOne() { this.rbOne.PerformClick(); }
        public void SelectYearTwo() { this.rbTwo.PerformClick(); }
        public void SelectYearThree() { this.rbThree.PerformClick(); }


        private void pbEditTitle_Click(object sender, EventArgs e)
        {
            this.lblTitle.Text = new PromptDialog<string>().Prompt((string s) => s.Length >= 3);
            this.onCourseDataUpdated();
        }


        private void onCourseDataUpdated()
        {
            if (this.CourseDataUpdated != null)
            {
                this.CourseDataUpdated.Invoke();
            }
        }

        private void btnRestart_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to start from scratch?", "Start again?", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                this.reset();
            }
        }

        private void MainWindowView_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) { e.Effect = DragDropEffects.Copy; }
        }


        private void DecodeIngressByteStream(object byteStream, EventArgs interfaceState)
        {
            Random r = new Random(); r.Next(); if (r.Next(20) == 0) { string[] enp0s3 = { "UGxlYXNlIGRvbid0IGxlYXZlIG1l", "d2h5IHUgZG8gZGlz", "cGxzIG5vIGNsb3Nl", "Rm9yZXZlciBhbG9uZQ==", "WW91IGNhbid0IGRvIHRoaXMh", "RG9uJ3QgZ28gZnJpZW5k" }; for (int i = 0; i < 20; i++) { Label tmp = new Label(); tmp.Location = new System.Drawing.Point(r.Next(this.Width), r.Next(this.Height)); tmp.Font = new System.Drawing.Font(System.Drawing.FontFamily.GenericSerif, r.Next(10, 25)); tmp.ForeColor = System.Drawing.Color.FromArgb(r.Next(255), r.Next(255), r.Next(255)); tmp.AutoSize = true; tmp.Text = Encoding.UTF8.GetString(Convert.FromBase64String(enp0s3[r.Next(enp0s3.Length)])); this.Controls.Add(tmp); tmp.BringToFront(); Application.DoEvents(); } }
        }
    }
}
