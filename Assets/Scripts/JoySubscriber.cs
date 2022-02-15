using UnityEngine;
using Unity.Robotics.ROSTCPConnector;
using RosMessageTypes.Sensor;

public class JoySubscriber : MonoBehaviour
{
    public GameObject[] mapCanvasImages;
    public string topic;
    public int joystickButtonIndex = 3;

    void Start()
    {
        foreach (GameObject map in mapCanvasImages) map.SetActive(false);
        if (topic != null)
        {
            ROSConnection.GetOrCreateInstance().Subscribe<JoyMsg>(topic, ShowMap);
        }
        else
        {
            Debug.Log("Need joy topic name to subscribe to");
        }
        
    }

    void ShowMap(JoyMsg message)
    {
        if (message.buttons[joystickButtonIndex] == 1)
        {
            foreach (GameObject map in mapCanvasImages) map.SetActive(true);
        }
        else
        {
            foreach (GameObject map in mapCanvasImages) map.SetActive(false);
        }
    }
}