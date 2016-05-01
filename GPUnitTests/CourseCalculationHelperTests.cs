using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using GradePredictor.CourseCore;
using GradePredictor.CourseUtil;


/// <copyright file="CourseCalculationHelperTests.cs">
///  Copyright (c) All Rights Reserved
///  <author>Martin Kukura</author>
/// </copyright>


namespace GPUnitTests
{
    [TestClass]
    public class CourseCalculationHelperTests
    {
        [TestMethod]
        public void ValueWeightTupleSort_AllValues()
        {
            List<Tuple<double, double>> data = TestHelpers.CreateModuleTupleList(
                new[] {65.3, 43.2},
                new[] {84.7, 26.0},
                new[] {76.0, 81.8},
                new[] {65.4, 43.2}
            );

            data.Sort(CourseCalculationHelper.ValueWeightTupleSort);
            Assert.AreEqual(84.7, data[0].Item1);
            Assert.AreEqual(76.0, data[1].Item1);
            Assert.AreEqual(65.4, data[2].Item1);
            Assert.AreEqual(65.3, data[3].Item1);

            data.Add(new Tuple<double, double>(100.0, 100.0));
            data.Sort(CourseCalculationHelper.ValueWeightTupleSort);
            Assert.AreEqual(100.0, data[0].Item1);
        }


        [TestMethod]
        public void Rescaler_NormalValue()
        {
            Assert.AreEqual(2.0, CourseCalculationHelper.Rescaler(100, 50));
            Assert.AreEqual(0.5, CourseCalculationHelper.Rescaler(100, 200));
            Assert.AreEqual(1.0, CourseCalculationHelper.Rescaler(100, 100));
        }


        [TestMethod]
        public void Rescale_IntegerValues()
        {
            List<Tuple<double, double>> data = TestHelpers.CreateModuleTupleList(
                new[] {100.0, 50.0},
                new[] {100.0, 50.0},
                new[] {100.0, 50.0},
                new[] {100.0, 50.0}
            );

            List<Tuple<double, double>> resultDown = CourseCalculationHelper.Rescale(data, 100);
            Assert.AreEqual(25.0, resultDown[0].Item2);
            Assert.AreEqual(25.0, resultDown[1].Item2);
            Assert.AreEqual(25.0, resultDown[2].Item2);
            Assert.AreEqual(25.0, resultDown[3].Item2);

            List<Tuple<double, double>> resultUp = CourseCalculationHelper.Rescale(data, 400);
            Assert.AreEqual(100.0, resultUp[0].Item2);
            Assert.AreEqual(100.0, resultUp[1].Item2);
            Assert.AreEqual(100.0, resultUp[2].Item2);
            Assert.AreEqual(100.0, resultUp[3].Item2);
        }

        [TestMethod]
        public void Rescale_FloatingValues()
        {
            List<Tuple<double, double>> data = TestHelpers.CreateModuleTupleList(
                new[] {100.0, 50.0},
                new[] {100.0, 50.0},
                new[] {100.0, 50.0},
                new[] {100.0, 50.0}
            );

            List<Tuple<double, double>> resultUp = CourseCalculationHelper.Rescale(data, 201);
            Assert.AreEqual(50.25, resultUp[0].Item2, 0.000001);
            Assert.AreEqual(50.25, resultUp[1].Item2, 0.000001);
            Assert.AreEqual(50.25, resultUp[2].Item2, 0.000001);
            Assert.AreEqual(50.25, resultUp[3].Item2, 0.000001);

            List<Tuple<double, double>> resultDown = CourseCalculationHelper.Rescale(data, 101);
            Assert.AreEqual(25.25, resultDown[0].Item2, 0.000001);
            Assert.AreEqual(25.25, resultDown[1].Item2, 0.000001);
            Assert.AreEqual(25.25, resultDown[2].Item2, 0.000001);
            Assert.AreEqual(25.25, resultDown[3].Item2, 0.000001);
        }


        [TestMethod]
        public void GetApproximateWeight_LessThan()
        {
            List<Tuple<double, double>> data = TestHelpers.CreateModuleWeightsTupleList(10, 10, 10);

            List<Tuple<double, double>> result = CourseCalculationHelper.GetApproximateWeight(data, 60).Item2;
            Assert.AreEqual(20, result[0].Item2);
            Assert.AreEqual(20, result[1].Item2);
            Assert.AreEqual(20, result[2].Item2);
        }

