using GradePredictor.CourseCore;


/// <copyright file="SingleAssessmentController.cs">
///  Copyright (c) All Rights Reserved
///  <author>Martin Kukura</author>
/// </copyright>

namespace GradePredictor.GUI
{
    class SingleAssessmentController
    {
        private SingleAssessmentView view;
        private Assessment assessment;

        public Assessment Assessment { set { this.assessment = value; } }

        public SingleAssessmentController()
        {
            this.view = new SingleAssessmentView();
            this.view.AssessmentChanged += this.assessmentChangedHandler;
        }

        public void populateAndShow()
        {
            this.view.AssessmentName = this.assessment.Title;
            this.view.AssessmentType = this.assessment.Type;
            this.view.AssessmentWeight = this.assessment.Weight;
            this.view.AssessmentResult = this.assessment.Result;
            this.view.ShowDialog();
        }


        public void assessmentChangedHandler()
        {
            this.assessment.changeAssessment(
                this.view.AssessmentType,
                this.view.AssessmentWeight,
                this.view.AssessmentResult,
                this.view.AssessmentName
            );
        }
    }
}
