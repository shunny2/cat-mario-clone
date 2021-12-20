using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saw : MonoBehaviour
{
    public float speed;
    public float moveTime;
    private float timer;
    public bool dirRight = true;

    // Update is called once per frame
    void Update()
    {
        if(dirRight) //se verdadeiro
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime); //serra vai pra direita
        }else
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);  //serra vai pra esquerda
        }

        timer += Time.deltaTime;

        if(timer >= moveTime)
        {
            dirRight = !dirRight; //invete, o verdadeiro se torna falso.
            timer = 0f; //zera o contador
        }
    }
}
