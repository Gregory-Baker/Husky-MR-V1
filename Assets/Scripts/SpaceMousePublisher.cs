using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Robotics.ROSTCPConnector;
using RosMessageTypes.Sensor;
using System;


public class SpaceMousePublisher : MonoBehaviour
{
    ROSConnection ros;
    public string topicName = "joy";
    public float publishMessageFrequency = 0.5f;
    public bool publish = false;

    void Start()
    {
        // start the ROS connection
        ros = ROSConnection.GetOrCreateInstance();
        ros.RegisterPublisher<JoyMsg>(topicName);
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Alpha1))
        {
            PublishJoyMsg();
        }
        if (Input.GetKey(KeyCode.Alpha2))
        {
            PublishJoyMsg();
        }
        if (Input.GetKey(KeyCode.Alpha3))
        {
            PublishJoyMsg();
        }
        if (Input.GetKey(KeyCode.Alpha4))
        {
            PublishJoyMsg();
        }
    }

    private void PublishJoyMsg()
    {
        JoyMsg joy = new JoyMsg();

        // Finally send the message to server_endpoint.py running in ROS
        ros.Publish(topicName, joy);
    }
}
