using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using GradePredictor.CourseCore;


/// <copyright file="CourseTests.cs">
///  Copyright (c) All Rights Reserved
///  <author>Martin Kukura</author>
/// </copyright>

namespace GPUnitTests
{
    [TestClass]
    public class AssessmentTests
    {
        [TestMethod]
        public void Assessment_BasicCheck()
        {
            Assessment a = new Assessment("test", Assessment.AssessmentType.VIVA, 50, 75.5, null);
            Assert.AreEqual("test", a.Title);
            Assert.AreEqual(Assessment.AssessmentType.VIVA, a.Type);
            Assert.AreEqual(50, a.Weight);
            Assert.AreEqual(75.5, a.Result);
        }

        [TestMethod]
        public void Assessment_IsUsableCheck()
        {
            Assessment a = new Assessment("test", Assessment.AssessmentType.COURSEWORK, 50, 75.5, null);
            Assert.IsTrue(a.IsUsable);

            a = new Assessment("test", Assessment.AssessmentType.COURSEWORK, 50, 0, null);
            Assert.IsTrue(a.IsUsable);

            a = new Assessment("test", Assessment.AssessmentType.COURSEWORK, 0, 75.5, null);
            Assert.IsFalse(a.IsUsable);
        }

        [TestMethod]
        public void Assessment_WeightValidation()
        {
            Assessment a = new Assessment("test", Assessment.AssessmentType.COURSEWORK, -5, 75.5, null);
            Assert.AreEqual(0, a.Weight);

            a = new Assessment("test", Assessment.AssessmentType.COURSEWORK, 150, 75.5, null);
            Assert.AreEqual(0, a.Weight);

            a = new Assessment("test", Assessment.AssessmentType.COURSEWORK, 50, 75.5, null);
            a.changeAssessment(a.Type, -5, a.Result, a.Title);
            Assert.AreEqual(0, a.Weight);

            a = new Assessment("test", Assessment.AssessmentType.COURSEWORK, 50, 75.5, null);
            a.changeAssessment(a.Type, 150, a.Result, a.Title);
            Assert.AreEqual(0, a.Weight);
        }
    }
}
