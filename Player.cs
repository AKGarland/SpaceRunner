using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public GameObject playerSpawn;
    public bool reSpawn = false;

    private Transform[] spawns;
    private Vector3 randomSpawn;

	// Use this for initialization
	void Start () {
        spawns = playerSpawn.GetComponentsInChildren<Transform>( );

    }
	
	// Update is called once per frame
	void Update () {
        if (reSpawn == true)
        {
            Respawn( );
        }
    }

    void Respawn( )
    {
        randomSpawn = spawns[Random.Range(1, (spawns.Length))].transform.position;
        transform.position = randomSpawn;
        reSpawn = false;
    }
}
