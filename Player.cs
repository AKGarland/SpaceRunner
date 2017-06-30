using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public GameObject playerSpawn;

    private Transform[] spawns;
    private Vector3 randomSpawn;
    private bool lastRespawnToggle = false;

    void Start () {
        spawns = playerSpawn.GetComponentsInChildren<Transform>( );
    }
	
	void Update () {
        if (lastRespawnToggle == true)
        {
            Respawn( );
        }
    }

    void Respawn( )
    {
        randomSpawn = spawns[Random.Range(1, (spawns.Length))].transform.position;
        transform.position = randomSpawn;
        lastRespawnToggle = false;
    }

    void OnFindClearArea( )
    {
        Invoke("DropFlare", 3f);
    }

    void DropFlare( )
    {
        //drop flare
    }
}
