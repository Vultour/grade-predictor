/// <copyright file="CourseWarnings.CourseHelpers.cs">
///  Copyright (c) All Rights Reserved
///  <author>Martin Kukura</author>
/// </copyright>

namespace GradePredictor.CourseCore
{
    public partial class CourseWarnings
    {
        public static CourseWarning EmitCourseInsufficientData(string reference) { return CourseWarnings.EmitCourseInsufficientData(reference, false); }
        public static CourseWarning EmitCourseInsufficientData(string reference, bool reset)
        {
            return new CourseWarning(
                CourseWarning.WarningType.CourseInsufficientData,
                CourseWarning.WarningLevel.ERROR,
                reference,
                (reset) ? ("") : (Properties.Resources.WARNING_MESSAGE_COURSE_INSUFFDATA)
            );
        }


        public static CourseWarning EmitCourseInterpolated(string reference) { return CourseWarnings.EmitCourseInterpolated(reference, false); }
        public static CourseWarning EmitCourseInterpolated(string reference, bool reset)
        {
            return new CourseWarning(
                CourseWarning.WarningType.CourseInterpolated,
                CourseWarning.WarningLevel.INFO,
                reference,
                (reset) ? ("") : (Properties.Resources.WARNING_MESSAGE_COURSE_INTERPOLATED)
            );
        }


        public static CourseWarning EmitCourseResultUnavailable(string reference) { return CourseWarnings.EmitCourseResultUnavailable(reference, false); }
        public static CourseWarning EmitCourseResultUnavailable(string reference, bool reset)
        {
            return new CourseWarning(
                CourseWarning.WarningType.CourseResultUnavailable,
                CourseWarning.WarningLevel.ERROR,
                reference,
                (reset) ? ("") : (Properties.Resources.WARNING_MESSAGE_COURSE_RESULTNA)
            );
        }


        public static CourseWarning EmitCourseRetakeFailure(string reference) { return CourseWarnings.EmitCourseRetakeFailure(reference, false); }
        public static CourseWarning EmitCourseRetakeFailure(string reference, bool reset)
        {
            return new CourseWarning(
                CourseWarning.WarningType.CourseRetakeFailure,
                CourseWarning.WarningLevel.ERROR,
                reference,
                (reset) ? ("") : (Properties.Resources.WARNING_MESSAGE_COURSE_RETAKEFAIL)
            );
        }


        public static CourseWarning EmitCourseRetakeSixFailure(string reference) { return CourseWarnings.EmitCourseRetakeSixFailure(reference, false); }
        public static CourseWarning EmitCourseRetakeSixFailure(string reference, bool reset)
        {
            return new CourseWarning(
                CourseWarning.WarningType.CourseRetakeSixFailure,
                CourseWarning.WarningLevel.ERROR,
                reference,
                (reset) ? ("") : (Properties.Resources.WARNING_MESSAGE_COURSE_RETAKESIXFAIL)
            );
        }


        public static CourseWarning EmitCourseReferralFailure(string reference) { return CourseWarnings.EmitCourseReferralFailure(reference, false); }
        public static CourseWarning EmitCourseReferralFailure(string reference, bool reset)
        {
            return new CourseWarning(
                CourseWarning.WarningType.CourseReferralFailure,
                CourseWarning.WarningLevel.ERROR,
                reference,
                (reset) ? ("") : (Properties.Resources.WARNING_MESSAGE_COURSE_REFFAIL)
            );
        }
    }
}
