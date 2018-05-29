using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private Transform _girl;
    [SerializeField]
    private float _startPositionY; 

    void Update()
    {
        if ((transform.position.y + _startPositionY) < _girl.position.y)
        {
            transform.position = new Vector3 (0f, _startPositionY + _girl.position.y, -10f);
        }
    }
}
