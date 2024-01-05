using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapCamera : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform player;

    public void LateUpdate()
    {
        Vector3 newPosition = player.position;
        newPosition.y = transform.position.y; //Transformamos la y de la camara en la del jugador
        transform.position = newPosition;

    }
}
