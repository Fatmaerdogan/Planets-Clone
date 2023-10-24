using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    [SerializeField] private Transform _centerTranform;
    [SerializeField] private List<float> _spawnPosX;

    private void Awake()
    {
        transform.localPosition = Vector3.right * _spawnPosX[Random.Range(0,_spawnPosX.Count)];
        _centerTranform.rotation = Quaternion.Euler(0, 0, Random.Range(0, 37) * 10f);
    }

    public void DestroyCenterObject()
    {
        Destroy(_centerTranform.gameObject);
    }

}
