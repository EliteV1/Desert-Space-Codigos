using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public int Puntaje = 1; 

    public float speed = 2f;      //Permite elegir la velocidad
    public float maxSpeed = 5f;   //Establece un valor maximo de velocidad
    public bool grounded;         // booleanos que permite muestra si se encuentra o no en "el suelo"
    public float jumpPower = 6.5f;//Permite elegir la distancia del salto

    private Rigidbody2D rb2d;
    private Animator anim;         //Permite la animacion
    private SpriteRenderer spr;
    private bool jump;
    private Vector2 pos_o;
    private bool movement = true;
    public const string MUERTE = "Muerte";
    private int vidas = 3;

    //Asigna o retorna las vidas del personaje
    public int Vidas
    {
        get
        {
            return vidas;
        }
        set
        {
            vidas = value;
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        pos_o = this.transform.position;
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetFloat("Speed", Mathf.Abs(rb2d.velocity.x));   //Determina si se encuentra o no en el suelo y permite o no realizar un salto
        anim.SetBool("Grounded", grounded);

        if (Input.GetKeyDown(KeyCode.UpArrow) && grounded)
        {
            jump = true;
        }
    }

    private void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        if (!movement) h = 0;

        rb2d.AddForce(Vector2.right * speed * h);                           //Determina las direcciones con respecto a la velocidad

       if (rb2d.velocity.x > maxSpeed)
        {
            rb2d.velocity = new Vector2(maxSpeed, rb2d.velocity.y);             
        }
        if (rb2d.velocity.x < -maxSpeed)
        {
            rb2d.velocity = new Vector2(-maxSpeed, rb2d.velocity.y);
        }

        if (h > 0.1f)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }

        if (h< -0.1f)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }

        if (jump)
        {
            rb2d.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);             //Determinar la distancia de salto 
            jump = false;
        }
        Debug.Log(rb2d.velocity.x);

    }


    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.CompareTag("PickUp"))      //Al colisionar con el objeto con dicha Tag este se desactivara 
        {

            other.gameObject.SetActive(false);
            ControlPuntos.Score += Puntaje;             //Al colisionar con este objeto tambien sumara +1 al puntaje
            
        }
      



    }
    public void EnemyKnockBack(float enemyPosX)
    {
        float side = Mathf.Sign(enemyPosX - transform.position.x);
        rb2d.AddForce(Vector2.left * side * jumpPower, ForceMode2D.Impulse);
        spr.color = Color.red;
        movement = false;
        
        
    }
    public void EnemyJumo()
    {
        jump = true;
    }

    private void OnCollisionEnter2D(Collision2D col)      //Al colisionar con:
    {
        if (col.transform.tag.Equals("Portal"))           //Al colisonar con el portal te lleva a la escena Lvl2
        {
            SceneManager.LoadScene("Lvl2");
        }

        if (col.transform.tag.Equals("Portal2"))         //Al colisionar con el portal te muestra la pantalla de Victoria
        {
            SceneManager.LoadScene("Victoria");
        }

        if (col.transform.tag.Equals("PlataformaMovil"))
        {
            transform.parent = col.transform;
        }
        else
        {
            transform.parent = null;
        }

        if (col.gameObject.tag.Equals("Enemigo"))      //Al colisionar con enemigo:
        
        {
            vidas -= 1;                                  //perder una vida
            Destroy(col.gameObject);
            spr.color = Color.red;

            Invoke("EnableMovement", 0.5f);
        }

        if (col.transform.tag.Equals(MUERTE))           //Al colisionar con Muerte:
        {
            if (--vidas > 0)                             //Restar vidas
            {
                this.transform.position = pos_o;
            }
            else
            {
                Debug.Log("F");
            }
        }
        if (vidas <= 0)                                             //Al perder toda la vida el jugador se destruye
        {
            gameObject.SetActive(false);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);  //Reinicia la Escena actual






        }
    }
    void EnableMovement()
    {
        spr.color = Color.white;
    }



}
