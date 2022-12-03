using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.IO.Ports;
using System;


public static class CommunationManager  { 
    static SerialPort sp;
   // public static string portName = "COM7";

    static string Str = ""; 
   public  static string arduStr = "";
     
    public static void SerialClose() {
        if(sp != null) {
            if(sp.IsOpen) {
                sp.Close();
            }
        }
    }
     
    public static void SerialInit(string portName,int baudRate=9600,int writeTimeout=1,int readTimeout=100) //Assigns the variables and Setups initializations
    {
        sp = new SerialPort(string.Format("\\\\.\\{0}" , portName) , baudRate);
        sp.Open();
        sp.WriteTimeout = writeTimeout;
        sp.ReadTimeout = readTimeout; 
    }

    public static bool IsOpen() {
        return sp.IsOpen;
    }

    public static void SerialWrite(string deg)  // Sends string values
    {
        if(!sp.IsOpen) {
            sp.Open();
        }

        try {
            sp.Write(deg);
            Debug.Log("Data sended :" + deg);
        }
        catch(Exception e) {
            Debug.LogError(e);
        }
    }

    public static void SerialRead()  //Reads serial inputs byte by byte and assign them to arduStr
    { 
        char readed;
        if(!sp.IsOpen) {
            sp.Open(); 
        }

        try { 
            if(sp.ReadBufferSize > 0) {
                readed = (char)sp.ReadByte();
                if(readed == '#') {
                    readed = (char) sp.ReadByte();
                    while(readed != '*') {
                        arduStr += readed;
                        readed = (char) sp.ReadByte();
                    } 
                }
                Debug.Log(arduStr);
            }
        }
        catch(Exception e) {
            Debug.LogError(e);
        }

    }

    public static string DegToStr(int[] values) { //#xxxyyyzzz*... 
        string stringPacket="";
        string[] stringValues;
        stringValues = new string[values.Length];
        for(int i = 0 ; i < values.Length  ; i++) {
            stringValues[i]= Convert.ToString(values[i]);
            if(stringValues[i].Length < 3) {
                if(stringValues[i].Length < 2) {
                    stringValues[i] = "00" + stringValues[i]; 
                }
                else {
                    stringValues[i] = "0" + stringValues[i];
                }
            }
            stringPacket += stringValues[i];
        }
        stringPacket = "#" + stringPacket+"*"; 
        return stringPacket;
    } 
}
