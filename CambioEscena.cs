using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CambioEscena : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Iniciar()
    {
        Application.LoadLevel("Lvl1");

    }

    public void salir()
    {
        Application.LoadLevel("Inicio");

    }

}
