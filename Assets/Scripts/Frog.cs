using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frog : MonoBehaviour
{
    private Rigidbody2D rig;
    private Animator anim;

    private bool colliding;

    public float Speed;

    public Transform rightCol;
    public Transform leftCol;

    public Transform headPoint;

    public LayerMask layer;

    public BoxCollider2D box;
    public CircleCollider2D circle;

    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //movimentacao do inimigo
        rig.velocity = new Vector2(Speed, rig.velocity.y); //velocity adiciona velocidade a um corpo(no caso esta passando o proprio eixo y para ele n se movimentar para cima nem pra baixo)

        colliding = Physics2D.Linecast(rightCol.position, leftCol.position, layer); //desenha uma linha de colisao invisivel em duas posições de uma cena.

        if(colliding)
        {
            transform.localScale = new Vector2(transform.localScale.x * -1f, transform.localScale.y); //rotacionando o exio X do personagem
            Speed *= -1f; //inverte o speed de positivo para negativo(1,-1).
        }
    }
    bool playerDestroyed;
    void OnCollisionEnter2D(Collision2D collision) 
    {
        if(collision.gameObject.tag == "Player")
        {
            float height = collision.contacts[0].point.y - headPoint.position.y; //Checando se o personagem entra em contato com a cabeça do inimigo.
            if(height > 0 && !playerDestroyed) //se o valor for maior q 0 e o player nao estiver destruido.
            {
                collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 10, ForceMode2D.Impulse); //da um pulo pra cima.
                Speed = 0; //travando a movimentação do sapo
                anim.SetTrigger("die");
                box.enabled = false; // desativando colisao do sapo
                circle.enabled = false; // desativando colisao do sapo
                rig.bodyType = RigidbodyType2D.Kinematic; //desabilita a fisica para o inimigo nao cair.
                Destroy(gameObject, 0.33f);
            }
            else // se não tocar a cabeça o personagem morre.
            {
                Debug.Log("Entrou");
                playerDestroyed = true;
                GameController.instance.ShowGameOver();
                Destroy(collision.gameObject);
            }
        }
    }

}
