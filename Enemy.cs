using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public float health = 20f;  // public for testing as bullet velocity may need optimising

    private GameManager gameManager;

    private void Start( )
    {
        gameManager = FindObjectOfType<GameManager>( );
    }

    // Update is called once per frame
    void Update () {
        if (health <= 0f)
        {
            gameManager.killCount++;
            Destroy(gameObject);
        }
	}

    void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Laser"))
        {
            health -= 20f;
        }

        if (collider.CompareTag("Player"))
        {
            // Something that prevents it from "biting" every frame!
        }
    }
}
