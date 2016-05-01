using System.Xml.Linq;

using GradePredictor.CourseCore;


/// <copyright file="CourseXMLBackend.cs">
///  Copyright (c) All Rights Reserved
///  <author>Martin Kukura</author>
/// </copyright>

namespace GradePredictor.CourseUtil
{
    public partial class CourseXMLBackend
    {
        private Course course;
        private XDocument xml;
        private string filepath;

        public CourseXMLBackend(Course c)
        {
            this.course = c;
        }

        public CourseXMLBackend SetPath(string path)
        {
            this.filepath = path;
            return this;
        }
    }
}
