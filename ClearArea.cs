using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClearArea : MonoBehaviour {

    public bool areaClear = false;
    public float timeSinceLastTrigger = 0f;
    public Buttons buttons;

    void Update () {
        timeSinceLastTrigger += Time.deltaTime;

        if ((timeSinceLastTrigger > 1f) && (areaClear == false) && (Time.timeSinceLevelLoad > 10f))
        {
            buttons.HeliCallPossible( );
            if ((Input.GetKeyDown(KeyCode.H)) && (areaClear == false))
            {
                areaClear = true;
                SendMessageUpwards("OnFindClearArea");
            }
        }
	}

    private void OnTriggerStay(Collider collider)
    {
        if (collider.tag != "Player")
        {
            timeSinceLastTrigger = 0f;
        }
    }

}
