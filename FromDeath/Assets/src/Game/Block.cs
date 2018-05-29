using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour {

    public float _levelComplexity = 20f; 

    private void Awake()
    {
        transform.localScale = new Vector3(7f + Random.value * _levelComplexity, 2f, 1f); 
    }

    public void SetComplexity(float complexity)
    {
        transform.localScale = new Vector3(7f + Random.value * complexity, 2f, 1f);
    }
}
