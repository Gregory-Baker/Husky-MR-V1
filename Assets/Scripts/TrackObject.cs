using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class TrackObject : MonoBehaviour
{
    [SerializeField]
    GameObject objectToTrack;
    public string objectName;
    public Vector3 offset = new Vector3(0, 0, 0);

    // Update is called once per frame
    void Update()
    {
        if (objectToTrack == null)
        {
            objectToTrack = GameObject.Find(objectName);
        }
        else
        {
            transform.SetPositionAndRotation(objectToTrack.transform.position, objectToTrack.transform.rotation);
            transform.Translate(offset);
        }
    }
}
