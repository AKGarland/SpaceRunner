using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helicopter : MonoBehaviour {
    public AudioClip heliAudio;

    private AudioSource audioSource;
    private bool called = false;

    // Use this for initialization
    void Start () {
        audioSource = GetComponent<AudioSource>( );
    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetButtonDown("CallHeli") && !called)
        {
            called = true;
            CallHeli( );
        }
    }

    void CallHeli( )
    {
        audioSource.clip = heliAudio;
        audioSource.Play( );
    }
}
