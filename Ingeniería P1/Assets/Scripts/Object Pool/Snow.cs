using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snow : MonoBehaviour
{
    [SerializeField] private float snowSpeed = 5f;
    [SerializeField] private Rigidbody2D snowRb; 
    // Start is called before the first frame update

    private void OnEnable()
    {
        snowRb.velocity = Vector2.up * snowSpeed;
    }

    // Update is called once per frame
    private void OnCollisionEnter2D()
    {
        gameObject.SetActive(false);
    }
}
