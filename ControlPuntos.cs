using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlPuntos : MonoBehaviour
{
    public static int Score = 0;
    public string ScoreString = "Energia:";

    public Text TextScore;

    public static ControlPuntos Gamecontroller;


    void Awake()
    {
        Gamecontroller = this;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (TextScore != null )
        {
            TextScore.text = ScoreString + Score.ToString();
        }
    }
}
