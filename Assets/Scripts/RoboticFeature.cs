using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoboticFeature : MonoBehaviour {
    public enum Mission {
        Stop,
        GoAhead,
        GoBack,
        TurnLeft,
        TurnRight,
       
    }

    public Mission task;
    public int Time=1;

    private void Update() {
        if(task == Mission.GoAhead || task == Mission.GoBack) {
            transform.GetChild(0).GetComponent<Text>().text = Time.ToString();
        }
    }

}
