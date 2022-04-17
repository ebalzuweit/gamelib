using UnityEngine;

namespace com.ebalzuweit.gamelib
{
    /// <summary>
    /// Extension and static methods for Unity Vector classes.
    /// </summary>
    public static class VectorExtensions
    {
        /// <summary>
        /// Add two vectors component-wise.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns>A new <see cref="Vector3"/></returns>
        public static Vector3 ComponentAdd(Vector3 a, Vector3 b)
        {
            return new Vector3(a.x + b.x, a.y + b.y, a.z + b.z);
        }

        /// <summary>
        /// Add two vectors component-wise.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns>A new <see cref="Vector2"/></returns>
        public static Vector2 ComponentAdd(Vector2 a, Vector2 b)
        {
            return new Vector2(a.x + b.x, a.y + b.y);
        }

        /// <summary>
        /// Add two vectors component-wise.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns>A new <see cref="Vector3Int"/></returns>
        public static Vector3Int ComponentAdd(Vector3Int a, Vector3Int b)
        {
            return new Vector3Int(a.x + b.x, a.y + b.y, a.z + b.z);
        }

        /// <summary>
        /// Add two vectors component-wise.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns>A new <see cref="Vector2Int"/></returns>
        public static Vector2Int ComponentAdd(Vector2Int a, Vector2Int b)
        {
            return new Vector2Int(a.x + b.x, a.y + b.y);
        }
    }
}
