using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class DragHandler : MonoBehaviour,IBeginDragHandler,IDragHandler,IEndDragHandler {

    public static GameObject itemBeingDragged;
    public static Vector2 droppedPosition;
    public static Vector3 startPosition;
    Transform startParent;

    public static GameObject placeKeeper;
    public static int selectIndex = 0;
    public void OnBeginDrag(PointerEventData eventData) {
        itemBeingDragged = gameObject;
        startPosition = transform.position;

        Destroy(placeKeeper);
        placeKeeper = Instantiate(itemBeingDragged); 
        Destroy(placeKeeper.GetComponent<Image>());
        Destroy(placeKeeper.GetComponent<DragHandler>());
        Destroy(placeKeeper.GetComponent<CanvasGroup>());
        placeKeeper.transform.position = DragHandler.startPosition;
        //startParent = transform.parent;
        //GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData) {
        transform.position = Input.mousePosition;
        GetComponent<CanvasGroup>().blocksRaycasts = false;
        PickPoint.pickPoint.transform.position = PickPoint.startPosition;
    }

    public void OnEndDrag(PointerEventData eventData) {
    
        GetComponent<CanvasGroup>().blocksRaycasts = true;
        transform.position = startPosition;
        droppedPosition= Input.mousePosition;

        
        if(itemBeingDragged.transform.parent == DropHandler.itsTransform) {

            int index = 0;
            float min = 10000;

            foreach(Transform tran in itemBeingDragged.transform.parent) {
                if(tran != itemBeingDragged.transform) {
                    float dist = Vector3.Distance(tran.position , droppedPosition);
                    if(dist < min) {
                        min = dist;
                        selectIndex = index;
                    }
                }
                else {
                    float dist = Vector3.Distance(placeKeeper.transform.position , droppedPosition);

                    if(dist < min) {
                        min = dist;
                        selectIndex = index;
                    }
                }
                index++;
            }
           
            itemBeingDragged.transform.SetSiblingIndex(selectIndex);
        }
         
        itemBeingDragged = null;
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
