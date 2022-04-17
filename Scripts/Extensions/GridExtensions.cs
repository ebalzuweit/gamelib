using UnityEngine;

namespace com.ebalzuweit.gamelib
{
    /// <summary>
    /// Extension methods for the Unity Grid class.
    /// </summary>
    public static class GridExtensions
    {
        /// <summary>
        /// Get the center of a cell in world coordinates.
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="cellPosition"></param>
        /// <returns>Cell center in world coordinates.</returns>
        public static Vector3 CellToWorldCenter(this Grid grid, Vector3Int cellPosition)
        {
            var worldPosition = grid.CellToWorld(cellPosition);
            return worldPosition + grid.cellSize / 2f;
        }
    }
}
