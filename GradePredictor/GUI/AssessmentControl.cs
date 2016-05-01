using System.Windows.Forms;

using GradePredictor.CourseCore;
using GradePredictor.CourseUtil;


/// <copyright file="AssessmentControl.cs">
///  Copyright (c) All Rights Reserved
///  <author>Martin Kukura</author>
/// </copyright>

namespace GradePredictor.GUI
{
    public partial class AssessmentControl : UserControl
    {
        private Assessment assessment;

        public Assessment Assessment { get { return this.assessment; } }
        public string AssessmentName
        {
            set { this.lblName.Text = value; }
        }

        public Assessment.AssessmentType AssessmentType
        {
            set
            {
                switch (value)
                {
                    case Assessment.AssessmentType.COURSEWORK:
                        this.lblType.Text = "<CW>";
                        break;
                    case Assessment.AssessmentType.EXAM:
                        this.lblType.Text = "<EXAM>";
                        break;
                    case Assessment.AssessmentType.VIVA:
                        this.lblType.Text = "<VIVA>";
                        break;
                    case Assessment.AssessmentType.TEST:
                        this.lblType.Text = "<TEST>";
                        break;
                    case Assessment.AssessmentType.OTHER:
                        this.lblType.Text = "<OTHER>";
                        break;
                    default:
                        this.lblType.Text = "<ERR>";
                        break;
                }
            }
        }

        public int AssessmentWeight
        {
            set { this.lblWeight.Text = value.ToString() + "%"; }
        }

        public double AssessmentResult
        {
            set { this.lblResult.Text = value.ToString("f1") + "%"; }
        }


        public AssessmentControl(Assessment assessment)
        {
            InitializeComponent();

            this.assessment = assessment;
            this.assessment.Change += this.assessmentChangedHandler;

            this.AssessmentType = this.assessment.Type;
            this.AssessmentName = this.assessment.Title;
            this.AssessmentWeight = this.assessment.Weight;
            this.AssessmentResult = this.assessment.Result;
        }

        public void hookFaceClick(System.EventHandler callback)
        {
            this.Click += callback;
            this.pnlData.Click += callback;
            this.lblName.Click += callback;
            this.lblResult.Click += callback;
            this.lblResultTitle.Click += callback;
            this.lblType.Click += callback;
            this.lblWeight.Click += callback;
            this.lblWeightTitle.Click += callback;
        }

        public void hookRemoveClick(System.EventHandler callback)
        {
            this.btnRemove.Click += callback;
        }


        public void assessmentChangedHandler(object sender, bool triggerRecalc)
        {
            if (!(sender is Assessment)) { throw new InvalidCourseObjectException(); }
            Assessment assessment = (Assessment)sender;
            this.AssessmentType = assessment.Type;
            this.AssessmentName = assessment.Title;
            this.AssessmentWeight = assessment.Weight;
            this.AssessmentResult = assessment.Result;
        }
    }
}
