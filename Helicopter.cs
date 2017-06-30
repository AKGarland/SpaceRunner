using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helicopter : MonoBehaviour {
    public float heliSpeed = 50f;

    private Rigidbody rigidBody;
    private bool called = false;

    // Use this for initialization
    void Start () {
        rigidBody = GetComponent<Rigidbody>( );
    }
	
    public void OnDispatchHelicopter( )
    {
        called = true;
        rigidBody.velocity = new Vector3(0, 0, heliSpeed);
    }
}
