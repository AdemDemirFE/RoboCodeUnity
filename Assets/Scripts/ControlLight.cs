using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class ControlLight : MonoBehaviour {
    public bool status = true;
    void Start() {
        
    }

    private void OnApplicationQuit() { 
    }

    IEnumerator GetText(string mission) {
        status=false;
        UnityWebRequest www = UnityWebRequest.Get("http://192.168.137.102/" + mission);
        yield return www.SendWebRequest();

        if(www.isNetworkError || www.isHttpError) {
            Debug.Log(www.error);
        }
        else {
            // Show results as text
            Debug.Log(www.downloadHandler.text);
            status = true;
            // Or retrieve results as binary data
            byte[] results = www.downloadHandler.data;
        }
    }
     
}
