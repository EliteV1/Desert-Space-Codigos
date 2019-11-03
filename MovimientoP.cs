using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoP : MonoBehaviour
{
    public GameObject plataforma;        //Variables publicas donde se colocaran los GameObjects
    public Transform Posicion_Inical;
    public Transform Posicion_Final;
    private Transform Posicion_siguiente;
    public float velocidad;              //Variable publica que determina la velocidad del movimiento de la plataforma

    void Start()
    {
        Posicion_siguiente = Posicion_Final;    //Inicio del movimiento
        
    }

    // Update is called once per frame
    void Update()
    {  //Con este codigo se determina el movimiento de la plataforma en un vector2 (al solo moverse en dos ejes)
        plataforma.transform.position = Vector2.MoveTowards(plataforma.transform.position, Posicion_siguiente.position, Time.deltaTime * velocidad);


            if(plataforma.transform.position == Posicion_siguiente.position) //Condicional para que vuelva a moverse
            {
            Posicion_siguiente = Posicion_siguiente == Posicion_Final ? Posicion_Inical : Posicion_Final;
            }

        
    }
}
