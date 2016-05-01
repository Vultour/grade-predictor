using System;
using System.Drawing;
using System.Windows.Forms;

using GradePredictor.CourseCore;
using GradePredictor.CourseUtil;
using GradePredictor.Util;


/// <copyright file="SingleModuleView.cs">
///  Copyright (c) All Rights Reserved
///  <author>Martin Kukura</author>
/// </copyright>

namespace GradePredictor.GUI
{
    public partial class SingleModuleView : Form
    {
        public event VoidDelegate ModuleDataUpdated;

        private Panel loader;

        public string ModuleName
        {
            get { return this.lblName.Text; }
            set {
                this.lblName.Text = value;
                this.Text = "Module: " + value;
            }
        }

        public string ModuleCode
        {
            get { return this.lblCode.Text.Replace("[", "").Replace("]", ""); }
            set { this.lblCode.Text = "[" + value.ToUpper() + "]"; }
        }

        public int ModuleCredits
        {
            get { return Int32.Parse(this.lblCredits.Text); }
            set {
                if (value < 0) { value = 0; }
                this.lblCredits.Text = value.ToString();
            }
        }

        public double ModuleResult
        {
            set
            {
                if ((value < 0) || (value > 100))
                {
                    this.lblResult.Text = "--%";
                    this.lblResultText.Text = "Unknown";
                    this.lblResultText.ForeColor = CourseColor.Unknown;
                }
                else
                {
                    this.lblResult.Text = value.ToString("f1") + "%";
                    if (value >= 40)
                    {
                        this.lblResultText.ForeColor = CourseColor.GetColor(value);
                        this.lblResultText.Text = "PASS";
                    }
                    else if (value >= 30)
                    {
                        this.lblResultText.ForeColor = CourseColor.Retake;
                        this.lblResultText.Text = "REF";
                    }
                    else
                    {
                        this.lblResultText.ForeColor = CourseColor.Fail;
                        this.lblResultText.Text = "FAIL";
                    }
                }
            }
        }


        public SingleModuleView()
        {
            InitializeComponent();
        }

        public SingleModuleView(System.EventHandler callbackNew)
        {
            InitializeComponent();

            this.loader = new Panel();
            this.loader.Visible = false;
            this.loader.BackColor = this.BackColor;
            this.loader.Location = this.pnlAssessments.Location;
            this.loader.Size = this.pnlAssessments.Size;
            this.Controls.Add(this.loader);
            ProgressBar tmp = new ProgressBar();
            this.loader.Controls.Add(tmp);
            tmp.Center(loader);
            tmp.Style = ProgressBarStyle.Marquee;
            tmp.MarqueeAnimationSpeed = 25;
            this.loader.BringToFront();

            this.btnAdd.Click += callbackNew;
        }


        public void BeginLoading() { this.loader.Visible = true; }

        public void EndLoading() { this.loader.Visible = false; }


        public void reset()
        {
            this.ModuleName = Properties.Resources.MODULE_DEFAULT_TITLE;
            this.ModuleCode = Properties.Resources.MODULE_DEFAULT_CODE;
            for (int i = this.pnlAssessments.Controls.Count - 1; i > 1; i--) {
                AssessmentControl tmp = (AssessmentControl)this.pnlAssessments.Controls[i];
                this.pnlAssessments.Controls.RemoveAt(i);
                tmp.Dispose();
            }
            this.restoreHelp();
        }

        public void restoreHelp()
        {
            this.lblHelp.Visible = true;
            this.btnAdd.Anchor = (AnchorStyles.None);
            this.btnAdd.Location = new Point(
                (this.lblHelp.Location.X + (this.lblHelp.Width / 2)) - (this.btnAdd.Width / 2),
                (this.lblHelp.Location.Y + this.lblHelp.Height) + 5
            );
        }


        public void createAssessment(System.EventHandler callbackOpen, System.EventHandler callbackRemove, Assessment a)
        {
            AssessmentControl tmp = new AssessmentControl(a);
            tmp.Anchor = (AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top);
            //tmp.Width = this.pnlAssessments.Width - 2;// - ((/*this.pnlAssessments.VerticalScroll.Visible*/true) ? (System.Windows.Forms.SystemInformation.VerticalScrollBarWidth) : (0));
            //tmp.Location = new Point(0, this.pnlAssessments.AutoScrollPosition.Y + ((this.pnlAssessments.Controls.Count - 2) * 55));
            //tmp.Margin = new Padding(0, 10, 0, 10);
            tmp.hookFaceClick(callbackOpen);
            tmp.hookRemoveClick(callbackRemove);

            this.pnlAssessments.Controls.Add(tmp);
            this.resetAssessmentControlPositions();
            this.updateControls();
        }

