using System;
using System.Globalization;

using GradePredictor.CourseUtil;


/// <copyright file="Assessment.cs">
///  Copyright (c) All Rights Reserved
///  <author>Martin Kukura</author>
/// </copyright>

namespace GradePredictor.CourseCore
{
    public class Assessment : CourseObjectBase
    {
        public enum AssessmentType { OTHER, COURSEWORK, TEST, EXAM, VIVA };

        private AssessmentType type;
        private int weight;
        private double result;
        private string title;

        public string Title
        {
            get { return this.title; }
        }

        public AssessmentType Type
        {
            get { return this.type; }
        }

        public int Weight
        {
            get { return this.weight; }
        }

        public double Result
        {
            get { return this.result; }
        }

        public bool IsUsable
        {
            get { return (this.Weight != 0); }
        }


        public Assessment() : this(Properties.Resources.ASSESSMENT_DEFAULT_TITLE, (Assessment.AssessmentType)Enum.Parse(typeof(Assessment.AssessmentType), Properties.Resources.ASSESSMENT_DEFAULT_TYPE), Int32.Parse(Properties.Resources.ASSESSMENT_DEFAULT_WEIGHT), Double.Parse(Properties.Resources.ASSESSMENT_DEFAULT_RESULT, CultureInfo.InvariantCulture), null) { }

        public Assessment(string title, AssessmentType type, int weight, double result, CourseObjectChangedHandler callbackChanged)
        {
            this.title = title;
            this.type = type;
            this.weight = (((weight >= 0) && (weight <= 100)) ? (weight) : (0));
            this.result = (((result >= 0) && (result <= 100)) ? (result) : (0));
            this.Change += callbackChanged;
        }

        public Assessment(CourseObjectChangedHandler callback): this()
        {
            this.Change += callback;
        }

        public override void Detach()
        {
            this.emitWarning(CourseWarnings.EmitReset());
        }


        public void changeAssessment(AssessmentType type, int weight, double result, string title)
        {
            bool change = false;
            bool recalculationNeeded = false;

            if ((weight < 0) || (weight > 100)) { weight = 0; }
            if ((result < 0) || (result > 100)) { result = -1; }

            if (this.type != type)
            {
                this.type = type;
                change = true;
            }
            if (this.title != title)
            {
                this.title = title;
                change = true;
            }
            if (this.weight != weight)
            {
                this.weight = weight;
                change = true;
                recalculationNeeded = true;
            }
            if (this.result != result)
            {
                this.result = result;
                change = true;
                recalculationNeeded = true;
            }

            if (change) { this.onChange(recalculationNeeded); }
        }


        protected override void recalculateResult() { /* dummy */ }

        protected override void checkValues()
        {
            if (this.Weight == 0) { this.emitWarning(CourseWarnings.EmitAssessmentNoWeightValue(this.getRef())); }
            else { this.emitWarning(CourseWarnings.EmitAssessmentNoWeightValue(this.getRef(), true)); }

            if (this.Result == Course.VALUE_NOT_AVAILABLE) { this.emitWarning(CourseWarnings.EmitAssessmentInvalidResultValue(this.getRef())); }
            else { this.emitWarning(CourseWarnings.EmitAssessmentInvalidResultValue(this.getRef(), true)); }
        }

        protected override string getRef()
        {
            return String.Format("Assessment: {0}", this.Title);
        }
    }
}
