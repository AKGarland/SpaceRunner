using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helicopter : MonoBehaviour {
    public float heliSpeed = 50f;
    public bool called = false;

    private GameObject landingArea;
    private Rigidbody rigidBody;
    private Transform destinationTransform;
    private bool arrived = false;
    private GameManager gameManager;

    // Use this for initialization
    void Start ()
    {
        rigidBody = GetComponent<Rigidbody>( );
        gameManager = FindObjectOfType<GameManager>( );
    }

    private void Update( )
    {
        if (landingArea)
        {
            if (arrived == true)
            {
                rigidBody.velocity = new Vector3(0, 0, 0);
                rigidBody.AddForce(Vector3.down*750f, ForceMode.Acceleration);
                if (transform.position.y <= 55)
                {
                    rigidBody.isKinematic = true;
                }
            }
        }
    }

    public void SetDestination(Transform target, float distanceToStop, float speed)
    {
        if (Vector3.Distance(transform.position, target.position) > distanceToStop)
        {
            transform.LookAt(target);           // Rotates to face landing area so only forward motion is required
            rigidBody.AddForce(transform.forward * speed, ForceMode.Acceleration);
        }
    }

    public void OnDispatchHelicopter( )
    {
        if (called == false)
        {
            landingArea = GameObject.FindGameObjectWithTag("LandingArea");
            SetDestination(landingArea.transform, 0, heliSpeed);
            gameManager.timeHeliCalled = Time.time;
            print(landingArea.transform.position + " landingArea position.");
            called = true;
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("LandingArea") == true)
        {
            arrived = true;
        }
        if (collider.CompareTag("Player") == true)
        {
            rigidBody.isKinematic = false;
            rigidBody.AddForce(Vector3.up * 750f, ForceMode.Acceleration);
            GameManager.gameWon = true;
        }
    }
}
