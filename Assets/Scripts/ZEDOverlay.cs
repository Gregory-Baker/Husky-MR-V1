using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ZEDOverlay : MonoBehaviour
{
    public ZEDManager zedManager;
    public Camera leaderObject;
    float x_offset = 0;
    float y_offset = 0;
    public float z_offset = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        if (zedManager != null && leaderObject == null)
        {
            zedManager.OnZEDReady += AssignLeader;
        }
        else
            return;
    }

    void AssignLeader ()
    {
        leaderObject = zedManager.GetComponentInChildren<ZEDMixedRealityPlugin>().GetComponentInChildren<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (leaderObject != null)
        {
            Vector3 offset = new Vector3(x_offset, y_offset, z_offset);
            transform.SetPositionAndRotation(leaderObject.transform.position, leaderObject.transform.rotation);
            
            transform.Translate(offset, Space.Self);
        }

    }
}
