using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DebugDisplay : MonoBehaviour
{
    Dictionary<string, string> debugLogs = new Dictionary<string, string>();
    public Text display;
    private OVRGrabber grabbedObject;
    private bool isHeld = false;

    void Start()
    {
        // Get the OVRGrabber script from the game object
        grabbedObject = GetComponent<OVRGrabber>();
    }

    private void Update()
    {
        Debug.Log("time:" + Time.time);
        Debug.Log(gameObject.name);

        // Check if the object is currently being grabbed
        if (grabbedObject != null)
        {
            // Set the isHeld variable to true
            isHeld = true;
            Debug.Log("Something Grabbed");
        }
        else
        {
            // Set the isHeld variable to false
            isHeld = false;
            Debug.Log("Something Not Grabbed");
        }
        //if (OVRInput.GetDown(OVRInput.Axis1D.SecondaryHandTrigger))
        //{
        //    Debug.Log("A button pressed");
        //}
        //  || OVRInput.Get(OVRInput.Button.One) WORKS
        bool buttonPressed = false;
        float res = OVRInput.Get(OVRInput.Axis1D.SecondaryHandTrigger);
        if (OVRInput.Get(OVRInput.Axis1D.SecondaryIndexTrigger) > 0.1f || OVRInput.Get(OVRInput.Axis1D.SecondaryHandTrigger) > 0.1f)
        {
            //Debug.Log("A button pressed");
            
            buttonPressed = true;
        }
        else
        {
            //Debug.Log("A button not pressed");
            buttonPressed = false;
        }
        Debug.Log("pressed:"+buttonPressed);
        Debug.Log("Resistance:" + res);
    }




    private void OnEnable()
    {
        Application.logMessageReceived += HandleLog;
    }

    private void OnDisable()
    {
        Application.logMessageReceived -= HandleLog;
    }

    void HandleLog(string logString, string stackTrace, LogType type)
    {
        if (type == LogType.Log)
        {
            string[] splitString = logString.Split(char.Parse(":"));
            string debugKey = splitString[0];
            string debugValue = splitString.Length > 1 ? splitString[1] : "";

            if (debugLogs.ContainsKey(debugKey))
                debugLogs[debugKey] = debugValue;
            else
                debugLogs.Add(debugKey, debugValue);

        }

        string displayText = "";
        foreach (KeyValuePair<string, string> log in debugLogs)
        {
            if (log.Value == "")
                displayText += log.Key + "\n";
            else
                displayText += log.Key + ": " + log.Value + "\n";
        }

        display.text = displayText;
    }
}