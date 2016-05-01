using System.Drawing;


/// <copyright file="CourseColor.cs">
///  Copyright (c) All Rights Reserved
///  <author>Martin Kukura</author>
/// </copyright>

namespace GradePredictor.CourseUtil
{
    static class CourseColor
    {
        public static Color FirstClass          = Color.Green;
        public static Color UpperSecondClass    = Color.DarkGreen;
        public static Color SecondClass         = Color.Yellow;
        public static Color ThirdClass          = Color.Orange;
        public static Color Fail                = Color.Red;
        public static Color Retake              = Color.OrangeRed;
        public static Color Unknown             = Color.Black;


        public static Color GetColor(double x)
        {
            if ((x <= 0) || (x > 100)) { return CourseColor.Unknown; }
            if (x >= 70)
            {
                return CourseColor.FirstClass;
            }
            else if (x >= 60)
            {
                return CourseColor.UpperSecondClass;
            }
            else if (x >= 50)
            {
                return CourseColor.SecondClass;
            }
            else if (x >= 40)
            {
                return CourseColor.ThirdClass;
            }
            else if (x >= 30)
            {
                return CourseColor.Retake;
            }
            else
            {
                return CourseColor.Fail;
            }
        }
    }
}
