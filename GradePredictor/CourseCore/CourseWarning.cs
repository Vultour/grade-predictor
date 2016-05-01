/// <copyright file="CourseWarning.cs">
///  Copyright (c) All Rights Reserved
///  <author>Martin Kukura</author>
/// </copyright>

namespace GradePredictor.CourseCore
{
    public class CourseWarning
    {
        public enum WarningLevel { INFO, WARNING, ERROR }
        public enum WarningType
        {
            CourseInsufficientData, CourseInterpolated, CourseResultUnavailable, CourseRetakeFailure, CourseRetakeSixFailure, CourseReferralFailure,
            YearNoUsableModules, YearResultUnavailable, YearInconsistentCredits,
            ModuleNoUsableAssessments, ModuleNoCreditValue, ModuleInvalidCreditValue, ModuleInvalidResultValue, ModuleNonStandardCreditValue, ModuleInconsistentAssessments,
            AssessmentNoWeightValue, AssessmentInvalidResultValue,
            Reset
        }

        public string Message { get; private set; }
        public string Reference { get; private set; }
        public WarningLevel Level { get; private set; }
        public WarningType Type { get; private set; }

        public CourseWarning(WarningType type, WarningLevel level, string reference, string message)
        {
            this.Type = type;
            this.Level = level;
            this.Reference = reference;
            this.Message = message;
        }
    }
}
