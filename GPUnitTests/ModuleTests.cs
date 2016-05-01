using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using GradePredictor.CourseCore;
using GradePredictor.Util;


/// <copyright file="CourseTests.cs">
///  Copyright (c) All Rights Reserved
///  <author>Martin Kukura</author>
/// </copyright>

namespace GPUnitTests
{
    // HACK: Result calculations are running on a separate thread, therefore there is no
    //       way of checking the results immediately after the calculation is completed
    //       without setting up event handlers. Working around this by suspending the
    //       current thread for 100ms before checking values that depend on the
    //       calculations. This should be enough for them to finish.
    [TestClass]
    public class ModuleTests
    {
        private Module m;

        [TestInitialize]
        public void TestInitialize()
        {
            ConcurrentWorkQueue.Initialize();
            this.m = new Module("test", "test", 15, null);
        }


        [TestMethod]
        public void Module_Title_Basic()
        {
            Assert.AreEqual("test", this.m.Title);
        }

        [TestMethod]
        public void Module_Title_Valid()
        {
            this.m.EditModule("test2", this.m.Code, this.m.Credits);
            Assert.AreEqual("test2", this.m.Title);
        }


        [TestMethod]
        public void Module_Code_Basic()
        {
            Assert.AreEqual("TEST", this.m.Code);
        }

        [TestMethod]
        public void Module_Code_Valid()
        {
            this.m.EditModule(this.m.Title, "test2", this.m.Credits);
            Assert.AreEqual("TEST2", this.m.Code);
        }


        [TestMethod]
        public void Module_Credits_Basic()
        {
            Assert.AreEqual(15, this.m.Credits);
        }

        [TestMethod]
        public void Module_Credits_Valid()
        {
            this.m.EditModule(this.m.Title, this.m.Code, 30);
            Assert.AreEqual(30, this.m.Credits);
        }

        [TestMethod]
        public void Module_Credits_InvalidHigh()
        {
            this.m.EditModule(this.m.Title, this.m.Code, 150);
            Assert.AreEqual(0, this.m.Credits);
        }

        [TestMethod]
        public void Module_Credits_InvalidLow()
        {
            this.m.EditModule(this.m.Title, this.m.Code, -5);
            Assert.AreEqual(0, this.m.Credits);
        }


        [TestMethod]
        public void Module_Assessments_Basic()
        {
            Assert.AreEqual(0, this.m.Assessments.Count);
        }

        [TestMethod]
        public void Module_Assessments_Valid()
        {
            this.m.AddAssessment("test", Assessment.AssessmentType.COURSEWORK, 100, 100.0);
            Assert.AreEqual(1, this.m.Assessments.Count);
        }


        [TestMethod]
        public void Module_IsUsable_Basic()
        {
            Assert.IsFalse(this.m.IsUsable);
        }

        [TestMethod]
        public void Module_IsUsable_Valid()
        {
            this.m.AddAssessment("test", Assessment.AssessmentType.COURSEWORK, 100, 100.0);
            Thread.Sleep(100);
            Assert.IsTrue(this.m.IsUsable);
        }

        [TestMethod]
        public void Module_IsUsable_InvalidAssessment()
        {
            this.m.AddAssessment("test", Assessment.AssessmentType.COURSEWORK, 0, 100.0);
            Thread.Sleep(100);
            Assert.IsFalse(this.m.IsUsable);
        }

        [TestMethod]
        public void Module_IsUsable_InvalidModule()
        {
            this.m.Credits = 0;
            this.m.AddAssessment("test", Assessment.AssessmentType.COURSEWORK, 100, 100.0);
            Thread.Sleep(100);
            Assert.IsFalse(this.m.IsUsable);
        }


        [TestMethod]
        public void Module_NeedsRetake_Basic()
        {
            Assert.IsFalse(this.m.NeedsRetake);
        }

        [TestMethod]
        public void Module_NeedsRetake_ValidDataFalse()
        {
            this.m.AddAssessment("test", Assessment.AssessmentType.COURSEWORK, 100, 100.0);
            Thread.Sleep(100);
            Assert.IsFalse(this.m.NeedsRetake);
        }

        [TestMethod]
        public void Module_NeedsRetake_ValidDataTrue()
        {
            this.m.AddAssessment("test", Assessment.AssessmentType.COURSEWORK, 100, 25.0);
            Thread.Sleep(100);
            Assert.IsTrue(this.m.NeedsRetake);
        }

        [TestMethod]
        public void Module_NeedsRetake_InvalidDataFalse()
        {
            this.m.Credits = 0;
            this.m.AddAssessment("test", Assessment.AssessmentType.COURSEWORK, 100, 25.0);
            Thread.Sleep(100);
            Assert.IsFalse(this.m.NeedsRetake);
        }


        [TestMethod]
        public void Module_Result_Basic()
        {
            Thread.Sleep(100);
            Assert.AreEqual(Course.VALUE_NOT_AVAILABLE, m.Result);
        }

        [TestMethod]
        public void Module_Result_OneAssessment()
        {
            this.m.AddAssessment("test", Assessment.AssessmentType.COURSEWORK, 100, 100.0);
            Thread.Sleep(100);
            Assert.AreEqual(100.0, this.m.Result);
        }

        [TestMethod]
        public void Module_Result_TwoAssessments()
        {
            this.m.AddAssessment("test", Assessment.AssessmentType.COURSEWORK, 100, 25.0);
            this.m.AddAssessment("test", Assessment.AssessmentType.COURSEWORK, 100, 75.0);
            Thread.Sleep(100);
            Assert.AreEqual(50.0, this.m.Result);
        }

        [TestMethod]
        public void Module_Result_ThreeAssessmentsWithInvalid()
        {
            this.m.AddAssessment("test", Assessment.AssessmentType.COURSEWORK, 100, 25.0);
            this.m.AddAssessment("test", Assessment.AssessmentType.COURSEWORK, 100, 75.0);
            this.m.AddAssessment("test", Assessment.AssessmentType.COURSEWORK, 0, 100.0);
            Thread.Sleep(100);
            Assert.AreEqual(50.0, this.m.Result);
        }
    }
}
