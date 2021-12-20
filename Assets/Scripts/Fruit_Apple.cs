using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit_Apple : MonoBehaviour
{
    private SpriteRenderer sr;
    private CircleCollider2D circle;

    public GameObject collected;
    public int Score;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        circle = GetComponent<CircleCollider2D>();
    }

    void OnTriggerEnter2D(Collider2D collider) //metodo ultilizado em objetos estaticos cujo a opção trigger esta ativa
    {
        if(collider.gameObject.tag == "Player") //checa se a maçã bateu em algo
        {
            sr.enabled = false;
            circle.enabled = false;
            collected.SetActive(true);

            //GameController.instance.totalScore += Score; //Acessando a classe gameController e somando o total com o score
            GameController.instance.UpdateScoreText(Score);
            
            Destroy(gameObject, 0.25f); //destruindo a propria maçã dps de 0.25 segundos
        }
    }
}
