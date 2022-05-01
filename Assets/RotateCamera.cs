using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    [SerializeField] private float _speedRotate;

    private void Update()
    {
        transform.Rotate(-Vector3.forward * _speedRotate * Time.deltaTime);
    }
}
