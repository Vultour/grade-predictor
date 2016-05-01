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
    public class YearTests
    {
        private Year y;
        [TestInitialize]
        public void TestInitialize()
        {
            ConcurrentWorkQueue.Initialize();
            this.y = new Year(5);
        }


        [TestMethod]
        public void Year_Number_Basic()
        {
            Assert.AreEqual(5, this.y.Number);
        }


        [TestMethod]
        public void Year_IsUsable_Basic()
        {
            Assert.IsFalse(this.y.IsUsable);
        }

        [TestMethod]
        public void Year_IsUsable_Valid()
        {
            this.y.CreateModule("test", "test", 15);
            this.y.Modules[0].AddAssessment("test", Assessment.AssessmentType.COURSEWORK, 100, 100.0);
            Thread.Sleep(100);
            Assert.IsTrue(this.y.IsUsable);
        }

        [TestMethod]
        public void Year_IsUsable_InvalidModule()
        {
            this.y.CreateModule("test", "test", 0);
            this.y.Modules[0].AddAssessment("test", Assessment.AssessmentType.COURSEWORK, 100, 100.0);
            Thread.Sleep(100);
            Assert.IsFalse(this.y.IsUsable);
        }

        [TestMethod]
        public void Year_IsUsable_InvalidAssessment()
        {
            this.y.CreateModule("test", "test", 15);
            this.y.Modules[0].AddAssessment("test", Assessment.AssessmentType.COURSEWORK, 0, 100.0);
            Thread.Sleep(100);
            Assert.IsFalse(this.y.IsUsable);
        }


        [TestMethod]
        public void Year_Result_Basic()
        {
            Assert.AreEqual(Course.VALUE_NOT_AVAILABLE, this.y.Result);
        }

        [TestMethod]
        public void Year_Result_Valid()
        {
            this.y.CreateModule("test", "test", 15);
            this.y.Modules[0].AddAssessment("test", Assessment.AssessmentType.COURSEWORK, 100, 100.0);
            Thread.Sleep(100);
            Assert.AreEqual(100.0, this.y.Result);
        }

        [TestMethod]
        public void Year_Result_InvalidModule()
        {
            this.y.CreateModule("test", "test", 0);
            this.y.Modules[0].AddAssessment("test", Assessment.AssessmentType.COURSEWORK, 100, 100.0);
            Thread.Sleep(100);
            Assert.AreEqual(Course.VALUE_NOT_AVAILABLE, this.y.Result);
        }

        [TestMethod]
        public void Year_Result_InvalidAssessment()
        {
            this.y.CreateModule("test", "test", 15);
            this.y.Modules[0].AddAssessment("test", Assessment.AssessmentType.COURSEWORK, 0, 100.0);
            Thread.Sleep(100);
            Assert.AreEqual(Course.VALUE_NOT_AVAILABLE, this.y.Result);
        }


        [TestMethod]
        public void Year_UsableModules_Basic()
        {
            Assert.AreEqual(0, this.y.UsableModules.Count);
        }

        [TestMethod]
        public void Year_UsableModules_Valid()
        {
            this.y.CreateModule("test", "test", 15);
            this.y.Modules[0].AddAssessment("test", Assessment.AssessmentType.COURSEWORK, 100, 100.0);
            Thread.Sleep(100);
            Assert.AreEqual(1, this.y.UsableModules.Count);
        }

        [TestMethod]
        public void Year_UsableModules_Invalid()
        {
            this.y.CreateModule("test", "test", 15);
            this.y.Modules[0].AddAssessment("test", Assessment.AssessmentType.COURSEWORK, 0, 100.0);
            Thread.Sleep(100);
            Assert.AreEqual(0, this.y.UsableModules.Count);
        }


        [TestMethod]
        public void Year_Modules_Basic()
        {
            Assert.AreEqual(0, this.y.Modules.Count);
        }

        // TODO: Complete unit tests for Year.Modules


        [TestMethod]
        public void Year_NeedsRetake_Basic()
        {
            Assert.IsFalse(this.y.NeedsRetake);
        }

        // TODO: Complete unit tests for Year.NeedsRetake


        [TestMethod]
        public void Year_NeedsReferral_Basic()
        {
            Assert.IsFalse(this.y.NeedsReferral);
        }

        // TODO: Complete unit test for Year.NeedsReferral
    }
}
