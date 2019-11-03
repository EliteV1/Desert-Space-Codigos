using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Linea : MonoBehaviour
{
    public Transform from;
    public Transform to;

    private void OnDrawGizmos()
    {
        if (from != null && to != null)
        {
            Gizmos.color = Color.cyan;
            Gizmos.DrawLine(from.position, to.position);
            Gizmos.DrawSphere(from.position, 0.15f);
            Gizmos.DrawSphere(to.position, 0.15f);
        }
    }
    private void OnTriggerEnter2D(Collider2D col)

    {
        if (col.gameObject.tag == "Player")
        {
            
                Destroy(gameObject);


           
        }

        
    }

}
