using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace GradePredictor
{
    class CourseXMLBackend
    {
        private Course course;

        public CourseXMLBackend(Course c)
        {
            this.course = c;
        }
    }
}
