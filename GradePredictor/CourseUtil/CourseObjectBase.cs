using System;

using GradePredictor.CourseCore;
using GradePredictor.Util;


/// <copyright file="CourseObjectBase.cs">
///  Copyright (c) All Rights Reserved
///  <author>Martin Kukura</author>
/// </copyright>

namespace GradePredictor.CourseUtil
{
    /// <summary>
    /// Provides signalling, change propagation and unique identification for course objects.
    /// </summary>
    public abstract class CourseObjectBase : UniquelyIdentifiableObject
    {
        protected object _lock;
        public CourseObjectBase() { this._lock = new object(); }

        public delegate void CourseObjectChangedHandler(CourseObjectBase sender, bool triggerRecalculation);
        public event CourseObjectChangedHandler Change;
        protected virtual void onChange(bool triggerRecalculation)
        {
            this.checkValues();
            if (this.Change != null)
            {
                this.Change.Invoke(this, triggerRecalculation);
            }
        }
        protected virtual void childChangedHandler(CourseObjectBase sender, bool triggerRecalculation)
        {
            this.onChange(false);
            if (triggerRecalculation) { ConcurrentWorkQueue.Enqueue(() => this.recalculateResult()); }
        }
        public virtual void TriggerChange(bool triggerRecalculation) { this.onChange(triggerRecalculation); }
        public virtual void TriggerCalculation() { ConcurrentWorkQueue.Enqueue(() => this.recalculateResult()); }


        public event CourseWarningEmitEvent _WarningEmitted;
        protected virtual void onWarningEmitted(Guid g, CourseWarning w)
        {
            if (this._WarningEmitted != null)
            {
                this._WarningEmitted.Invoke(g, w);
            }
        }
        protected virtual void warningEmittedHandler(Guid g, CourseWarning w) { this.onWarningEmitted(g, w); }
        protected virtual void emitWarning(CourseWarning w) { this.onWarningEmitted(this.GUID, w); }


        /// <summary>
        /// Recalculates this course objects result.
        /// This method can and should raise warnings that would be difficult
        /// to determine in the checkValues() call.
        /// </summary>
        protected abstract void recalculateResult();
        /// <summary>
        /// This function is called every time data in the object changes.
        /// It should check the values of the current object and emit any
        /// appropriate warnings.
        /// </summary>
        protected abstract void checkValues();
        /// <summary>
        /// This function is used to simulate a destruction of the object.
        /// It will be called once the object is no longer used, without the
        /// need to wait for the GC.
        /// </summary>
        public abstract void Detach();
        /// <summary>
        /// Returns a string representation that can be used to identify this
        /// object.
        /// </summary>
        /// <returns>string</returns>
        protected abstract string getRef();
    }
}
