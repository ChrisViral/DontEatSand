namespace DontEatSand.Entities
{
    /// <summary>
    /// Screen selectable object
    /// </summary>
    public interface ISelectable
    {
        #region Propeties
        /// <summary>
        /// If this selectable object is currently selected
        /// </summary>
        bool IsSelected { get; set; }

        /// <summary>
        /// If this selectable unit is currently being hovered
        /// </summary>
        bool IsHovered { get; set; }

        /// <summary>
        /// Info related to this selectable unit
        /// </summary>
        UnitInfo Info { get; }
        #endregion
    }
}
