using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyButton : MonoBehaviour
{
    private Button button;

    //Referencia al objeto.
    private GameManager gameManager;

    //Variable para la dificultad
    public int difficulty;

    // Start is called before the first frame update
    void Start()
    {

        button = GetComponent<Button>();
        button.onClick.AddListener(SetDifficulty);

        //Inicializando objeto
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    void SetDifficulty()
    {
        gameManager.StartGame(difficulty);
        Debug.Log(gameObject.name + " was clicked");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
