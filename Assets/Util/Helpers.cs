using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public static class Helpers
{
    private static readonly Dictionary<float, WaitForSeconds> _waitDictionary = new Dictionary<float, WaitForSeconds>();

    /// <summary>
    /// Get a cached instance of <see cref="WaitForSeconds"/>, or create if not exists.
    /// </summary>
    /// <param name="time">The time to wait.</param>
    /// <returns></returns>
    public static WaitForSeconds GetWait(float time)
    {
        if (_waitDictionary.TryGetValue(time, out var wait)) return wait;

        _waitDictionary[time] = new WaitForSeconds(time);
        return _waitDictionary[time];
    }

    private static PointerEventData _eventDataCurrentPosition;
    private static List<RaycastResult> _results;

    /// <summary>
    /// Returns true if the pointer is over a UI element.
    /// </summary>
    /// <returns></returns>
    public static bool IsOverUI()
    {
        _eventDataCurrentPosition = new PointerEventData(EventSystem.current) { position = Input.mousePosition };
        _results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(_eventDataCurrentPosition, _results);
        return _results.Count > 0;
    }

    /// <summary>
    /// Get the world position of a UI element.
    /// </summary>
    /// <param name="element"></param>
    /// <returns></returns>
    public static Vector3 GetWorldPositionOfCanvasElement(RectTransform element)
    {
        RectTransformUtility.ScreenPointToWorldPointInRectangle(element, element.position, Camera.main, out var result);
        return result;
    }
}