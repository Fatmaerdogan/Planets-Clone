using UnityEngine;

public class Rotat : MonoBehaviour
{
    [SerializeField] private float _rotateSpeed;
    [SerializeField] private Transform _rotateTransform;

    private void FixedUpdate()
    {
        _rotateTransform.Rotate(0, 0, _rotateSpeed * Time.fixedDeltaTime);
    }
}
