using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class RobotController : MonoBehaviour {
    public static RobotController instance;
    public GameObject CodePanel;
    public string portName="COM7"; 
    public bool start = false;

    private void Awake() {
        instance = this;        
    }
        
	// Use this for initialization
	void Start () { 
         CommunationManager.SerialInit(portName);
	}
	
	// Update is called once per frame
	void Update () {

        if(Input.GetKeyDown(KeyCode.Space)) { 
            CommunationManager.SerialWrite("a");
            CommunationManager.SerialRead();
        } 
	}

    public void SendProgram() {
        int stepNum = CodePanel.transform.childCount;
        int[] values;
        values =new int[stepNum + 1];
        values[0] = stepNum;
        int i = 1;
        foreach(Transform t in CodePanel.transform) {
            values[i] = (int)t.GetComponent<RoboticFeature>().task*100 + t.GetComponent<RoboticFeature>().Time; 
            i++;
        }

        CommunationManager.SerialWrite(CommunationManager.DegToStr(values));
    }

    public void StartStopProgram() {
        start = !start;

        if(start) {
             CommunationManager.SerialWrite("#P*");
        }
        else {
             CommunationManager.SerialWrite("#S*");
        }
    }
     
    private void OnApplicationQuit() {
        CommunationManager.SerialClose();
    }
}
