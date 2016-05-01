using System;
using System.Collections.Generic;


/// <copyright file="TestHelpers.cs">
///  Copyright (c) All Rights Reserved
///  <author>Martin Kukura</author>
/// </copyright>

namespace GPUnitTests
{
    static class TestHelpers
    {
        public static List<Tuple<double, double>> CreateModuleTupleList(params double[][] items)
        {
            List<Tuple<double, double>> ret = new List<Tuple<double, double>>();
            foreach (double[] item in items) { ret.Add(new Tuple<double, double>(item[0], item[1])); }
            return ret;
        }

        public static List<Tuple<double, double>> CreateModuleValuesTupleList(params double[] values)
        {
            List<Tuple<double, double>> ret = new List<Tuple<double, double>>();
            foreach (double item in values) { ret.Add(new Tuple<double, double>(item, 0.0)); }
            return ret;
        }

        public static List<Tuple<double, double>> CreateModuleWeightsTupleList(params double[] weights)
        {
            List<Tuple<double, double>> ret = new List<Tuple<double, double>>();
            foreach (double item in weights) { ret.Add(new Tuple<double, double>(0.0, item)); }
            return ret;
        }
    }
}
