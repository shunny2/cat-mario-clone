using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float Speed;
    public float JumpForce;

    public bool isJumping;
    public bool doubleJumping;

    private Rigidbody2D rig;
    private Animator anim;
    private bool isBlowing;

    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>(); //rig recebe o componente rigibody q estiver anexado neste script
        anim = GetComponent<Animator>(); // anim recebe o componente animator do meu objeto
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
    }

    void Move()
    {
        //Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);

        //move o personagem em uma posição
        //transform.position += movement * Time.deltaTime * Speed; //passando pro personagem as posições

        float movement = Input.GetAxis("Horizontal"); //pegando a posiçao direita ou esqerda (1,-1)
        rig.velocity = new Vector2(movement * Speed, rig.velocity.y);

        if(movement > 0f)
        {
            anim.SetBool("walk", true);
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
        }

        if(movement < 0f)
        {
            anim.SetBool("walk", true);
            transform.eulerAngles = new Vector3(0f, 180f, 0f);
        }

        if(movement == 0f)
        {
            anim.SetBool("walk", false);
        }
    }

    void Jump()
    {
        if(Input.GetButtonDown("Jump") && !isBlowing) //se a tecla space for pressionada e o personagem estiver no chao(jump = false)
        {
            if(!isJumping) {
                rig.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse); //Adiciona uma força na posição Y
                doubleJumping = true; // então ele pode dar um pulo duplo
                anim.SetBool("jump", true);
            }else 
            {
                if(doubleJumping) //se for verdade
                {
                    rig.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse); //pula
                    doubleJumping = false;
                }
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision) //Detecta toda vez que o personagem toca em alguma coisa
    {
        if(collision.gameObject.layer == 8)
        {
            isJumping = false;
            anim.SetBool("jump", false);
        }

        if(collision.gameObject.tag == "Damage")
        {
            GameController.instance.ShowGameOver();
            Destroy(gameObject); //destruindo personagem
        }
    }

    void OnCollisionExit2D(Collision2D collision)  //é chamado quando personagem para de toca em alguma coisa
    {
        if(collision.gameObject.layer == 8) 
        {
            isJumping = true;
        }
    }

    void OnTriggerStay2D(Collider2D collider) //é chamado quando o objeto esta em constante colisao.
    {
        if(collider.gameObject.layer == 11)
        {
            isBlowing = true; //se colidir os isblowing é verdadeiro
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if(collider.gameObject.layer == 11) 
        {
            isBlowing = false; //se parar de colidir entao o isblowing volta a ser falso
        }
    }

}