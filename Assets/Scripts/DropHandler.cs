using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class DropHandler : MonoBehaviour , IDropHandler{
    //public GameObject item {
    //    get {
    //        if(transform.childCount > 0) {
    //            return transform.GetChild(0).gameObject;
    //        }
    //        return null;
    //    }
    //}
    GameObject go;
    public static Transform itsTransform;

    private void Awake() {
        itsTransform = transform;
    } 
    public void OnDrop(PointerEventData eventData) {
      
        if( transform.childCount < 21) {
            if(DragHandler.itemBeingDragged.transform.parent != transform) {
                go = Instantiate(DragHandler.itemBeingDragged , transform);
                go.name = "shape" + transform.childCount;
                go.GetComponent<CanvasGroup>().blocksRaycasts = true;
                go.AddComponent<OnClickHandler>(); 
            } 
        } 
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        //try {
        //    foreach(Transform tran in DragHandler.itemBeingDragged.transform.parent) {
        //        Debug.DrawLine(DragHandler.itemBeingDragged.transform.position , tran.position , Color.red);
        //    }
        //    Debug.DrawLine(DragHandler.placeKeeper.transform.position , DragHandler.itemBeingDragged.transform.position , Color.red);
        //}
        //catch(System.Exception e) {

        //}

        if(Input.GetKeyDown(KeyCode.Alpha1)) {
            go.transform.SetSiblingIndex(0);
        }
        if(Input.GetKeyDown(KeyCode.Alpha2)) {
            go.transform.SetSiblingIndex(1);
        }
        if(Input.GetKeyDown(KeyCode.Alpha3)) {
            go.transform.SetSiblingIndex(2);
        }
        if(Input.GetKeyDown(KeyCode.Alpha4)) {
            go.transform.SetSiblingIndex(3);
        }
        if(Input.GetKeyDown(KeyCode.Alpha5)) {
            go.transform.SetSiblingIndex(4);
        }
    }
}
