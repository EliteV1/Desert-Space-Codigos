using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hud : MonoBehaviour
{
    public PlayerController Player;
    public GameObject barra_vida;
    private Animator anim;
    public const string ESTADO_VIDAS="Vidas";
    void Start()
    {
        anim = barra_vida.GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        anim.SetInteger(ESTADO_VIDAS, Player.Vidas);
    }
}
