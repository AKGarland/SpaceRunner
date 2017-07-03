using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public GameObject playerSpawn;
    public GameObject landingArea;
    public GameObject heliCamera;

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

        if (GameManager.gameWon == true)
        {
            heliCamera.SetActive(true);
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
        Instantiate(landingArea, (transform.position + new Vector3 (0,450,0)), transform.rotation);
    }
}
