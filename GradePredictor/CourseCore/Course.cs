using System;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using System.Timers;

using GradePredictor.CourseUtil;
using GradePredictor.Util;


/// <copyright file="Course.cs">
///  Copyright (c) All Rights Reserved
///  <author>Martin Kukura</author>
/// </copyright>

namespace GradePredictor.CourseCore
{
    public class Course : CourseObjectBase, IDeepCloneable<Course>
    {
        public const int VALUE_NOT_AVAILABLE = -1;
        public enum Degree
        {
            FirstClass,
            UpperSecondClass,
            SecondClass,
            ThirdClass,
            Fail,
            Unknown
        }

        public event VoidDelegate WarningEmitted;

        private Year[] years;
        private string title;
        private Course.Degree result;
        private CourseWarnings warnings;
        private Timer saveTimer;

        public string Title {
            get { return this.title; }
            set {
                this.title = value;
                this.onChange(false);
            }
        }

        public Year[] Years { get { return this.years; } }

        public Degree Result {
            get { return this.result; }
            private set
            {
                this.result = value;
                this.onChange(true);
            }
        }

        public List<CourseWarning> Warnings { get { return this.warnings.GetWarnings(); } }


        public Course() : this(true) { }
        public Course(bool createTimer)
        {
            this.years = new Year[3];
            for (int i = 0; i < 3; i++) {
                this.years[i] = new Year(i + 1);
                this.years[i].Change += this.childChangedHandler;
                this.years[i]._WarningEmitted += this.warningEmittedHandler;
                this.years[i].TriggerCalculation();
            }

            this.title = Properties.Resources.COURSE_DEFAULT_TITLE;
            this.Result = Course.Degree.Unknown;

            this.warnings = new CourseWarnings();
            this.warnings.WarningsChanged += this.warningsChangedHandler;
            this._WarningEmitted += this.handleWarningChain;

            if (createTimer)
            {
                this.saveTimer = new Timer(Double.Parse(Properties.Resources.COURSE_SAVE_INTERVAL, CultureInfo.InvariantCulture));
                this.saveTimer.AutoReset = true;
                this.saveTimer.Elapsed += (object sender, ElapsedEventArgs e) =>
                {
                    ConcurrentWorkQueue.Enqueue(() =>
                    {
                        new CourseXMLBackend(this.DeepClone()).SetPath(Properties.Resources.SAVE_FILE_PATH).Save();
                    });
                };
                this.saveTimer.Start();
            }
        }

        public override void Detach()
        {
            this.emitWarning(CourseWarnings.EmitReset());
            this.saveTimer.Stop();
        }


        protected override void recalculateResult()
        {
            if (!this.years[0].IsUsable && !this.years[1].IsUsable && !this.years[2].IsUsable) {
                this.emitWarning(CourseWarnings.EmitCourseInsufficientData(this.getRef()));
                this.Result = Course.Degree.Unknown;
                return;
            }

            if (this.years[2].NeedsRetake)
            {
                this.Result = Course.Degree.Fail;
                this.emitWarning(CourseWarnings.EmitCourseRetakeSixFailure(this.getRef()));
                return;
            }
            else { this.emitWarning(CourseWarnings.EmitCourseRetakeSixFailure(this.getRef(), true)); }

            if (Boolean.Parse(Properties.Resources.X_FAIL_ON_RETAKE))
            {
                if (this.years[0].NeedsRetake || this.years[1].NeedsRetake)
                {
                    this.Result = Course.Degree.Fail;
                    this.emitWarning(CourseWarnings.EmitCourseRetakeFailure(this.getRef()));
                    return;
                }
                else { this.emitWarning(CourseWarnings.EmitCourseRetakeFailure(this.getRef(), true)); }
            }

            if (Boolean.Parse(Properties.Resources.X_FAIL_ON_REF))
            {
                if (this.years[0].NeedsReferral || this.years[1].NeedsReferral || this.years[2].NeedsReferral)
                {
                    this.Result = Course.Degree.Fail;
                    this.emitWarning(CourseWarnings.EmitCourseReferralFailure(this.getRef()));
                    return;
                }
                else { this.emitWarning(CourseWarnings.EmitCourseReferralFailure(this.getRef(), true)); }
            }

            List<Tuple<double, double>> yearOne = this.years[0].UsableModules;
            List<Tuple<double, double>> yearTwo = this.years[1].UsableModules;
            List<Tuple<double, double>> yearThree = this.years[2].UsableModules;

            if (!this.years[1].IsUsable || !this.years[2].IsUsable)
            {
                if (Boolean.Parse(Properties.Resources.X_STOP_ON_MISSING))
                {
                    this.Result = Course.Degree.Unknown;
                    this.emitWarning(CourseWarnings.EmitCourseInsufficientData(this.getRef()));
                    return;
                }

                CourseCalculationHelper.InterpolateYearResult(yearOne, yearTwo, yearThree);
                this.emitWarning(CourseWarnings.EmitCourseInterpolated(this.getRef()));
            }
            else { this.emitWarning(CourseWarnings.EmitCourseInterpolated(this.getRef(), true)); }

            this.emitWarning(CourseWarnings.EmitCourseInsufficientData(this.getRef(), true));
            this.Result = CourseCalculationHelper.Degree(yearTwo, yearThree);
        }


        private void handleWarningChain(Guid g, CourseWarning w)
        {
            this.warnings.SetWarning(g, w);
        }

        private void warningsChangedHandler()
        {
            if (this.WarningEmitted != null)
            {
                this.WarningEmitted.Invoke();
            }
        }


        protected override void checkValues()
        {
            if (this.Result == Course.Degree.Unknown) { this.emitWarning(CourseWarnings.EmitCourseResultUnavailable(this.getRef())); }
            else { this.emitWarning(CourseWarnings.EmitCourseResultUnavailable(this.getRef(), true)); }
        }

        protected override string getRef()
        {
            return String.Format("Course: {0}", this.Title);
        }


        public Course DeepClone()
        {
            Course c = new Course(false);
            c.Title = this.title;
            foreach (Year y in this.Years)
            {
                foreach (Module m in y.Modules)
                {
                    c.Years[y.Number - 1].CreateModule(m.Title, m.Code, m.Credits);
                    foreach (Assessment a in m.Assessments)
                    {
                        c.Years[y.Number - 1].Modules.Last().AddAssessment(a.Title, a.Type, a.Weight, a.Result);
                    }
                }
            }

            return c;
        }
    }
}
