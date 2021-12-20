using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    public float fallingTime;

    private TargetJoint2D target;
    private BoxCollider2D boxColl;

    // Start is called before the first frame update
    void Start()
    {
        target = GetComponent<TargetJoint2D>();
        boxColl = GetComponent<BoxCollider2D>();
    }

    void OnCollisionEnter2D(Collision2D collision) //Detecta toda vez que o personagem toca em alguma coisa
    {
        if(collision.gameObject.tag == "Player")
        {
            Invoke("Falling", fallingTime); //invoca outros metodos baseado no tempo
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.layer == 9) //se bater em algum objeto que seja trigger ela e destruida
        {
            Destroy(gameObject);
        }
    }

    void Falling()
    {
        target.enabled = false; //desabilita o target
        boxColl.isTrigger = true; //habilita o isTrigger
    }
}
