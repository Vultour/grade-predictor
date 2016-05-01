using System;


/// <copyright file="Exceptions.cs">
///  Copyright (c) All Rights Reserved
///  <author>Martin Kukura</author>
/// </copyright>

namespace GradePredictor.CourseUtil
{
    class InvalidCourseXMLException : Exception
    {
        public InvalidCourseXMLException() { }
    }

    class InvalidParameterException : Exception
    {
        public InvalidParameterException() { }
    }

    class InvalidCourseObjectException : Exception
    {
        public InvalidCourseObjectException() { }
    }
}
