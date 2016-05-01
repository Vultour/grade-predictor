using System;
using System.Collections.Generic;
using System.Linq;

using GradePredictor.CourseCore;


/// <copyright file="CourseCalculationHelper.cs">
///  Copyright (c) All Rights Reserved
///  <author>Martin Kukura</author>
/// </copyright>

namespace GradePredictor.CourseUtil
{
    /// <summary>
    ///  Helper calculation functions for interacting with course objects.
    /// </summary>
    public static class CourseCalculationHelper
    {
        /// <summary>
        ///  Sorter for DOUBLE/DOUBLE tuple collections.
        ///  Sorts the collection in descending order.
        /// </summary>
        public static int ValueWeightTupleSort(Tuple<double, double> x, Tuple<double, double> y)
        {
            if (x.Item1 < y.Item1) { return 1; }
            if (x.Item1 > y.Item1) { return -1; }
            return 0;
        }


        public static double Rescaler(double desiredValue, double actualValue)
        {
            return (desiredValue / actualValue);
        }

        /// <summary>
        ///  Rescales the weight of each item so that the total equals desiredTotal.
        /// </summary>
        /// <param name="items">
        ///  List of DOUBLE/DOUBLE tuples. Item1 contains the value, Item2 contains the respective
        ///  weight.
        /// </param>
        /// <param name="desiredTotal">The value that sum of all the weights should equal.</param>
        /// <returns>List</returns>
        public static List<Tuple<double, double>> Rescale(List<Tuple<double, double>> items, double desiredTotal)
        {
            IEnumerable<double> weights = items.Select((Tuple<double, double> i) => i.Item2);
            if (weights.Sum() == desiredTotal) { return items; }

            double rescaler = CourseCalculationHelper.Rescaler(desiredTotal, weights.Sum());
            return items.Select((Tuple<double, double> i) => new Tuple<double, double>(i.Item1, i.Item2 * rescaler)).ToList();
        }


        /// <summary>
        ///  Returns a bool and a subset of the items List, making sure the sum of all weights is close to
        ///  desiredWeight (equal or exceeding). It the input items' sum is less than desiredWeight,
        ///  they are upscaled to total its value.
        ///  The returned bool is false if the values had to be rescaled, or if the total returned weight
        ///  is not equal to desiredWeight.
        /// </summary>
        /// <param name="items">
        ///  A list of DOUBLE/DOUBLE tuples. Item1 contains the values, Item2 contains the respective
        ///  weights.
        /// </param>
        /// <param name="desiredWeight">The desired sum of the resulting lists weights.</param>
        /// <returns></returns>
        public static Tuple<bool, List<Tuple<double, double>>> GetApproximateWeight(List<Tuple<double, double>> items, double desiredWeight)
        {
            double w = items.Select((Tuple<double, double> i) => i.Item2).Sum();

            if (w == desiredWeight) { return new Tuple<bool, List<Tuple<double, double>>>(true, items); }
            if (w < desiredWeight) { return new Tuple<bool, List<Tuple<double, double>>>(false, CourseCalculationHelper.Rescale(items, desiredWeight)); }

            w = 0.0;
            int j = 0;
            List<Tuple<double, double>> result = new List<Tuple<double, double>>();
            while (w < desiredWeight)
            {
                result.Add(new Tuple<double, double>(items[j].Item1, items[j].Item2));
                w += items[j].Item2;
                j++;
            }
            return new Tuple<bool, List<Tuple<double, double>>>(
                ((w > desiredWeight) ? (false) : (true)),
                result
            );
        }

        /// <summary>
        ///  This function takes all the values and weights from the items parameter and 
        ///  replicates each to appear (weight/weightDivider) times. If there is a non-integer
        ///  remainder after the replication, the value will be inserted one last time with the
        ///  remaining weight. The return value is a 2-tuple containing a bool indicating whether
        ///  all splits could be carried out without resulting in a remainder, and the resulting
        ///  list.
        /// </summary>
        /// <param name="weightDivider">The weight by which all items will be split.</param>
        /// <param name="items">
        ///  A 2-tuple of DOUBLE/DOUBLE pairs, with Item1 containing the values, and Item2
        ///  containing the respective weight for each value.
        /// </param>
        /// <returns>Pair (2-tuple)</returns>
        /// <exception cref="GradePredictor.InvalidParameterException">
        ///  Thrown when the items list is empty, or when weightDivider is negative or equal to zero.
        /// </exception>
        public static Tuple<bool, List<Tuple<double, double>>> WeightReplicatedValues(double weightDivider, List<Tuple<double, double>> items)
        {
            if ((items.Count < 1) || (weightDivider == 0.0) || (weightDivider < 0.0)) { throw new InvalidParameterException(); }

            bool clean = true;
            List<Tuple<double, double>> result = items.SelectMany(
                (Tuple<double, double> i)
                =>
                {
                    List<Tuple<double, double>> tmp = new List<Tuple<double, double>>();
                    for (int j = 0; j < Math.Floor(i.Item2 / weightDivider); j++)
                    {
                        tmp.Add(new Tuple<double, double>(i.Item1, weightDivider));
                    }
                    if ((i.Item2 % weightDivider) != 0.0)
                    {
                        tmp.Add(new Tuple<double, double>(i.Item1, (i.Item2 % weightDivider)));
                        clean = false;
                    }
                    return tmp;
                }
            ).ToList();

            return new Tuple<bool, List<Tuple<double, double>>>(clean, result);
        }

