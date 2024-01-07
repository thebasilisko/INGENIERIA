using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snow : MonoBehaviour
{
    public float snowSpeed = 1f;
    public void Start()
    {
        float xForce = Random.Range(snowSpeed / 10f, 0);
        float yForce = Random.Range(snowSpeed / 10f, 10);
        float zForce = Random.Range(snowSpeed / 10f, 0);
        Vector3 force= new Vector3(xForce , yForce, zForce);

        GetComponent<Rigidbody>().velocity = force;
    }
}
