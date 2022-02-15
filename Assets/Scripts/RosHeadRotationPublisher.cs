using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Robotics.ROSTCPConnector;
using RosMessageTypes.DynamixelPanTilt;
using UnityEngine.XR;
using Valve.VR;
using System.Linq;
using UnityEngine.UIElements;

public class RosHeadRotationPublisher : MonoBehaviour
{
    ROSConnection ros;
    public string topicName = "head_rot";
    public float publishMessageFrequency = 0.05f;
    private float timeElapsed;

    private PanTiltAngleMsg headPosition;
    private Quaternion headRotation;
    private List<XRNodeState> nodeStates = new List<XRNodeState>();

    // Start is called before the first frame update
    void Start()
    {
        // start the ROS connection
        ros = ROSConnection.GetOrCreateInstance();
        ros.RegisterPublisher<PanTiltAngleMsg>(topicName);
    }

    // Update is called once per frame
    void Update()
    {
        timeElapsed += Time.deltaTime;
        if (timeElapsed > publishMessageFrequency)
        {
            InputTracking.GetNodeStates(nodeStates);
            var headState = nodeStates.FirstOrDefault(node => node.nodeType == XRNode.Head);
            headState.TryGetRotation(out headRotation);
            Vector3 angles = headRotation.eulerAngles;
            float panAngle = angles.y;
            float tiltAngle = angles.x;
            if (panAngle > 180)
            {
                panAngle -= 360;
            }
            if (tiltAngle > 180)
            {
                tiltAngle -= 360;
            }
            // Vector3Msg headRotMsg = new Vector3Msg(angles.x, angles.y, angles.z);
            PanTiltAngleMsg headRotMsg = new PanTiltAngleMsg(panAngle, tiltAngle);
            ros.Publish(topicName, headRotMsg);
            timeElapsed = 0;
        }
    }
}
