using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteSelected : MonoBehaviour {

    public static GameObject SelectedOject;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void DeleteObject() {
        if(SelectedOject != null) {
            Destroy(SelectedOject);
            TimerSet.SelectedObject = null;
            PickPoint.pickPoint.transform.position= PickPoint.startPosition;
        }    
    }
}
