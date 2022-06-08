using UnityEngine;

namespace gamelib
{
    public class BillboardSprite : MonoBehaviour
    {
        [SerializeField, Tooltip("If True, object's rotation will match the camera's rotation. Will rotate to face the camera if False.")]
        private bool useStaticBillboard;

        private Camera _camera;

        private void Awake()
        {
            _camera = Camera.main;
        }

        private void LateUpdate()
        {
            if (useStaticBillboard)
            {
                transform.rotation = _camera.transform.rotation;
            }
            else
            {
                transform.LookAt(_camera.transform);
            }

            transform.rotation = Quaternion.Euler(0f, transform.rotation.eulerAngles.y, 0f);
        }
    }
}
