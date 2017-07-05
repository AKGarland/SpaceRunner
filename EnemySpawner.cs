using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    public GameObject enemyPrefab;
    public Helicopter heli;
    public float spawnDelay = 0.5f;

    private bool initialSpawn = false;

	// Update is called once per frame
	void Update () {
        if ((heli.called == true) && (!initialSpawn))
        {
            SpawnUntilFull( );  // the maximum number of enemies on scene at the same time is equal to the number of spawn points. 
            initialSpawn = true;
        }

        if (AllMembersDead( ))
        {
            SpawnUntilFull( );
            Debug.Log("Empty Formation");
        }
    }

    void Spawn( )
    {
        foreach (Transform child in transform)
        {
            GameObject enemy = Instantiate(enemyPrefab, child.transform.position, Quaternion.identity) as GameObject;
            enemy.transform.parent = child;
        }
    }

    void SpawnUntilFull( )
    {
        Transform freePosition = NextFreePosition( );
        if (freePosition)
        {
            GameObject enemy = Instantiate(enemyPrefab, freePosition.position, Quaternion.identity) as GameObject;
            enemy.transform.parent = freePosition;
        }
        if (NextFreePosition( ))
        {
            Invoke("SpawnUntilFull", spawnDelay);
        }
    }

    Transform NextFreePosition( )
    {
        foreach (Transform childPositionGameObject in transform)
        {
            if (childPositionGameObject.childCount == 0)
            {
                return childPositionGameObject;
            }
        }
        return null;
    }

    bool AllMembersDead( )
    {
        foreach (Transform childPositionGameObject in transform)
        {
            if (childPositionGameObject.childCount > 0)
            {
                return false;
            }
        }
        return true;
    }
}
