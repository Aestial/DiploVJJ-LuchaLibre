using UnityEngine;

namespace Lucha.Camera
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField] private Transform target;
        [SerializeField] private Vector3 offset = new(0, 2, -5);
        [SerializeField] private float smoothSpeed = 0.125f;

        private void LateUpdate()
        {
            if (target) return;
            
            var desiredPosition = target.position + offset;
            var smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;
            transform.LookAt(target);
        }
    }
}