        [TestMethod]
        public void GetApproximateWeight_Equals()
        {
            List<Tuple<double, double>> data = TestHelpers.CreateModuleWeightsTupleList(10, 10, 10);

            List<Tuple<double, double>> result = CourseCalculationHelper.GetApproximateWeight(data, 30).Item2;
            Assert.AreEqual(10, result[0].Item2);
            Assert.AreEqual(10, result[1].Item2);
            Assert.AreEqual(10, result[2].Item2);
        }

        [TestMethod]
        public void GetApproximateWeight_MoreThanConsistent()
        {
            List<Tuple<double, double>> data = TestHelpers.CreateModuleWeightsTupleList(10, 20, 30);

            List<Tuple<double, double>> result = CourseCalculationHelper.GetApproximateWeight(data, 30).Item2;
            Assert.AreEqual(10, result[0].Item2);
            Assert.AreEqual(20, result[1].Item2);
        }

        [TestMethod]
        public void GetApproximateWeight_MoreThanInconsistent()
        {
            List<Tuple<double, double>> data = TestHelpers.CreateModuleWeightsTupleList(10, 20, 30, 40);

            List<Tuple<double, double>> result = CourseCalculationHelper.GetApproximateWeight(data, 35).Item2;
            Assert.AreEqual(10, result[0].Item2);
            Assert.AreEqual(20, result[1].Item2);
            Assert.AreEqual(30, result[2].Item2);
        }


        [TestMethod]
        public void WeightReplicatedValues_IntegerValues()
        {
            List<Tuple<double, double>> data = TestHelpers.CreateModuleTupleList(
                new[] {20.0, 15.0},
                new[] {40.0, 30.0},
                new[] {60.0, 15.0},
                new[] {80.0, 45.0}
            );

            Tuple<bool, List<Tuple<double, double>>> result = CourseCalculationHelper.WeightReplicatedValues(15, data);
            Assert.IsTrue(result.Item1);
            // First data item
            Assert.AreEqual(20, result.Item2[0].Item1);
            Assert.AreEqual(15, result.Item2[0].Item2);
            // Second data item
            Assert.AreEqual(40, result.Item2[1].Item1);
            Assert.AreEqual(15, result.Item2[1].Item2);
            Assert.AreEqual(40, result.Item2[2].Item1);
            Assert.AreEqual(15, result.Item2[2].Item2);
            // Third data item
            Assert.AreEqual(60, result.Item2[3].Item1);
            Assert.AreEqual(15, result.Item2[3].Item2);
            // Fourth data item
            Assert.AreEqual(80, result.Item2[4].Item1);
            Assert.AreEqual(15, result.Item2[4].Item2);
            Assert.AreEqual(80, result.Item2[5].Item1);
            Assert.AreEqual(15, result.Item2[5].Item2);
            Assert.AreEqual(80, result.Item2[6].Item1);
            Assert.AreEqual(15, result.Item2[6].Item2);
        }

        [TestMethod]
        public void WeightReplicatedValues_FloatingValues()
        {
            List<Tuple<double, double>> data = TestHelpers.CreateModuleTupleList(
                new[] {20.0, 20.25},
                new[] {40.0, 30.55},
                new[] {60.0, 15.75},
                new[] {80.0, 59.95}
            );

            Tuple<bool, List<Tuple<double, double>>> result = CourseCalculationHelper.WeightReplicatedValues(15, data);
            Assert.IsFalse(result.Item1);
            // First data item
            Assert.AreEqual(20, result.Item2[0].Item1);
            Assert.AreEqual(15, result.Item2[0].Item2);
            Assert.AreEqual(20, result.Item2[1].Item1);
            Assert.AreEqual(5.25, result.Item2[1].Item2, 0.000001);
            // Second data item
            Assert.AreEqual(40, result.Item2[2].Item1);
            Assert.AreEqual(15, result.Item2[2].Item2);
            Assert.AreEqual(40, result.Item2[3].Item1);
            Assert.AreEqual(15, result.Item2[3].Item2);
            Assert.AreEqual(40, result.Item2[4].Item1);
            Assert.AreEqual(0.55, result.Item2[4].Item2, 0.000001);
            // Third data item
            Assert.AreEqual(60, result.Item2[5].Item1);
            Assert.AreEqual(15, result.Item2[5].Item2);
            Assert.AreEqual(60, result.Item2[6].Item1);
            Assert.AreEqual(0.75, result.Item2[6].Item2, 0.000001);
            // Fourth data item
            Assert.AreEqual(80, result.Item2[7].Item1);
            Assert.AreEqual(15, result.Item2[7].Item2);
            Assert.AreEqual(80, result.Item2[8].Item1);
            Assert.AreEqual(15, result.Item2[8].Item2);
            Assert.AreEqual(80, result.Item2[9].Item1);
            Assert.AreEqual(15, result.Item2[9].Item2);
            Assert.AreEqual(80, result.Item2[10].Item1);
            Assert.AreEqual(14.95, result.Item2[10].Item2, 0.000001);
        }


