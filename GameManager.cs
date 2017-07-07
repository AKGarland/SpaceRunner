using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public Scores scores;
    public bool gameWon = false;
    public static bool gameLost = false;
    public Player player;
    public float killCount;         // Written in Enemy.Update() on enemy death
    public float timeOfLatestSpawn; // Times written in Player.Start() & Respawn()
    public float timeHeliCalled;    // Written in Helicopter.OnDispatchHelicopter() 
    public float timeScore;
    public float killScore;
    public float healthScore;
    public float score;

    private bool set = false;

    void Update () {
        if ((gameWon == true) && (set == false))
        {
            GameWonScore( );
            scores.SetScore( );
            set = true;
        }

        if (gameLost == true)
        {
            player.Respawn( );
        }
	}

   public void GameWonScore( )
    {
        float timeUntilCall = timeHeliCalled - timeOfLatestSpawn;

        timeScore = ((1/timeUntilCall)*1000f);
        killScore = (killCount * 567f);
        healthScore = player.health * 677;
        score = timeScore + killScore + healthScore;
    }
}
