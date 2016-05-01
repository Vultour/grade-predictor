using System;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;

using GradePredictor.CourseUtil;


/// <copyright file="Module.cs">
///  Copyright (c) All Rights Reserved
///  <author>Martin Kukura</author>
/// </copyright>

namespace GradePredictor.CourseCore
{
    public class Module : CourseObjectBase
    {
        private List<Assessment> assessments;
        private int credits;
        private double result;
        private string code;

        public string Title { get; set; }

        public string Code
        {
            get { return this.code; }
            set { this.code = value.ToUpper(); }
        }

        public int Credits
        {
            get { return this.credits; }
            set { this.credits = (((value < 1) || (value > 120)) ? (0) : (value)); }
        }

        public double Result
        {
            get { return this.result; }
            set {
                this.result = (((value < 0) && (value > 100)) ? (-1) : (value));
                this.onChange(true);
            }
        }

        public bool IsUsable { get { return ((this.Credits > 0) && (this.Result != Course.VALUE_NOT_AVAILABLE)); } }

        public bool NeedsRetake { get { return ((this.IsUsable) && (this.Result < 30)); } }


        public List<Assessment> Assessments
        {
            get
            {
                return this.assessments;
            }
        }


        public Module(CourseObjectChangedHandler callbackChanged): this(Properties.Resources.MODULE_DEFAULT_TITLE, Properties.Resources.MODULE_DEFAULT_CODE, Int32.Parse(Properties.Resources.MODULE_DEFAULT_CREDITS), callbackChanged) { }

        public Module(string title, string code, int credits, CourseObjectChangedHandler callbackChanged)
        {
            this.Title = title;
            this.Code = code;
            this.credits = credits;
            this.result = Course.VALUE_NOT_AVAILABLE;
            this.assessments = new List<Assessment>();
            this.Change += callbackChanged;
        }

        public override void Detach()
        {
            this.emitWarning(CourseWarnings.EmitReset());
        }


        protected override void recalculateResult()
        {
            IEnumerable<Assessment> selection = this.assessments.Where((Assessment a) => a.IsUsable);
            if (selection.Count() < 1)
            {
                this.result = Course.VALUE_NOT_AVAILABLE;
                return;
            }

            this.Result = CourseCalculationHelper.WeightedResult(
                selection.Select((Assessment a) => new Tuple<double, double>(a.Result, a.Weight)).ToList()
            ).Item2;
        }


        public void AddAssessment()
        {
            this.AddAssessment(
                Properties.Resources.ASSESSMENT_DEFAULT_TITLE,
                (Assessment.AssessmentType)Enum.Parse(typeof(Assessment.AssessmentType), Properties.Resources.ASSESSMENT_DEFAULT_TYPE),
                Int32.Parse(Properties.Resources.ASSESSMENT_DEFAULT_WEIGHT),
                Double.Parse(Properties.Resources.ASSESSMENT_DEFAULT_RESULT, CultureInfo.InvariantCulture)
            );
        }

        public void AddAssessment(string title, Assessment.AssessmentType type, int weight, double result)
        {
            Assessment tmp = new Assessment(title, type, weight, result, this.childChangedHandler);
            tmp._WarningEmitted += this.warningEmittedHandler;
            tmp.TriggerChange(false);
            this.assessments.Add(tmp);
            if (weight != 0) { this.childChangedHandler(null, true); }
        }

        public void EditModule(string title, string code, int credits)
        {
            bool change = false;
            bool recalc = false;
            if (this.Title != title)
            {
                this.Title = title;
                change = true;
            }
            if (this.Code != code)
            {
                this.Code = code;
                change = true;
            }
            if (this.Credits != credits)
            {
                this.Credits = credits;
                change = true;
                recalc = true;
            }

            if (change) { this.onChange(recalc); }
        }


        public void RemoveAssessment(int index)
        {
            this.Assessments[index].Detach();
            this.Assessments.RemoveAt(index);
            this.childChangedHandler(null, true);
        }
        public void RemoveAssessment(Assessment a)
        {
            a.Detach();
            this.Assessments.Remove(a);
            this.childChangedHandler(null, true);
        }


        protected override void checkValues()
        {
            if (this.Assessments.Where((Assessment a) => ((a.Weight > 0) && (a.Result >= 0))).Count() < 1) { this.emitWarning(CourseWarnings.EmitModuleNoAssessments(this.getRef())); }
            else { this.emitWarning(CourseWarnings.EmitModuleNoAssessments(this.getRef(), true)); }

            if (this.Credits == 0) { this.emitWarning(CourseWarnings.EmitModuleNoCreditValue(this.getRef())); }
            else { this.emitWarning(CourseWarnings.EmitModuleNoCreditValue(this.getRef(), true)); }

            if (this.Credits == Course.VALUE_NOT_AVAILABLE) { this.emitWarning(CourseWarnings.EmitModuleInvalidCreditValue(this.getRef())); }
            else { this.emitWarning(CourseWarnings.EmitModuleInvalidCreditValue(this.getRef(), true)); }

            if (this.Result == Course.VALUE_NOT_AVAILABLE) { this.emitWarning(CourseWarnings.EmitModuleInvalidResultValue(this.getRef())); }
            else { this.emitWarning(CourseWarnings.EmitModuleInvalidResultValue(this.getRef(), true)); }

            if ((this.Credits % Int32.Parse(Properties.Resources.MODULE_STANDARD_CREDIT_VALUE)) != 0) { this.emitWarning(CourseWarnings.EmitModuleNonStandardCreditValue(this.getRef())); }
            else { this.emitWarning(CourseWarnings.EmitModuleNonStandardCreditValue(this.getRef(), true)); }
        }

        protected override string getRef()
        {
            return String.Format("Module: {0}", this.Title);
        }
    }
}