        [TestMethod]
        public void WeightedResult_ConsistentValues()
        {
            List<Tuple<double, double>> data = TestHelpers.CreateModuleTupleList(
                new[] {100.0, 50.0},
                new[] {50.0, 50.0}
            );

            Tuple<bool, double> result = CourseCalculationHelper.WeightedResult(data);
            Assert.AreEqual(75.0, result.Item2, 0.000001);
            Assert.IsFalse(result.Item1);
        }

        [TestMethod]
        public void WeightedResult_InconsistentValues()
        {
            List<Tuple<double, double>> data = TestHelpers.CreateModuleTupleList(
                new[] {100.0, 60.0},
                new[] {50.0, 60.0}
            );

            Tuple<bool, double> result = CourseCalculationHelper.WeightedResult(data);
            Assert.AreEqual(75.0, result.Item2, 0.000001);
            Assert.IsTrue(result.Item1);
        }


        [TestMethod]
        public void InterpolateYearResult_MissingFirst()
        {
            List<Tuple<double, double>> one = new List<Tuple<double, double>>();
            List<Tuple<double, double>> two = TestHelpers.CreateModuleValuesTupleList(0, 50);
            List<Tuple<double, double>> three = TestHelpers.CreateModuleValuesTupleList(25, 75);

            CourseCalculationHelper.InterpolateYearResult(one, two, three);
            Assert.AreEqual(37.5, one[0].Item1, 0.000001);
        }

        [TestMethod]
        public void InterpolateYearResult_MissingSecond()
        {
            List<Tuple<double, double>> one = TestHelpers.CreateModuleValuesTupleList(0, 50);
            List<Tuple<double, double>> two = new List<Tuple<double, double>>();
            List<Tuple<double, double>> three = TestHelpers.CreateModuleValuesTupleList(25, 75);

            CourseCalculationHelper.InterpolateYearResult(one, two, three);
            Assert.AreEqual(37.5, two[0].Item1, 0.000001);
        }

        [TestMethod]
        public void InterpolateYearResult_MissingThird()
        {
            List<Tuple<double, double>> one = TestHelpers.CreateModuleValuesTupleList(0, 50);
            List<Tuple<double, double>> two = TestHelpers.CreateModuleValuesTupleList(25, 75);
            List<Tuple<double, double>> three = new List<Tuple<double, double>>();

            CourseCalculationHelper.InterpolateYearResult(one, two, three);
            Assert.AreEqual(37.5, three[0].Item1, 0.000001);
        }

        [TestMethod]
        public void InterpolateYearResult_MissingMultiple()
        {
            List<Tuple<double, double>> one = TestHelpers.CreateModuleValuesTupleList(0, 50);
            List<Tuple<double, double>> two = TestHelpers.CreateModuleValuesTupleList(25, 75);
            List<Tuple<double, double>> three = TestHelpers.CreateModuleValuesTupleList(50, 100);

            List<Tuple<double, double>> x = new List<Tuple<double, double>>();
            List<Tuple<double, double>> y = new List<Tuple<double, double>>();
            List<Tuple<double, double>> z = new List<Tuple<double, double>>();

            CourseCalculationHelper.InterpolateYearResult(x, y, z);
            Assert.AreEqual(0, x.Count);
            Assert.AreEqual(0, y.Count);
            Assert.AreEqual(0, z.Count);

            CourseCalculationHelper.InterpolateYearResult(one, y, z);
            Assert.AreEqual(25.0, y[0].Item1);
            Assert.AreEqual(25.0, z[0].Item1);

            y = new List<Tuple<double, double>>();
            z = new List<Tuple<double, double>>();

            CourseCalculationHelper.InterpolateYearResult(x, two, z);
            Assert.AreEqual(50.0, x[0].Item1);
            Assert.AreEqual(50.0, z[0].Item1);

            x = new List<Tuple<double, double>>();
            z = new List<Tuple<double, double>>();

            CourseCalculationHelper.InterpolateYearResult(x, y, three);
            Assert.AreEqual(75.0, x[0].Item1);
            Assert.AreEqual(75.0, y[0].Item1);
        }


