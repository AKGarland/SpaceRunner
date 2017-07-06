using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static bool gameWon = false;
    public static bool gameLost = false;
    public Player player;
    public float killCount;         // Written in Enemy.Update() on enemy death
    public float timeOfLatestSpawn; // Times written in Player.Start() & Respawn()
    public float timeHeliCalled;    // Written in Helicopter.OnDispatchHelicopter() 
    public float timeScore;
    public float killScore;
    public float healthScore;
    public float score;
	
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

    void GameWonScore( )
    {
        float timeUntilCall = timeHeliCalled - timeOfLatestSpawn;

        timeScore = ((1/timeUntilCall)*1000f);
        killScore = (killCount * 567f);
        healthScore = player.health * 677;
        score = timeScore + killScore + healthScore;
    }
}