        /// <summary>
        ///  Returns BOOL/DOUBLE pair indicating whether the values had to be rescaled, and the result.
        /// </summary>
        /// <param name="items">
        ///  A list of DOUBLE/DOUBLE tuples, with Item1 containing the values and Item2 containing the
        ///  respective weight for each value.
        /// </param>
        /// <returns>Pair (2-tuple)</returns>
        /// <exception cref="GradePredictor.InvalidParameterException">
        ///  Thrown when the items list is empty.
        /// </exception>
        public static Tuple<bool, double> WeightedResult(List<Tuple<double, double>> items)
        {
            if (items.Count < 1) { throw new InvalidParameterException(); }

            double weight = items.Select((Tuple<double, double> i) => i.Item2).Sum();

            double rescaler = (1.0 / weight);
            double result = 0.0;
            for (int j = 0; j < items.Count; j++)
            {
                result += ((items[j].Item2 * rescaler) * items[j].Item1);
                
            }
            return new Tuple<bool, double>((weight != 100), result);
        }


        /// <summary>
        /// If at least one year has a result, interpolates the result of any other missing years.
        /// </summary>
        public static void InterpolateYearResult(List<Tuple<double, double>> yearOne, List<Tuple<double, double>> yearTwo, List<Tuple<double, double>> yearThree)
        {
            List<double> results = new List<double>(3);
            if (yearOne.Count > 0) { results.Add(yearOne.Average((Tuple<double, double> i) => i.Item1)); }
            if (yearTwo.Count > 0) { results.Add(yearTwo.Average((Tuple<double, double> i) => i.Item1)); }
            if (yearThree.Count > 0) { results.Add(yearThree.Average((Tuple<double, double> i) => i.Item1)); }

            if ((results.Count < 1) || (results.Count >= 3)) { return; }

            double average = results.Average();
            if (yearOne.Count < 1) { yearOne.Add(new Tuple<double, double>(average, 120)); }
            if (yearTwo.Count < 1) { yearTwo.Add(new Tuple<double, double>(average, 120)); }
            if (yearThree.Count < 1) { yearThree.Add(new Tuple<double, double>(average, 120)); }
        }

        /// <summary>
        ///  Calculates the degree result based on the results from each relevant academic year.
        ///  <para>
        ///   This function DOES NOT interpolate missing results.
        ///  </para>
        /// </summary>
        /// <returns>Member of Course.Degree enum</returns>
        public static Course.Degree Degree(List<Tuple<double, double>> yearTwo, List<Tuple<double, double>> yearThree)
        {
            double weightTwo = yearTwo.Select((Tuple<double, double> i) => i.Item2).Sum();
            double weightThree = yearThree.Select((Tuple<double, double> i) => i.Item2).Sum();

            if ((weightTwo < 1) || (weightThree < 1)) { throw new InvalidParameterException(); }

            // Rescale if weight < 120
            if (weightTwo < 120) { yearTwo = CourseCalculationHelper.Rescale(yearTwo, 120); }
            if (weightThree < 120) { yearThree = CourseCalculationHelper.Rescale(yearThree, 120); }

            // Replicate modules for each 15 credits
            yearTwo = CourseCalculationHelper.WeightReplicatedValues(15, yearTwo).Item2;
            yearThree = CourseCalculationHelper.WeightReplicatedValues(15, yearThree).Item2;

            yearThree.Sort(CourseCalculationHelper.ValueWeightTupleSort);
            yearTwo.Add(yearThree[yearThree.Count - 1]);
            yearTwo.Sort(CourseCalculationHelper.ValueWeightTupleSort);

            // Get best 105 credits
            yearTwo = CourseCalculationHelper.GetApproximateWeight(yearTwo, 105).Item2;
            yearThree = CourseCalculationHelper.GetApproximateWeight(yearThree, 105).Item2;

            double bestLevelSix = yearThree.Average((Tuple<double, double> i) => i.Item1);
            double bestLevelFiveSix = yearTwo.Average((Tuple<double, double> i) => i.Item1);

            if ((bestLevelSix < 30) || (bestLevelFiveSix < 30)) { return Course.Degree.Fail; }
            if (bestLevelSix >= 70)
            {
                if (bestLevelFiveSix >= 60) { return Course.Degree.FirstClass; }
                if (bestLevelFiveSix >= 50) { return Course.Degree.UpperSecondClass; }
                if (bestLevelFiveSix >= 40) { return Course.Degree.SecondClass; }
                else { return Course.Degree.ThirdClass; }
            }
            if (bestLevelSix >= 60)
            {
                if (bestLevelFiveSix >= 50) { return Course.Degree.UpperSecondClass; }
                if (bestLevelFiveSix >= 40) { return Course.Degree.SecondClass; }
                else { return Course.Degree.ThirdClass; }
            }
            if (bestLevelSix >= 50)
            {
                if (bestLevelFiveSix >= 40) { return Course.Degree.SecondClass; }
                else { return Course.Degree.ThirdClass; }
            }
            if (bestLevelSix >= 40)
            {
                return Course.Degree.ThirdClass;
            }

            return Course.Degree.Unknown;
        }
    }
}
