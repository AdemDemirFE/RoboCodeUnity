using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickPoint : MonoBehaviour {
    public static GameObject pickPoint;
    public GameObject myPoint;
    public static Vector3 startPosition;
    // Use this for initialization
    void Awake () {
        pickPoint = myPoint;
        startPosition = pickPoint.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
