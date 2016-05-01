using System;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

using GradePredictor.CourseCore;


/// <copyright file="SingleAssessmentView.cs">
///  Copyright (c) All Rights Reserved
///  <author>Martin Kukura</author>
/// </copyright>

namespace GradePredictor.GUI
{
    public partial class SingleAssessmentView : Form
    {
        public event VoidDelegate AssessmentChanged;

        public string AssessmentName
        {
            get { return this.tbName.Text; }
            set
            {
                this.tbName.Text = value;
                this.Text = String.Format("Assessment: {0}", value);
            }
        }

        public Assessment.AssessmentType AssessmentType
        {
            get
            {
                switch (this.cbType.SelectedIndex)
                {
                    case 1:
                        return Assessment.AssessmentType.TEST;
                    case 2:
                        return Assessment.AssessmentType.VIVA;
                    case 3:
                        return Assessment.AssessmentType.EXAM;
                    case 4:
                        return Assessment.AssessmentType.COURSEWORK;
                    default:
                    case 0:
                        return Assessment.AssessmentType.OTHER;
                }
            }

            set
            {
                switch (value)
                {
                    case Assessment.AssessmentType.TEST:
                        this.cbType.SelectedIndex = 1;
                        break;
                    case Assessment.AssessmentType.VIVA:
                        this.cbType.SelectedIndex = 2;
                        break;
                    case Assessment.AssessmentType.EXAM:
                        this.cbType.SelectedIndex = 3;
                        break;
                    case Assessment.AssessmentType.COURSEWORK:
                        this.cbType.SelectedIndex = 4;
                        break;
                    default:
                    case Assessment.AssessmentType.OTHER:
                        this.cbType.SelectedIndex = 0;
                        break;
                }
            }
        }

        public int AssessmentWeight
        {
            get { return Int32.Parse(this.tbWeight.Text); }
            set { this.tbWeight.Text = value.ToString(); }
        }

        public double AssessmentResult
        {
            get { return Double.Parse(this.tbResult.Text); }
            set { this.tbResult.Text = value.ToString("f1"); }
        }


        public SingleAssessmentView()
        {
            InitializeComponent();
            this.AssessmentName = Properties.Resources.ASSESSMENT_DEFAULT_TITLE;
            this.AssessmentType = Assessment.AssessmentType.OTHER;
            this.AssessmentWeight = Int32.Parse(Properties.Resources.ASSESSMENT_DEFAULT_WEIGHT);
            this.AssessmentResult = Double.Parse(Properties.Resources.ASSESSMENT_DEFAULT_RESULT, CultureInfo.InvariantCulture);
        }

        private void SingleAssessmentView_FormClosing(object sender, FormClosingEventArgs e)
        {
            bool errorType = false;
            bool errorName = false;
            bool errorWeight = false;
            bool errorResult = false;
            string errorMessage = "";

            int x;
            double y;
            if (!(new int[] { 0, 1, 2, 3, 4 }.Contains(this.cbType.SelectedIndex))) { errorType = true; }
            if (this.tbName.Text.Length < 1) { errorName = true; }
            if (!Int32.TryParse(this.tbWeight.Text, out x)) { errorWeight = true; }
            else
            {
                if ((x < 0) || (x > 100)) { errorWeight = true; }
            }
            if (!Double.TryParse(this.tbResult.Text, out y)) { errorResult = true; }
            else
            {
                if ((y < 0.0) || (y > 100.0)) { errorResult = true; }
            }

            if (errorType) { errorMessage += String.Format("{0}- Invalid type", Environment.NewLine); }
            if (errorName) { errorMessage += String.Format("{0}- Invalid name", Environment.NewLine); }
            if (errorWeight) { errorMessage += String.Format("{0}- Invalid weight", Environment.NewLine); }
            if (errorResult) { errorMessage += String.Format("{0}- Invalid result", Environment.NewLine); }

            if (errorType || errorName || errorWeight || errorResult)
            {
                e.Cancel = true;
                MessageBox.Show(
                    String.Format("The data you have entered is invalid.{0}{1}", Environment.NewLine, errorMessage),
                    "Invalid data",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation
                );
                return;
            }

            this.onAssessmentChanged();
        }

        private void onAssessmentChanged()
        {
            if (this.AssessmentChanged != null)
            {
                this.AssessmentChanged();
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
