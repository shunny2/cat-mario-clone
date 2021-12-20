using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    public float jumpForce;
    public bool isUp;
    public int health = 5;

    public Animator anim; //tornando publico e referenciando para o objeto pai
    public GameObject effect;

    void FixedUpdate() 
    {
        if(health <= 0)
        {
            //destroi a caixa
            Instantiate(effect, transform.position, transform.rotation); //criando um efeito na posiçao atual da caixa
            Destroy(transform.parent.gameObject); //destroy o objeto pai
        }
    }

    void OnCollisionEnter2D(Collision2D collision) 
    {
        if(collision.gameObject.tag == "Player")
        {
            if(isUp) //se for true, eu arremesso de baixo para cima
            {
                anim.SetTrigger("hit"); //ativando a animação
                health--;
                collision.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            }else //se nao arremessa, pra baixo
            {
                anim.SetTrigger("hit");
                health--;
                collision.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, -jumpForce), ForceMode2D.Impulse);
            }
        }
    }
}
