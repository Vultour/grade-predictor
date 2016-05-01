using System;
using System.Collections.Generic;
using System.Linq;

using GradePredictor.CourseUtil;


/// <copyright file="Year.cs">
///  Copyright (c) All Rights Reserved
///  <author>Martin Kukura</author>
/// </copyright>

namespace GradePredictor.CourseCore
{
    public class Year : CourseObjectBase
    {
        private List<Module> modules;
        private double result;
        private int number;

        public List<Module> Modules
        {
            get { return this.modules; }
        }

        private IEnumerable<Module> UsableModulesRaw
        {
            get { return this.modules.Where((Module m) => m.IsUsable); }
        }

        public List<Tuple<double, double>> UsableModules
        {
            get { return this.UsableModulesRaw.Select((Module m) => new Tuple<double, double>(m.Result, m.Credits)).ToList(); }
        }

        public int Number { get { return this.number; } }

        public double Result {
            get { return this.result; }
            set { this.result = (((value < 0) || (value > 100)) ? (Course.VALUE_NOT_AVAILABLE) : (value)); }
        }

        public bool IsUsable { get { return (this.Result != Course.VALUE_NOT_AVAILABLE); } }

        public bool NeedsRetake { get { return (this.UsableModulesRaw.Where((Module m) => (m.NeedsRetake)).Count() > 0); } } // NOTE: Can be optimized into single query

        public bool NeedsReferral { get { return (this.UsableModulesRaw.Where((Module m) => ((m.Result < 40) && (m.Result >= 30))).Count() > 0); } } // NOTE: Can be optimized into single query

        public Year(int n)
        {
            this.modules = new List<Module>();
            this.result = Course.VALUE_NOT_AVAILABLE;
            this.number = n;
        }

        public override void Detach()
        {
            this.emitWarning(CourseWarnings.EmitReset());
        }


        protected override void recalculateResult()
        {
            List<Tuple<double, double>> selection = this.UsableModules;

            if (selection.Count < 1) {
                this.emitWarning(CourseWarnings.EmitYearNoUsableModules(this.getRef()));
                this.Result = Course.VALUE_NOT_AVAILABLE;
            }
            else
            {
                this.emitWarning(CourseWarnings.EmitYearNoUsableModules(this.getRef(), true));
                this.Result = CourseCalculationHelper.WeightReplicatedValues(15, selection).Item2.Average((Tuple<double, double> i) => i.Item1);
            }

            this.onChange(true);
        }


        public void CreateModule()
        {
            this.CreateModule(Properties.Resources.MODULE_DEFAULT_TITLE, Properties.Resources.MODULE_DEFAULT_CODE, Int32.Parse(Properties.Resources.MODULE_DEFAULT_CREDITS));
        }

        public void CreateModule(string title, string code, int credits)
        {
            Module tmp = new Module(title, code, credits, this.childChangedHandler);
            tmp._WarningEmitted += this.warningEmittedHandler;
            tmp.TriggerChange(false);
            this.modules.Add(tmp);
        }


        public void RemoveModule(int index)
        {
            this.modules[index].Detach();
            this.modules.RemoveAt(index);
            this.onChange(true);
        }

        public void RemoveModule(Module m)
        {
            m.Detach();
            this.modules.Remove(m);
            this.onChange(true);
        }


        protected override void checkValues()
        {
            if (this.Result == Course.VALUE_NOT_AVAILABLE) { this.emitWarning(CourseWarnings.EmitYearResultUnavailable(this.getRef())); }
            else { this.emitWarning(CourseWarnings.EmitYearResultUnavailable(this.getRef(), true)); }
        }

        protected override string getRef()
        {
            return String.Format("Year: {0}", this.Number);
        }
    }
}
