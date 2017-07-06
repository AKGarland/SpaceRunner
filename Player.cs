using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public GameObject playerSpawn;
    public GameObject landingArea;
    public Transform gunBarrel;  // The gun barrel is an empty object positioned at the tip of the weapon object so only the transform is required
    public GameObject projectile;  // Prefab of the laser itself to instantiate later
    public float health = 200;

    private float projectileSpeed = 10000f;
    private float firingRate = 0.2f;
    private Transform[] spawns;
    private GameManager gameManager;
    private Vector3 randomSpawn;
    private bool lastRespawnToggle = false;

    void Start () {
        spawns = playerSpawn.GetComponentsInChildren<Transform>( );
        gameManager = FindObjectOfType<GameManager>( );
        gameManager.timeOfLatestSpawn = Time.time;
    }
	
	void Update () {
        if (lastRespawnToggle == true)
        {
            Respawn( );
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            InvokeRepeating("Fire", 0.00001f, firingRate);
        }
        if (Input.GetKeyUp(KeyCode.Q))
        {
            CancelInvoke("Fire");
        }

        if (health <=0f)
        {
            GameManager.gameLost = true;
        }
    }

    public void Respawn( )
    {
        randomSpawn = spawns[Random.Range(1, (spawns.Length))].transform.position;
        transform.position = randomSpawn;
        gameManager.timeOfLatestSpawn = Time.time;
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

    void Fire( )
    {
        GameObject projectilePrefab = Instantiate(projectile, gunBarrel.position, gunBarrel.rotation) as GameObject;
        Rigidbody projectileRigidbody = projectilePrefab.GetComponent<Rigidbody>( );
        projectileRigidbody.AddForce(gunBarrel.transform.forward * projectileSpeed * Time.deltaTime, ForceMode.Acceleration);
        GetComponent<AudioSource>( ).Play( );
        Destroy(projectilePrefab, 5f);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Enemy"))
        {
            health -= 20f;
        }
    }
}
