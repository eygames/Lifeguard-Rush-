using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeEfekt : MonoBehaviour
{
    ParticleSystem _system;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, 1.5f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {

       // transform.position += new Vector3(0, 0, 1);
    }
}
