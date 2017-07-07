using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scores : MonoBehaviour {

    public Text scoreText;

    private GameManager gameManager;  

	void Start ()
    {
        gameObject.SetActive(false);
        gameManager = FindObjectOfType<GameManager>( );
	}
	
	void Update ()
    {
        if (gameManager.gameWon==true)
        {
            SetScore( );
        }
	}

    public void SetScore( )
    {
        gameObject.SetActive(true);
        this.gameObject.SetActive(true);
        scoreText.text = gameManager.score.ToString( );
        print("Score set");
    }
}
