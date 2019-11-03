using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraS : MonoBehaviour
{
    public Transform jugador;
    public Vector3 desplazamiento;


    void Update()
    {
        transform.position = new Vector3(jugador.position.x + desplazamiento.x, jugador.position.y + desplazamiento.y, desplazamiento.z);

    }
}