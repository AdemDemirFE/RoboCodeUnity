using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.EventSystems;

public class OnClickHandler : MonoBehaviour  {
    public GameObject pickPoint;
    // Use this for initialization
    void Start () {
        pickPoint = PickPoint.pickPoint;
        GetComponent<Button>().onClick.AddListener(delegate() { transform.GetComponent<OnClickHandler>().SayThing(); });
         
    }

    // Update is called once per frame
    void Update () {
       
    }

    public void SayThing() {
        if(transform.GetComponent<RoboticFeature>().task == RoboticFeature.Mission.GoAhead || transform.GetComponent<RoboticFeature>().task == RoboticFeature.Mission.GoBack) {
            TimerSet.instance.ShowTimerFeatures();
            TimerSet.instance.Timer = transform.GetComponent<RoboticFeature>().Time;
            TimerSet.instance.RefreshText();
            TimerSet.SelectedObject = transform.gameObject;
        }
        else {
            TimerSet.instance.HideTimerFeatures();
        }
        DeleteSelected.SelectedOject = transform.gameObject;
        pickPoint.transform.position = transform.position;
    }

 
}

 