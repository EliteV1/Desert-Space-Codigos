using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara : MonoBehaviour
{
    public Transform Player;
    public Vector3 desplazamiento;

    void Start()
    {
        
    }

    
    void FixedUpdate()
    {
        transform.position = new Vector3(Player.position.x + desplazamiento.x, Player.position.y + desplazamiento.y, desplazamiento.z);

    }
}
