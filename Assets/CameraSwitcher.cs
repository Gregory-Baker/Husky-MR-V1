using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class CameraSwitcher : MonoBehaviour
{
    public enum XRCamera {
        THETA,
        ZED,
        ZED_NOVR
    }

    public XRCamera cam;
    public Canvas canvas;

    [Header("Theta")]
    public Camera thetaCam;
    public GameObject[] thetaObjects;

    [Header("Zed")]
    public Camera zedCam;
    public GameObject[] zedObjects;

    public RectTransform minimap;
    public Vector2 vrPos = new Vector2(100,100);
    public Vector2 nonVRPos = new Vector2(300,100);




    void Update()
    {
        if (cam == XRCamera.THETA)
        {
            foreach (GameObject zedObject in zedObjects)
            {
                zedObject.SetActive(false);
            }
            foreach (GameObject thetaObject in thetaObjects)
            {
                thetaObject.SetActive(true);
            }
            if (thetaCam != null)
            {
                canvas.worldCamera = thetaCam;
            } 
            
        }

        if (cam == XRCamera.ZED || cam == XRCamera.ZED_NOVR)
        {
            foreach (GameObject thetaObject in thetaObjects)
            {
                thetaObject.SetActive(false);
            }
            foreach (GameObject zedObject in zedObjects)
            {
                zedObject.SetActive(true);
            }
            if (thetaCam != null)
            {
                canvas.worldCamera = zedCam;
            }
            if (cam == XRCamera.ZED_NOVR)
            {
                minimap.anchoredPosition = nonVRPos;
            }
            else
            {
                minimap.anchoredPosition = vrPos;
            }

        }
    }

}
