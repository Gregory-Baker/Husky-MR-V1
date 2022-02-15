using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FullMapImageViewer : MonoBehaviour
{
    public GameObject mapMesh;
    public string objectName = "map_mesh";

    void Update()
    {
        if (mapMesh == null)
        {
            mapMesh = GameObject.Find(objectName);
        }
        else
        {
            GetComponent<RawImage>().material = mapMesh.GetComponent<Renderer>().material;
        }
    }

}
