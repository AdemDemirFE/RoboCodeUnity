using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public static class WifiConnectionManager   { 
     
    public static IEnumerator WifiMissionPusher(string mission) {
        UnityWebRequest www = UnityWebRequest.Get("http://192.168.137.102/" + mission);
        yield return www.SendWebRequest();

        if(www.isNetworkError || www.isHttpError) {
            Debug.Log(www.error);
        }
        else {
            // Show results as text
            Debug.Log(www.downloadHandler.text);
           
            // Or retrieve results as binary data
            byte[] results = www.downloadHandler.data;
        }
    }
 
 
}