        public void editAssessment(int index, Assessment assessment)
        {
            ((AssessmentControl)this.pnlAssessments.Controls[index + 2]).AssessmentType = assessment.Type;
            ((AssessmentControl)this.pnlAssessments.Controls[index + 2]).AssessmentName = assessment.Title;
            ((AssessmentControl)this.pnlAssessments.Controls[index + 2]).AssessmentWeight = assessment.Weight;
            ((AssessmentControl)this.pnlAssessments.Controls[index + 2]).AssessmentResult = assessment.Result;
        }

        public void removeAssessment(AssessmentControl assessment)
        {
            this.pnlAssessments.Controls.Remove(assessment);
            assessment.Dispose();
            this.resetAssessmentControlPositions();
            this.updateControls();
        }

        public void resetAssessmentControlPositions()
        {
            for (int i = 2; i < this.pnlAssessments.Controls.Count; i++)
            {
                this.pnlAssessments.Controls[i].Location = new Point(
                    this.pnlAssessments.Controls[i].Location.X,
                    this.pnlAssessments.AutoScrollPosition.Y + ((i - 2) * Int32.Parse(Properties.Resources.ASSESSMENT_POSITION_MULTIPLIER))
                );
                this.pnlAssessments.Controls[i].Width = this.pnlAssessments.Width - 2 - ((this.pnlAssessments.VerticalScroll.Visible) ? (System.Windows.Forms.SystemInformation.VerticalScrollBarWidth) : (0));
                this.pnlAssessments.Controls[i].Tag = (i - 2);
            }
            this.btnAdd.Location = new Point(this.btnAdd.Location.X, this.pnlAssessments.AutoScrollPosition.Y + ((this.pnlAssessments.Controls.Count - 2) * Int32.Parse(Properties.Resources.ASSESSMENT_POSITION_MULTIPLIER)));
        }

        public void updateControls()
        {
            if (this.pnlAssessments.Controls.Count < 3)
            {
                this.lblHelp.Visible = true;
                this.btnAdd.Anchor = (AnchorStyles.None);
                this.btnAdd.Location = new Point(
                    (this.lblHelp.Location.X + (this.lblHelp.Width / 2)) - (this.btnAdd.Width / 2),
                    (this.lblHelp.Location.Y + this.lblHelp.Height)
                );
            }
            else
            {
                this.lblHelp.Visible = false;
                this.btnAdd.Anchor = (AnchorStyles.Top);
                this.btnAdd.Location = new Point(
                    (this.pnlAssessments.Width / 2 - this.btnAdd.Width / 2),
                    this.pnlAssessments.AutoScrollPosition.Y + ((this.pnlAssessments.Controls.Count - 2) * Int32.Parse(Properties.Resources.ASSESSMENT_POSITION_MULTIPLIER))
                );
                this.pnlAssessments.VerticalScroll.Value = this.pnlAssessments.VerticalScroll.Maximum;
            }
        }

        public void beginPopulation() { this.pnlAssessments.SuspendLayout(); }

        public void endPopulation() { this.pnlAssessments.ResumeLayout(); }

        public void textEditButtonClickHandler(object sender, EventArgs e)
        {
            PictureBox p = (PictureBox)sender;
            switch (p.Name)
            {
                case "pbName":
                    this.ModuleName = new PromptDialog<string>().SetCaption("Module name").Prompt((string x) => x.Length >= 3);
                    break;
                case "pbCode":
                    this.ModuleCode = new PromptDialog<string>().SetCaption("Module code").Prompt((string x) => x.Length > 0);
                    break;
                case "pbCredits":
                    this.ModuleCredits = new PromptDialog<int>().SetCaption("Module credits").Prompt((int x) => ((x >= 0) && (x < 1000)));
                    break;
            }
            this.onModuleDataUpdated();
        }


        private void onModuleDataUpdated()
        {
            if (this.ModuleDataUpdated != null)
            {
                this.ModuleDataUpdated();
            }
        }
    }
}
