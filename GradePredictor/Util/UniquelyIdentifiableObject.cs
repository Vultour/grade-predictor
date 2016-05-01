using System;

/// <copyright file="UniquelyIdentifiableObject.cs">
///  Copyright (c) All Rights Reserved
///  <author>Martin Kukura</author>
/// </copyright>

namespace GradePredictor.Util
{
    /// <summary>
    /// <para>
    ///  Provides base class for objects that need to be uniquely identified.
    ///  The unique identifier is created automatically on instantiation of any
    ///  derived class.
    /// </para>
    /// <para>
    ///  This identifier supports near-infinite instantiations, and is thus 
    ///  not represented as an integer. This means that the creation of it is
    ///  relatively slow.
    /// </para>
    /// You can access the unique identifier through the GUID property.
    /// </summary>
    public abstract class UniquelyIdentifiableObject
    {
        private Guid _guid;

        /// <summary>
        /// Represents the unique identifier of this object.
        /// </summary>
        public Guid GUID { get { return this._guid; } }

        public UniquelyIdentifiableObject()
        {
            this._guid = Guid.NewGuid();
        }
    }
}
