using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kameraTakip : MonoBehaviour
{
    private Transform lookAt;
    private Vector3 startOffset;
    void Start()
    {
        lookAt = GameObject.FindGameObjectWithTag("adam").transform;
        startOffset = transform.position - lookAt.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = lookAt.position + startOffset;
    }
}
