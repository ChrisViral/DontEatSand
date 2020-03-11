using System;
using System.Collections.Generic;
using UnityEngine;

namespace DontEatSand.Utils
{
    /// <summary>
    /// Named existing layers in the project
    /// </summary>
    public enum Layers
    {
        DEFAULT            = 0,
        TRANSPARENT_FX     = 1,
        IGNORE_RAYCAST     = 2,
        WATER              = 4,
        UI                 = 5,
        POSTPROSSESSING    = 8,
    }

    /// <summary>
    /// Layer data container
    /// </summary>
    public readonly struct Layer : IEquatable<Layer>, IComparable<Layer>
    {
        #region Properties
        /// <summary>
        /// Integer value of the layer (0 to 31)
        /// </summary>
        public int Value { get; }

        /// <summary>
        /// Name of the layer
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// LayerMask of this layer
        /// </summary>
        public LayerMask Mask { get; }
        #endregion

        #region Constructors
        /// <summary>
        /// Creates a new layer from a layer number
        /// </summary>
        /// <param name="value">Integer value of the layer (0 to 31)</param>
        /// <exception cref="ArgumentOutOfRangeException">If <paramref name="value"/> is less than 0 or greater than 31</exception>
        public Layer(int value)
        {
            //Check range
            if (value > 31 || value < 0) { throw new ArgumentOutOfRangeException(nameof(value), value, "Layer number must be between 0 and 31 inclusively"); }

            //Set values
            this.Value = value;
            this.Name = LayerMask.LayerToName(value);
            this.Mask = 1 << value;
        }

        /// <summary>
        /// Creates a new layer from it's name
        /// </summary>
        /// <param name="name">Name of the layer get</param>
        /// <exception cref="ArgumentNullException">If <paramref name="name"/> is null</exception>
        /// <exception cref="ArgumentException">If <paramref name="name"/> is not a valid layer name</exception>
        public Layer(string name)
        {
            //Nullcheck
            if (name == null) { throw new ArgumentNullException(nameof(name), "Name cannot be null"); }
            this.Mask = LayerMask.NameToLayer(name);

            //Check if the layer is valid
            if (this.Mask == -1) { throw new ArgumentException("Invalid layer name provided", nameof(name)); }
            //Set values
            this.Name = name;
            this.Value = LayerUtils.MaskToValue(this.Mask);
        }
        #endregion

        #region Methods
        /// <summary>
        /// Gets the name of this Layer
        /// </summary>
        /// <returns>The name of the Layer</returns>
        public override string ToString() => this.Name;

        /// <summary>
        /// Tests if the passed object is an equal Layer
        /// </summary>
        /// <param name="o">Object to test</param>
        /// <returns>True if the passed object is a Layer of equal value, false otherwise</returns>
        public override bool Equals(object o) => o is Layer layer && Equals(layer);

        /// <summary>
        /// Tests if the passed Layer is equal to this instance
        /// </summary>
        /// <param name="layer">Layer to test</param>
        /// <returns>True if both layers are equal, false otherwise</returns>
        public bool Equals(Layer layer) => layer == this;

        /// <summary>
        /// Gets the Hashcode of this instance
        /// </summary>
        /// <returns>The Layer value number</returns>
        public override int GetHashCode() => this.Value;

        /// <summary>
        /// Compares both layers for sorting
        /// </summary>
        /// <param name="layer">Layer to compare to</param>
        /// <returns>-1 if this layer is lesser than the passed value, 1 if it is greater, and 0 if they are equal</returns>
        public int CompareTo(Layer layer) => this.Value.CompareTo(layer.Value);
        #endregion

        #region Operators
        /// <summary>
        /// Tests the equality of two layers
        /// </summary>
        /// <param name="a">First layer</param>
        /// <param name="b">Second layer</param>
        /// <returns>True if both layers are equal, false otherwise</returns>
        public static bool operator ==(Layer a, Layer b) => a.Value == b.Value;

        /// <summary>
        /// Tests the inequality of two layers
        /// </summary>
        /// <param name="a">First layer</param>
        /// <param name="b">Second layer</param>
        /// <returns>True if both layers aren't equal, false otherwise</returns>
        public static bool operator !=(Layer a, Layer b) => a.Value != b.Value;

        /// <summary>
        /// Bitwise OR operator between two layer masks
        /// </summary>
        /// <param name="a">First layer</param>
        /// <param name="b">Second layer</param>
        /// <returns>The bitwise OR mask of both layers</returns>
        public static int operator |(Layer a, Layer b) => a.Mask | b.Mask;

        /// <summary>
        /// Bitwise OR operator between two layer masks
        /// </summary>
        /// <param name="a">First layer</param>
        /// <param name="b">Second layer</param>
        /// <returns>The bitwise OR mask of both layers</returns>
        public static int operator |(Layer a, int b) => a.Mask | b;

        /// <summary>
        /// Bitwise OR operator between two layer masks
        /// </summary>
        /// <param name="a">First layer</param>
        /// <param name="b">Second layer</param>
        /// <returns>The bitwise OR mask of both layers</returns>
        public static int operator |(int a, Layer b) => a | b.Mask;

        /// <summary>
        /// Casts this layer to it's mask value
        /// </summary>
        /// <param name="layer">Layer to cast</param>
        public static implicit operator LayerMask(Layer layer) => layer.Mask;

        /// <summary>
        /// Casts the layer value (0 to 31) to it's Layer equivalent
        /// </summary>
        /// <param name="value">Value to cast</param>
        public static explicit operator Layer(int value) => new Layer(value);
        #endregion
    }

