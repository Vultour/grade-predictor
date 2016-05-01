﻿using System.Xml.Linq;

using GradePredictor.CourseCore;


/// <copyright file="CourseXMLBackend.Save.cs">
///  Copyright (c) All Rights Reserved
///  <author>Martin Kukura</author>
/// </copyright>

namespace GradePredictor.CourseUtil
{
    public partial class CourseXMLBackend
    {
        public void Save()
        {
            if (this.course == null) { return; }
            this.serializeAndSave();
        }


        private void serializeAndSave()
        {
            this.serialize();
            this.save();
        }
        private void serialize()
        {
            XElement root = new XElement("course",
                new XElement("title", this.course.Title)
            );

            XElement yearsRootNode = new XElement("years");
            foreach (Year year in this.course.Years)
            {
                XElement yearNode = new XElement("year",
                    new XElement("number", year.Number)
                );

                XElement modulesRootNode = new XElement("modules");
                foreach (Module module in year.Modules)
                {
                    XElement moduleNode = new XElement("module",
                        new XElement("title", module.Title),
                        new XElement("code", module.Code),
                        new XElement("credits", module.Credits)
                    );

                    XElement assessmentsRootNode = new XElement("assessments");
                    foreach (Assessment assessment in module.Assessments)
                    {
                        XElement assessmentNode = new XElement("assessment",
                            new XElement("title", assessment.Title),
                            new XElement("type", assessment.Type),
                            new XElement("weight", assessment.Weight),
                            new XElement("result", assessment.Result)
                        );

                        assessmentsRootNode.Add(assessmentNode);
                    }
                    moduleNode.Add(assessmentsRootNode);

                    modulesRootNode.Add(moduleNode);
                }

                yearNode.Add(modulesRootNode);
                yearsRootNode.Add(yearNode);
            }

            root.Add(yearsRootNode);

            this.xml = new XDocument(
                new XComment("This is an autogenerated file, you should probably not edit it by hand."),
                root
            );
        }
        private void save()
        {
            this.xml.Save(this.filepath);
        }
    }
}
