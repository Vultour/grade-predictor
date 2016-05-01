using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;


/// <copyright file="TestHelpersTests.cs">
///  Copyright (c) All Rights Reserved
///  <author>Martin Kukura</author>
/// </copyright>

namespace GPUnitTests
{
    [TestClass]
    public class TestHelpersTests
    {
        [TestMethod]
        public void CreateModuleTupleList_AllValues()
        {
            List<Tuple<double, double>> items = TestHelpers.CreateModuleTupleList(
                new[] {5.5, 15.5},
                new[] {25.5, 35.5},
                new[] {45.5, 55.5},
                new[] {65.5, 75.5},
                new[] {85.5, 95.5},
                new[] {100.0, 100.0}
            );

            Assert.AreEqual(5.5, items[0].Item1);
            Assert.AreEqual(15.5, items[0].Item2);
            Assert.AreEqual(25.5, items[1].Item1);
            Assert.AreEqual(35.5, items[1].Item2);
            Assert.AreEqual(45.5, items[2].Item1);
            Assert.AreEqual(55.5, items[2].Item2);
            Assert.AreEqual(65.5, items[3].Item1);
            Assert.AreEqual(75.5, items[3].Item2);
            Assert.AreEqual(85.5, items[4].Item1);
            Assert.AreEqual(95.5, items[4].Item2);
            Assert.AreEqual(100.0, items[5].Item1);
            Assert.AreEqual(100.0, items[5].Item2);
        }

        [TestMethod]
        public void CreateModuleValuesTupleList_AllValues()
        {
            List<Tuple<double, double>> items = TestHelpers.CreateModuleValuesTupleList(
                0.0,
                25.5,
                50.0,
                75.5,
                100.0
            );

            Assert.AreEqual(0.0, items[0].Item1);
            Assert.AreEqual(25.5, items[1].Item1);
            Assert.AreEqual(50.0, items[2].Item1);
            Assert.AreEqual(75.5, items[3].Item1);
            Assert.AreEqual(100.0, items[4].Item1);
        }

        [TestMethod]
        public void CreateModuleWeightsTupleList_AllValues()
        {
            List<Tuple<double, double>> items = TestHelpers.CreateModuleWeightsTupleList(
                0.0,
                25.5,
                50.0,
                75.5,
                100.0
            );

            Assert.AreEqual(0.0, items[0].Item2);
            Assert.AreEqual(25.5, items[1].Item2);
            Assert.AreEqual(50.0, items[2].Item2);
            Assert.AreEqual(75.5, items[3].Item2);
            Assert.AreEqual(100.0, items[4].Item2);
        }
    }
}
