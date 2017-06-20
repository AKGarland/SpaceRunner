﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helicopter : MonoBehaviour {
    //public AudioClip heliAudio;

    private AudioSource audioSource;
    // Use this for initialization
    void Start () {
        audioSource = GetComponent<AudioSource>( );
    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetButtonDown("CallHeli"))
        {
            CallHeli( );
        }
    }

    void CallHeli( )
    {
        audioSource.Play( );
    }
}