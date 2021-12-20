using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    private int totalScore;

    //public int Score;
    public Text scoreText;
    public GameObject gameOver;
    //public GameObject continueGame;

    public static GameController instance; //variavel statica

    // Start is called before the first frame update
    void Start()
    {
        instance = this; //atribuindo a variavel statica o proprio script
        //totalScore = PlayerPrefs.GetInt("score"); //obtendo valor
        //scoreText.text = Score.ToString();
        //Debug.Log("Player.Prefs: "+PlayerPrefs.GetInt("score"));
    }

    public void Quit() 
    {
        Application.Quit();
    }

    public void UpdateScoreText(int score)
    {
        //totalScore += score; //valor armazenado recebe o valor da maça
        //PlayerPrefs.SetInt("score", totalScore); //guardando valor
        totalScore += score;
        scoreText.text = totalScore.ToString(); //atualiza o texto canvas para o totalscore
    }

    public void ShowGameOver()
    {
        gameOver.SetActive(true); //ativando a tela de GameOver pelo metodo setActive
    }

    public void RestartGame(string lvlName)
    {
        SceneManager.LoadScene(lvlName); //cria um campo no botao na unity para digitar o lvl que eu quero resetar.
    }

    /*public void ShowScreenContinueGame()
    {
        continueGame.SetActive(true);
    }*/
}
