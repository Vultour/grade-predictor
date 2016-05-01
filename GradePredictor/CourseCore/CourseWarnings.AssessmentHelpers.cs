/// <copyright file="CourseWarnings.AssessmentHelpers.cs">
///  Copyright (c) All Rights Reserved
///  <author>Martin Kukura</author>
/// </copyright>

namespace GradePredictor.CourseCore
{
    public partial class CourseWarnings
    {
        public static CourseWarning EmitAssessmentNoWeightValue(string reference) { return CourseWarnings.EmitAssessmentNoWeightValue(reference, false); }
        public static CourseWarning EmitAssessmentNoWeightValue(string reference, bool reset)
        {
            return new CourseWarning(
                CourseWarning.WarningType.AssessmentNoWeightValue,
				CourseWarning.WarningLevel.WARNING,
                reference,
				(reset) ? ("") : (Properties.Resources.WARNING_MESSAGE_ASSESSMENT_NOWEIGHT)
            );
        }


        public static CourseWarning EmitAssessmentInvalidResultValue(string reference) { return CourseWarnings.EmitAssessmentInvalidResultValue(reference, false); }
        public static CourseWarning EmitAssessmentInvalidResultValue(string reference, bool reset)
        {
            return new CourseWarning(
                CourseWarning.WarningType.AssessmentInvalidResultValue,
                CourseWarning.WarningLevel.WARNING,
                reference,
                (reset) ? ("") : (Properties.Resources.WARNING_MESSAGE_ASSESSMENT_INVALIDRESULT)
            );
        }
    }
}