        [TestMethod]
        public void Degree_FirstClass()
        {
            Assert.AreEqual(
                Course.Degree.FirstClass,
                CourseCalculationHelper.Degree(
                    TestHelpers.CreateModuleTupleList(
                        new[] { 100.0, 90.0 },
                        new[] { 100.0, 15.0 },
                        new[] { 100.0, 15.0 }
                    ),
                    TestHelpers.CreateModuleTupleList(
                        new[] { 100.0, 90.0 },
                        new[] { 100.0, 15.0 },
                        new[] { 100.0, 15.0 }
                    )
                )
            );

            Assert.AreEqual(
                Course.Degree.FirstClass,
                CourseCalculationHelper.Degree(
                    TestHelpers.CreateModuleTupleList(
                        new[] { 60.0, 90.0 },
                        new[] { 60.0, 15.0 },
                        new[] { 60.0, 15.0 }
                    ),
                    TestHelpers.CreateModuleTupleList(
                        new[] { 70.0, 90.0 },
                        new[] { 70.0, 15.0 },
                        new[] { 70.0, 15.0 }
                    )
                )
            );
        }

        [TestMethod]
        public void Degree_UpperSecondClass()
        {
            Assert.AreEqual(
                Course.Degree.UpperSecondClass,
                CourseCalculationHelper.Degree(
                    TestHelpers.CreateModuleTupleList(
                        new[] { 50, 90.0 },
                        new[] { 50.0, 15.0 },
                        new[] { 50.0, 15.0 }
                    ),
                    TestHelpers.CreateModuleTupleList(
                        new[] { 100.0, 90.0 },
                        new[] { 100.0, 15.0 },
                        new[] { 100.0, 15.0 }
                    )
                )
            );

            Assert.AreEqual(
                Course.Degree.UpperSecondClass,
                CourseCalculationHelper.Degree(
                    TestHelpers.CreateModuleTupleList(
                        new[] { 50, 90.0 },
                        new[] { 50.0, 15.0 },
                        new[] { 50.0, 15.0 }
                    ),
                    TestHelpers.CreateModuleTupleList(
                        new[] { 65.0, 90.0 },
                        new[] { 65.0, 15.0 },
                        new[] { 65.0, 15.0 }
                    )
                )
            );
        }

        [TestMethod]
        public void Degree_SecondClass()
        {
            Assert.AreEqual(
                Course.Degree.SecondClass,
                CourseCalculationHelper.Degree(
                    TestHelpers.CreateModuleTupleList(
                        new[] { 35.0, 90.0 },
                        new[] { 35.0, 15.0 },
                        new[] { 35.0, 15.0 }
                    ),
                    TestHelpers.CreateModuleTupleList(
                        new[] { 100.0, 90.0 },
                        new[] { 100.0, 15.0 },
                        new[] { 100.0, 15.0 }
                    )
                )
            );

            Assert.AreEqual(
                Course.Degree.SecondClass,
                CourseCalculationHelper.Degree(
                    TestHelpers.CreateModuleTupleList(
                        new[] { 40.0, 90.0 },
                        new[] { 40.0, 15.0 },
                        new[] { 40.0, 15.0 }
                    ),
                    TestHelpers.CreateModuleTupleList(
                        new[] { 65.0, 90.0 },
                        new[] { 65.0, 15.0 },
                        new[] { 65.0, 15.0 }
                    )
                )
            );

            Assert.AreEqual(
                Course.Degree.SecondClass,
                CourseCalculationHelper.Degree(
                    TestHelpers.CreateModuleTupleList(
                        new[] { 40.0, 90.0 },
                        new[] { 40.0, 15.0 },
                        new[] { 40.0, 15.0 }
                    ),
                    TestHelpers.CreateModuleTupleList(
                        new[] { 55.0, 90.0 },
                        new[] { 55.0, 15.0 },
                        new[] { 55.0, 15.0 }
                    )
                )
            );
        }

