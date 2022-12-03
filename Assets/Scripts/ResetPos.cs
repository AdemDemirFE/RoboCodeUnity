using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPos : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ResetPosition() {
        DeleteSelected.SelectedOject = null;
        TimerSet.SelectedObject = null;
        TimerSet.instance.HideTimerFeatures();
        PickPoint.pickPoint.transform.position = PickPoint.startPosition;
    }
}
