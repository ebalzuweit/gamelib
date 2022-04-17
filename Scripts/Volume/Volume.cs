
using UnityEngine;

public abstract class Volume : MonoBehaviour
{
    [SerializeField] private Vector3 _size = Vector3.one;

    public Vector3 GetRandomPosition()
    {
        return transform.position + new Vector3(
            Random.Range(-_size.x * 0.5f, _size.x * 0.5f),
            Random.Range(-_size.y * 0.5f, _size.y * 0.5f),
            Random.Range(-_size.z * 0.5f, _size.z * 0.5f)
        );
    }

    protected virtual void OnDrawGizmos()
    {
        var color = Color.yellow;
        color.a = 0.4f;
        Gizmos.color = color;
        Gizmos.DrawCube(transform.position, _size);
    }

    protected virtual void OnValidate()
    {
        _size.x = Mathf.Max(0f, _size.x);
        _size.y = Mathf.Max(0f, _size.y);
        _size.z = Mathf.Max(0f, _size.z);
    }
}