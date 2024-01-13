using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snow : MonoBehaviour
{
    public float upForce = 0.5f;
    //public float sideForce = .1f;
    public void Start()
    {
        float xForce = Random.Range(-upForce, upForce);
        float yForce = Random.Range(upForce / 2f, upForce);
        float zForce = Random.Range(-upForce, upForce);
        Vector3 force= new Vector3(xForce , yForce, zForce);

        GetComponent<Rigidbody>().velocity = force;
    }
}
