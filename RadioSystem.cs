using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadioSystem : MonoBehaviour
{
    public AudioClip heliCall, callReply;

    private AudioSource audioSource;

    // Use this for initialization
    void Start( )
    {
        audioSource = GetComponent<AudioSource>( );
    }

    void OnMakeInitialHeliCall( )
    {
        audioSource.clip = heliCall;
        audioSource.Play( );
        Invoke("CallReply", heliCall.length + 1f);  // waits one second after audio clip finishes before playing next & calling helicopter
    }

    void CallReply( )
    {
        audioSource.clip = callReply;
        audioSource.Play( );
        BroadcastMessage("OnDispatchHelicopter");
    }
}
