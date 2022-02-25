using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Robotics.ROSTCPConnector;
using RosMessageTypes.Std;

public class LatencyPublisher : MonoBehaviour
{
    public ZEDManager zedManager;

    double systemTimestamp = 0;
    double imageTimestamp = 0;

    const double nsToms = 1e6;
    double latency = 0;

    ROSConnection ros;
    public string topicName = "latency";
    public float publishMessageFrequency = 0.5f;
    public bool publish = false;

    int i = 0;


    // Start is called before the first frame update
    void Start()
    {
        zedManager.OnGrab += CalculateLatency;
    }


    private void CalculateLatency()
    {
        try
        {
            systemTimestamp = System.DateTime.UtcNow.Subtract(new System.DateTime(1970,1,1)).TotalMilliseconds;
            imageTimestamp = zedManager.ImageTimeStamp;

            latency = (systemTimestamp - imageTimestamp / nsToms) / 1000;
        }
        catch (System.Exception)
        {
            throw;
        }
    }

    void Update()
    {
        if (i%500 == 0)
        {
            Debug.Log(systemTimestamp);
            Debug.Log(imageTimestamp);
            Debug.Log(latency) ;
        }
        i++;
    }
}
