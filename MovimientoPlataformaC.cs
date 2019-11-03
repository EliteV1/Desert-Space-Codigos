using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoPlataformaC : MonoBehaviour
{
    public Transform centro;
    private float xo, yo, x, y, r, angulo, tiempo;
    // Start is called before the first frame update
    void Start()
    {
        r = 3f;
        angulo = Mathf.PI / 4;
        xo = centro.transform.position.x;
        yo = centro.transform.position.y;
        tiempo = 0f;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (tiempo >= 0.1f)
        {
            x = xo + r * Mathf.Cos(angulo);
            y = yo + r * Mathf.Sin(angulo);
            angulo = (angulo - Mathf.PI / 32) % (2 * Mathf.PI);
            transform.localPosition = new Vector2(x, y);
            tiempo = 0.075f;
        }
        else
        {
            tiempo += Time.deltaTime;
        }
    }
}