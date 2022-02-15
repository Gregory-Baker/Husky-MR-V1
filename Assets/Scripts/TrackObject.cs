using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class TrackObject : MonoBehaviour
{
    [SerializeField]
    GameObject objectToTrack;
    public string objectName;
    //public bool trackObjectCenter;

    // Update is called once per frame
    void Update()
    {
        if (objectToTrack == null)
        {
            objectToTrack = GameObject.Find(objectName);
        }
        else
        {
            //if (trackObjectCenter)
            //    transform.position = objectToTrack.GetComponent<Renderer>().bounds.center;
            transform.SetPositionAndRotation(objectToTrack.transform.position, objectToTrack.transform.rotation);
        }
    }
}