        [TestMethod]
        public void Degree_ThirdClass()
        {
            Assert.AreEqual(
                Course.Degree.ThirdClass,
                CourseCalculationHelper.Degree(
                    TestHelpers.CreateModuleTupleList(
                        new[] { 100.0, 90.0 },
                        new[] { 100.0, 15.0 },
                        new[] { 100.0, 15.0 }
                    ),
                    TestHelpers.CreateModuleTupleList(
                        new[] { 45.0, 90.0 },
                        new[] { 45.0, 15.0 },
                        new[] { 45.0, 15.0 }
                    )
                )
            );

            Assert.AreEqual(
                Course.Degree.ThirdClass,
                CourseCalculationHelper.Degree(
                    TestHelpers.CreateModuleTupleList(
                        new[] { 45.0, 90.0 },
                        new[] { 45.0, 15.0 },
                        new[] { 45.0, 15.0 }
                    ),
                    TestHelpers.CreateModuleTupleList(
                        new[] { 45.0, 90.0 },
                        new[] { 45.0, 15.0 },
                        new[] { 45.0, 15.0 }
                    )
                )
            );
        }

        [TestMethod]
        public void Degree_Fail()
        {
            Assert.AreEqual(
                Course.Degree.Fail,
                CourseCalculationHelper.Degree(
                    TestHelpers.CreateModuleTupleList(
                        new[] { 100.0, 90.0 },
                        new[] { 100.0, 15.0 },
                        new[] { 100.0, 15.0 }
                    ),
                    TestHelpers.CreateModuleTupleList(
                        new[] { 25.0, 90.0 },
                        new[] { 25.0, 15.0 },
                        new[] { 25.0, 15.0 }
                    )
                )
            );

            Assert.AreEqual(
                Course.Degree.Fail,
                CourseCalculationHelper.Degree(
                    TestHelpers.CreateModuleTupleList(
                        new[] { 15.0, 90.0 },
                        new[] { 15.0, 15.0 },
                        new[] { 15.0, 15.0 }
                    ),
                    TestHelpers.CreateModuleTupleList(
                        new[] { 100.0, 90.0 },
                        new[] { 100.0, 15.0 },
                        new[] { 100.0, 15.0 }
                    )
                )
            );

            Assert.AreEqual(
                Course.Degree.Fail,
                CourseCalculationHelper.Degree(
                    TestHelpers.CreateModuleTupleList(
                        new[] { 25.0, 90.0 },
                        new[] { 25.0, 15.0 },
                        new[] { 25.0, 15.0 }
                    ),
                    TestHelpers.CreateModuleTupleList(
                        new[] { 25.0, 90.0 },
                        new[] { 25.0, 15.0 },
                        new[] { 25.0, 15.0 }
                    )
                )
            );
        }

        [TestMethod]
        public void Degree_Unknown()
        {
            Assert.AreEqual(
                Course.Degree.Unknown,
                CourseCalculationHelper.Degree(
                    TestHelpers.CreateModuleTupleList(
                        new[] { 100.0, 90.0 },
                        new[] { 100.0, 15.0 },
                        new[] { 100.0, 15.0 }
                    ),
                    TestHelpers.CreateModuleTupleList(
                        new[] { 35.0, 90.0 },
                        new[] { 35.0, 15.0 },
                        new[] { 35.0, 15.0 }
                    )
                )
            );

            Assert.AreEqual(
                Course.Degree.Unknown,
                CourseCalculationHelper.Degree(
                    TestHelpers.CreateModuleTupleList(
                        new[] { 35.0, 90.0 },
                        new[] { 35.0, 15.0 },
                        new[] { 35.0, 15.0 }
                    ),
                    TestHelpers.CreateModuleTupleList(
                        new[] { 35.0, 90.0 },
                        new[] { 35.0, 15.0 },
                        new[] { 35.0, 15.0 }
                    )
                )
            );
        }
    }
}
