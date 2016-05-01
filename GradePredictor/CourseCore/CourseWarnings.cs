using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/// <copyright file="CourseWarnings.cs">
///  Copyright (c) All Rights Reserved
///  <author>Martin Kukura</author>
/// </copyright>

namespace GradePredictor.CourseCore
{
    public delegate void CourseWarningEmitEvent(Guid g, CourseWarning w);

    /// <summary>
    /// This class provides functions for managing messages from
    /// Course, Module and Assessments objects.
    /// It should be thread-safe.
    /// </summary>
    public partial class CourseWarnings
    {
        public event VoidDelegate WarningsChanged;
        private ConcurrentDictionary<Guid, ConcurrentDictionary<CourseWarning.WarningType, CourseWarning>> warnings;


        public CourseWarnings()
        {
            this.warnings = new ConcurrentDictionary<Guid, ConcurrentDictionary<CourseWarning.WarningType, CourseWarning>>(4, 28);
        }

        
        public void SetWarning(Guid g, CourseWarning w)
        {
            CourseWarning tmp;
            ConcurrentDictionary<CourseWarning.WarningType, CourseWarning> tmpL;
            if (w.Type == CourseWarning.WarningType.Reset) {
                this.warnings.TryRemove(g, out tmpL);
            }
            else if (w.Message == "") {
                if (this.warnings.TryGetValue(g, out tmpL))
                {
                    tmpL.TryRemove(w.Type, out tmp);
                }
            }
            else
            {
                this.warnings.TryAdd(g, new ConcurrentDictionary<CourseWarning.WarningType, CourseWarning>());
                if (this.warnings.TryGetValue(g, out tmpL))
                {
                    if (tmpL.TryGetValue(w.Type, out tmp)) { tmpL.TryUpdate(w.Type, w, tmp); }
                    else { tmpL.TryAdd(w.Type, w); }
                }
            }

            this.onChange();
        }

        public List<CourseWarning> GetWarnings()
        {
            return this.warnings.SelectMany(
               (KeyValuePair<Guid, ConcurrentDictionary<CourseWarning.WarningType, CourseWarning>> d) =>
                d.Value.Select((KeyValuePair<CourseWarning.WarningType, CourseWarning> dd) => dd.Value)
            ).ToList();
        }


        public static CourseWarning EmitReset()
        {
            return new CourseWarning(
                CourseWarning.WarningType.Reset,
                CourseWarning.WarningLevel.INFO,
                "",
                null
            );
        }

        private void onChange()
        {
            if (this.WarningsChanged != null)
            {
                this.WarningsChanged.Invoke();
            }
        }
    }
}
