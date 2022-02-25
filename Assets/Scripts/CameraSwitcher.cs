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

    public int participantID;

    public XRCamera cam;
    public Canvas canvas;

    [Header("Theta")]
    public Camera thetaCam;
    public GameObject[] thetaObjects;

    [Header("Zed VR")]
    public Camera zedCam;
    public GameObject[] zedObjects;

    [Header("Zed No VR")]
    public Camera zedMonoCam;
    public GameObject[] zedNoVRObjects;


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
            foreach (GameObject zedObject in zedNoVRObjects)
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

        if (cam == XRCamera.ZED)
        {
            foreach (GameObject thetaObject in thetaObjects)
            {
                thetaObject.SetActive(false);
            }
            foreach (GameObject zedObject in zedObjects)
            {
                zedObject.SetActive(true);
            }
            foreach (GameObject zedObject in zedNoVRObjects)
            {
                zedObject.SetActive(false);
            }
            if (zedCam != null)
            {
                canvas.worldCamera = zedCam;
            }
        }

        if (cam == XRCamera.ZED_NOVR)
        {
            foreach (GameObject thetaObject in thetaObjects)
            {
                thetaObject.SetActive(false);
            }
            foreach (GameObject zedObject in zedObjects)
            {
                zedObject.SetActive(false);
            }
            foreach (GameObject zedObject in zedNoVRObjects)
            {
                zedObject.SetActive(true);
            }
            if (zedMonoCam != null)
            {
                canvas.worldCamera = zedMonoCam;
            }
        }
    }

}
