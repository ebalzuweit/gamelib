using UnityEngine;

namespace gamelib
{
    public static class TransformExtensions
    {
        /// <summary>
        /// Destroy all child objects of this transform.
        /// </summary>
        /// <param name="t"></param>
        public static void DestroyChildren(this Transform t)
        {
            for (int i = t.childCount; i >= 0; i--)
            {
                Object.Destroy(t.GetChild(i));
            }
        }
    }
}