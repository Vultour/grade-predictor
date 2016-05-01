/// <copyright file="CourseWarnings.YearHelpers.cs">
///  Copyright (c) All Rights Reserved
///  <author>Martin Kukura</author>
/// </copyright>

namespace GradePredictor.CourseCore
{
    public partial class CourseWarnings
    {
        public static CourseWarning EmitYearNoUsableModules(string reference) { return CourseWarnings.EmitYearNoUsableModules(reference, false); }
        public static CourseWarning EmitYearNoUsableModules(string reference, bool reset)
        {
            return new CourseWarning(
                CourseWarning.WarningType.YearNoUsableModules,
                CourseWarning.WarningLevel.INFO,
                reference,
                (reset) ? ("") : (Properties.Resources.WARNING_MESSAGE_YEAR_NOMODULES)
            );
        }


        public static CourseWarning EmitYearResultUnavailable(string reference) { return CourseWarnings.EmitYearResultUnavailable(reference, false); }
        public static CourseWarning EmitYearResultUnavailable(string reference, bool reset)
        {
            return new CourseWarning(
                CourseWarning.WarningType.YearResultUnavailable,
                CourseWarning.WarningLevel.ERROR,
                reference,
                (reset) ? ("") : (Properties.Resources.WARNING_MESSAGE_YEAR_NORESULT)
            );
        }


        public static CourseWarning EmitYearInconsistentCredits(string reference) { return CourseWarnings.EmitYearInconsistentCredits(reference, false); }
        public static CourseWarning EmitYearInconsistentCredits(string reference, bool reset)
        {
            return new CourseWarning(
                CourseWarning.WarningType.YearInconsistentCredits,
                CourseWarning.WarningLevel.WARNING,
                reference,
                (reset) ? ("") : (Properties.Resources.WARNING_MESSAGE_YEAR_INCONSCREDITS)
            );
        }
    }
}
