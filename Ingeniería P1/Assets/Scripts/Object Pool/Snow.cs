using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snow : MonoBehaviour
{
    public float snowSpeed = 1f;
    public void Start()
    {
        float yForce = Random.Range(snowSpeed / 2f, snowSpeed);

        Vector3 force= new Vector3(0,yForce, 0);

        GetComponent<Rigidbody>().velocity = force;
    }
}
