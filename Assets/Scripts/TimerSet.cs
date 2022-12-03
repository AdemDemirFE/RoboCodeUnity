using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerSet : MonoBehaviour {
    public static TimerSet instance;
    public static GameObject SelectedObject;
    private int timer = 0;

    void Awake() {
        instance = this;
    }

    public int Timer {

        get {
            return timer;
        }
        set {
            if(value > 10)
                timer = 10;
            else if(value < 1)
                timer = 1;
            else
                timer = value;
        }
    }

    public Text text;
    public GameObject IncDecPanel;

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    public void Increase() {
        if(SelectedObject != null) {
            if(SelectedObject.GetComponent<RoboticFeature>().Time != 0) {
                Timer++;
                SelectedObject.GetComponent<RoboticFeature>().Time = Timer;
                text.text = Timer.ToString();
            }
        }
    }
    public void Decrease() {
        if(SelectedObject != null) { 
            if(SelectedObject.GetComponent<RoboticFeature>().Time != 0) {
                Timer--;
                SelectedObject.GetComponent<RoboticFeature>().Time = Timer;
                text.text = Timer.ToString();
            }
        }
    }

    public void RefreshText() {
        text.text = Timer.ToString();
    }

    public void ShowTimerFeatures() {
        text.gameObject.SetActive(true);
        IncDecPanel.SetActive(true);

    }

    public void HideTimerFeatures() {
        text.gameObject.SetActive(false);
        IncDecPanel.SetActive(false);
    }

}
