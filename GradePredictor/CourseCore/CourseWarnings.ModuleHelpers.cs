/// <copyright file="CourseWarnings.ModuleHelpers.cs">
///  Copyright (c) All Rights Reserved
///  <author>Martin Kukura</author>
/// </copyright>

namespace GradePredictor.CourseCore
{
    public partial class CourseWarnings
    {
        public static CourseWarning EmitModuleInvalidCreditValue(string reference) { return CourseWarnings.EmitModuleInvalidCreditValue(reference, false); }
        public static CourseWarning EmitModuleInvalidCreditValue(string reference, bool reset)
        {
            return new CourseWarning(
                CourseWarning.WarningType.ModuleInvalidCreditValue,
                CourseWarning.WarningLevel.WARNING,
                reference,
                (reset) ? ("") : (Properties.Resources.WARNING_MESSAGE_MODULE_INVALIDCREDITS)
            );
        }


        public static CourseWarning EmitModuleInvalidResultValue(string reference) { return CourseWarnings.EmitModuleInvalidResultValue(reference, false); }
        public static CourseWarning EmitModuleInvalidResultValue(string reference, bool reset)
        {
            return new CourseWarning(
                CourseWarning.WarningType.ModuleInvalidResultValue,
                CourseWarning.WarningLevel.WARNING,
                reference,
                (reset) ? ("") : (Properties.Resources.WARNING_MESSAGE_MODULE_INVALIDRESULT)
            );
        }


        public static CourseWarning EmitModuleNoAssessments(string reference) { return CourseWarnings.EmitModuleNoAssessments(reference, false); }
        public static CourseWarning EmitModuleNoAssessments(string reference, bool reset)
        {
            return new CourseWarning(
                CourseWarning.WarningType.ModuleNoUsableAssessments,
                CourseWarning.WarningLevel.INFO,
                reference,
                (reset) ? ("") : (Properties.Resources.WARNING_MESSAGE_MODULE_NOASSESSMENTS)
            );
        }


        public static CourseWarning EmitModuleNoCreditValue(string reference) { return CourseWarnings.EmitModuleNoCreditValue(reference, false); }
        public static CourseWarning EmitModuleNoCreditValue(string reference, bool reset)
        {
            return new CourseWarning(
                CourseWarning.WarningType.ModuleNoCreditValue,
                CourseWarning.WarningLevel.INFO,
                reference,
                (reset) ? ("") : (Properties.Resources.WARNING_MESSAGE_MODULE_NOCREDITS)
            );
        }


        public static CourseWarning EmitModuleNonStandardCreditValue(string reference) { return CourseWarnings.EmitModuleNonStandardCreditValue(reference, false); }
        public static CourseWarning EmitModuleNonStandardCreditValue(string reference, bool reset)
        {
            return new CourseWarning(
                CourseWarning.WarningType.ModuleNonStandardCreditValue,
                CourseWarning.WarningLevel.WARNING,
                reference,
                (reset) ? ("") : (Properties.Resources.WARNING_MESSAGE_MODULE_NONSTANDCREDITS)
            );
        }


        public static CourseWarning EmitModuleInconsistentAssessments(string reference) { return CourseWarnings.EmitModuleInconsistentAssessments(reference, false); }
        public static CourseWarning EmitModuleInconsistentAssessments(string reference, bool reset)
        {
            return new CourseWarning(
                CourseWarning.WarningType.ModuleInconsistentAssessments,
                CourseWarning.WarningLevel.WARNING,
                reference,
                (reset) ? ("") : (Properties.Resources.WARNING_MESSAGE_MODULE_INCONSASSESSMENTS)
            );
        }
    }
}
