using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WifiRobotController : MonoBehaviour {
    public GameObject CodePanel;
    public bool start = false;
    public int progress = 0;
    float waitTime;
    public float rotationTime=1;
    float startTime = 0;
    float timer = 0;
    bool entered = false;
    int[] data;
    private void Awake() {
    }

    // Use this for initialization
    void Start() {
       
         
    }

    // Update is called once per frame
    void Update() {
        if(start) {
           
            if(!entered) {
                data = CreateDataListForCommunication();
                StartCoroutine( WifiConnectionManager.WifiMissionPusher(data[progress].ToString()));
               entered = true;
            }

            if(entered) { 
                int type = Mathf.FloorToInt(data[progress] / 100f);
                switch(type) {
                    case 0:
                        waitTime = -1;
                        break;
                    case 1:
                        waitTime = data[progress] % 100;
                        break;
                    case 2:
                        waitTime = data[progress] % 100;
                        break;
                    case 3:
                        waitTime = rotationTime;
                        break;
                    case 4:
                        waitTime = rotationTime;
                        break;
                }

                timer += Time.deltaTime;
                if(waitTime != -1) {
                    if(timer > waitTime) {
                        timer = 0; 
                        progress++;
                        entered = false;
                    }
                }


                if(progress == data.Length) {
                    start = false;
                    progress = 0;
                }
            }
        }

    }

    public void StartProgress() {
        start = !start;
        progress = 0;
        timer = 0;
    }

    public void GetDataList() {
        data = CreateDataListForCommunication();    
    }

    int[] CreateDataListForCommunication() {
        int stepNum = CodePanel.transform.childCount;
        int[] values;
        values = new int[stepNum]; 
        int i = 0;

        foreach(Transform t in CodePanel.transform) {
            values[i] = (int) t.GetComponent<RoboticFeature>().task * 100 + t.GetComponent<RoboticFeature>().Time;
            i++;
        }
        return values;
    }


 

    }
