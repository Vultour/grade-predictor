using System;
using System.Xml.Linq;

using GradePredictor.CourseCore;


/// <copyright file="CourseXMLBackend.Load.cs">
///  Copyright (c) All Rights Reserved
///  <author>Martin Kukura</author>
/// </copyright>

namespace GradePredictor.CourseUtil
{
    public partial class CourseXMLBackend
    {
		public Course Load()
        {
            this.load();
            return this.deserialize();
        }

		private void load()
        {
            try
            {
                this.xml = XDocument.Load(this.filepath);
            }
            catch (System.Xml.XmlException)
            {
                throw new InvalidCourseXMLException();
            }
        }

        private Course deserialize()
        {
            Course course = new Course();

            string courseTitle = (string)this.xml.Root.Element("title");
            this._assert(courseTitle);
            course.Title = courseTitle;

            var yearsRootNode = this.xml.Root.Element("years").Elements("year");
            this._assert(yearsRootNode);
            foreach (var yearNode in yearsRootNode)
            {
                int? yearNumber = (int?)yearNode.Element("number");
                this._assert(yearNumber);

                var modulesRootNode = yearNode.Element("modules").Elements("module");
                this._assert(modulesRootNode);
                foreach (var moduleNode in modulesRootNode)
                {
                    string moduleTitle = (string)moduleNode.Element("title");
                    this._assert(moduleTitle);
                    string moduleCode = (string)moduleNode.Element("code");
                    this._assert(moduleCode);
                    int? moduleCredits = (int?)moduleNode.Element("credits");
                    this._assert(moduleCredits);

                    course.Years[yearNumber.Value - 1].CreateModule(moduleTitle, moduleCode, moduleCredits.Value);
                    Module module = course.Years[yearNumber.Value - 1].Modules[course.Years[yearNumber.Value - 1].Modules.Count - 1];

                    var assessmentsRootNode = moduleNode.Element("assessments").Elements("assessment");
                    this._assert(assessmentsRootNode);
                    foreach (var assessmentNode in assessmentsRootNode)
                    {
                        string assessmentTitle = (string)assessmentNode.Element("title");
                        this._assert(assessmentTitle);
                        string assessmentTypeString = (string)assessmentNode.Element("type");
                        Assessment.AssessmentType assessmentType;
                        this._assert(assessmentTypeString);
						if (!Enum.TryParse<Assessment.AssessmentType>(assessmentTypeString, out assessmentType)) { this._assert(null); }
                        int? assessmentWeight = (int?)assessmentNode.Element("weight");
                        this._assert(assessmentWeight);
                        double? assessmentResult = (double?)assessmentNode.Element("result");
                        this._assert(assessmentResult);

                        module.AddAssessment(
                            assessmentTitle,
                            assessmentType,
							assessmentWeight.Value,
							assessmentResult.Value
						);
                    }
                }
            }

            return course;
        }


		private void _assert(object o)
        {
			if (o == null) { throw new InvalidCourseXMLException(); }
        }
    }
}