    /// <summary>
    /// Layers handling class
    /// </summary>
    public static class LayerUtils
    {
        #region Static fields
        /// <summary>
        /// Array of all the Layers of the game
        /// </summary>
        private static readonly Layer[] layers = new Layer[32];

        /// <summary>
        /// String name to layer mapping dictionary
        /// </summary>
        private static readonly Dictionary<string, Layer> layerNames = new Dictionary<string, Layer>(32);
        #endregion

        #region Static constructor
        /// <summary>
        /// Loads layers into the container array
        /// </summary>
        static LayerUtils()
        {
            //Load all the layers from their values
            for (int i = 0; i < 32; i++)
            {
                Layer layer = new Layer(i);
                layers[i] = layer;
                if (!string.IsNullOrWhiteSpace(layer.Name))
                {
                    layerNames.Add(layer.Name, layer);
                }
            }
        }
        #endregion

        #region Static methods
        /// <summary>
        /// Returns the layer value of a given LayerMask
        /// NOTE: If the LayerMask is a combine mask, this will return the first layer of the mask
        /// </summary>
        /// <param name="mask">LayerMask to get the value from</param>
        /// <returns>The layer value of this mask (0 to 31)</returns>
        public static int MaskToValue(LayerMask mask)
        {
            int value = 0;
            for (int i = mask; i != 1; i >>= 1) { value++; }
            return value;
        }

        /// <summary>
        /// Gets the specified layer
        /// </summary>
        /// <param name="layer">Layer to get</param>
        /// <returns>The requested layer</returns>
        public static Layer GetLayer(Layers layer) => layers[(int)layer];

        /// <summary>
        /// Gets the Layer associated with a specified layer value
        /// </summary>
        /// <param name="value">Value of the layer to get</param>
        /// <returns>The layer of the given value</returns>
        /// <exception cref="ArgumentOutOfRangeException">If <paramref name="value"/> is less than 0 or greater than 31</exception>
        public static Layer GetLayer(int value)
        {
            //Check range
            if (value > 31 || value < 0) { throw new ArgumentOutOfRangeException(nameof(value), value, "Layer number must be between 0 and 31 inclusively"); }

            //Return the corresponding layer
            return layers[value];
        }

        /// <summary>
        /// Gets a layer by it's name
        /// </summary>
        /// <param name="name">Name of the layer to get</param>
        /// <returns>The layer with the matching name</returns>
        /// <exception cref="KeyNotFoundException">If <paramref name="name"/> is not a valid layer name</exception>
        public static Layer GetLayer(string name) => layerNames[name];

        /// <summary>
        /// Tries to get a layer by it's name
        /// </summary>
        /// <param name="name">Name of the layer to get</param>
        /// <param name="layer">Found layer if any</param>
        /// <returns>True if the layer was found, false otherwise</returns>
        public static bool TryGetLayer(string name, out Layer layer) => layerNames.TryGetValue(name, out layer);

        /// <summary>
        /// Creates a cumulative LayerMask from the specified layers
        /// </summary>
        /// <param name="layers">Layers to create the mask from</param>
        /// <returns>The resulting LayerMask</returns>
        public static LayerMask GetMask(params Layers[] layers)
        {
            //If no layers passed, return -1
            if (layers.Length == 0) { return -1; }

            //Get the cumulative mask of all passed layers
            LayerMask mask = GetLayer(layers[0]);
            for (int i = 1; i < layers.Length; i++)
            {
                mask |= GetLayer(layers[i]);
            }

            //Return the resulting mask
            return mask;
        }
        #endregion
    }
}