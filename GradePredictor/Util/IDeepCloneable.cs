/// <copyright file="IDeepCloneable.cs">
///  Copyright (c) All Rights Reserved
///  <author>Martin Kukura</author>
/// </copyright>

namespace GradePredictor.Util
{
    /// <summary>
    /// Requires all inheriting classes to implement the DeepClone() method.
    /// </summary>
    /// <typeparam name="T">Return type of the DeepClone() method.</typeparam>
    public interface IDeepCloneable<T>
    {
        /// <summary>
        /// Returns a deep copy of this object's instance.
        /// </summary>
        /// <returns>T</returns>
        T DeepClone();
    }
}
