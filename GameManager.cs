using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static bool gameWon = false;
    public static bool gameLost = false;
    public Player player;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (gameWon == true)
        {
            // You Won/Timer flashes
            // Call ScoreScreenLoad once
        }

        if (gameLost == true)
        {
            player.Respawn( );
        }
	}
}
