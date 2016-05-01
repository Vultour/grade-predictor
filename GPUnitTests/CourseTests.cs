using System;
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
    public class CourseTests
    {
        private Course c;

        [TestInitialize]
        public void TestInitialize()
        {
            ConcurrentWorkQueue.Initialize();
            this.c = new Course(false);
        }


        [TestMethod]
        public void Course_Years_Basic()
        {
            Assert.AreEqual(3, this.c.Years.Length);
        }

        [TestMethod]
        public void Course_Years_Consistency()
        {
            Course c = new Course(false);
            Assert.AreEqual(3, c.Years.Length);
            Assert.AreEqual(1, c.Years[0].Number);
            Assert.AreEqual(2, c.Years[1].Number);
            Assert.AreEqual(3, c.Years[2].Number);
        }


        [TestMethod]
        public void Course_Result_Basic()
        {
            Assert.AreEqual(Course.Degree.Unknown, this.c.Result);
        }

        // TODO: Complete unit tests for Course.Result


        [TestMethod]
        public void Course_Title_Basic()
        {
            Assert.AreEqual("New Course", this.c.Title);
        }

        [TestMethod]
        public void Course_Title_Valid()
        {
            this.c.Title = "Test";
            Assert.AreEqual("Test", this.c.Title);
        }
    }
}
