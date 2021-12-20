using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampoline : MonoBehaviour
{
    public float jumpForce;

    private Animator anim;

    void Start() {
        anim = GetComponent<Animator>(); //anim recebe o componente animator
    }

    void OnCollisionEnter2D(Collision2D collision) //variavel collision pega o objeto de colisao. no caso retorna o proprio personagem.
    {
        if(collision.gameObject.tag == "Player")
        {
            anim.SetTrigger("jump");
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse); //Adicionando uma força no personagem.
        }
    }
}
