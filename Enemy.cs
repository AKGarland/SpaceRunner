using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    private float health = 60f;
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

    void OnTriggerEnter2D(Collider2D collider)
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
