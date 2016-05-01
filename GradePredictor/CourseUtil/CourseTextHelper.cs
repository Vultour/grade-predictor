using GradePredictor.CourseCore;


/// <copyright file="CourseTextHelper.cs">
///  Copyright (c) All Rights Reserved
///  <author>Martin Kukura</author>
/// </copyright>

namespace GradePredictor.CourseUtil
{
    static class CourseTextHelper
    {
        public static string Percentage(double value) { return CourseTextHelper.Percentage(value, 1, true); }
        public static string Percentage(double value, int precision, bool shorthand)
        {
            if (value == Course.VALUE_NOT_AVAILABLE) { return (shorthand) ? ("N/A") : ("Unavailable"); }
            if ((value < 0) || (value > 100)) { return (shorthand) ? ("???") : ("Unknown"); }
            return value.ToString("f" + precision.ToString());
        }

        public static string Degree(Course.Degree degree)
        {
            switch (degree)
            {
                case Course.Degree.FirstClass:
                    return "First Class";
                case Course.Degree.UpperSecondClass:
                    return "Upper Second Class";
                case Course.Degree.SecondClass:
                    return "Second Class";
                case Course.Degree.ThirdClass:
                    return "Third Class";
                case Course.Degree.Fail:
                    return "Fail";
            }
            return "Not Available";
        }
    }
}
