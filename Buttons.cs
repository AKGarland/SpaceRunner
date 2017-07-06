using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Buttons : MonoBehaviour {

    public GameObject heliButton;
    public ClearArea clearArea;

	// Use this for initialization
	void Start () {
        heliButton.GetComponent<RawImage>( ).color = new Color(.2f, .2f, .2f, .6f);
    }
	
	// Update is called once per frame
	void Update () {
        if(clearArea.areaClear == true){
            heliButton.GetComponent<RawImage>( ).color = new Color(0f, 0f, 0f, 0f);
        }
	}

    public void HeliCallPossible( )
    {
        heliButton.GetComponent<RawImage>( ).color = new Color(1f, 1f, 1f, 1f);
    }
}
