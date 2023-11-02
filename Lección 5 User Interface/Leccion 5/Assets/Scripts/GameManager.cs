using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;

    //Variable para el spawn
    private float spawnRate = 1.0f;

    //Variable del texto
    public TextMeshProUGUI scoreText;
    private int score;
    //Texto de gameOver
    public TextMeshProUGUI gameOverText;

    //Variable para el juego.
    public bool isGameActive;

    //Boton para reiniciar.
    public Button restartButton;

    //Variable de los titulos.
    public GameObject titleScreen;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    //Funcion para iniciar el videojuego.
    public void StartGame(int difficulty)
    {
        spawnRate /= difficulty;
        isGameActive = true;
        StartCoroutine(SpawnTarget());
        UpdateScore(0);
        titleScreen.SetActive(false);
        //Inicializando la vaiable del juego.
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }

    //Funcion de gameOver
    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        //Deteniendo el juego.
        isGameActive = false;

    }

    IEnumerator SpawnTarget()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
            //UpdateScore(5);
        }
    }

    //Metodo para reiniciar el juego.
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
