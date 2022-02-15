using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockXRRigPos : MonoBehaviour
{
    [SerializeField]
    GameObject objectToTrack;
    public string objectName;

    void LateUpdate()
    {
        if (objectToTrack == null)
        {
            objectToTrack = GameObject.Find(objectName);
        }
        else
        {
            //if (trackObjectCenter)
            //    transform.position = objectToTrack.GetComponent<Renderer>().bounds.center;
            if (objectToTrack != null)
            {
                Vector3 shiftVector = objectToTrack.transform.position - transform.position;
                transform.Translate(shiftVector);
            }
        }
    }
}
