using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZedRecorder : MonoBehaviour
{
    public CameraSwitcher camSwitcher;
    public ZEDManager zedManager;

    // Start is called before the first frame update
    void Start()
    {
        if(zedManager != null && camSwitcher.participantID != 0)
        {
            zedManager.OnZEDReady += StartRecording;
        }
    }

    private void StartRecording()
    {
        string folder = "C:/Users/g-baker-admin/Documents/MR_Experiment_Data/";
        string datetime = DateTime.Now.Date.Year + "_" + DateTime.Now.Date.Month + "_" + DateTime.Now.Date.Day + "-" + DateTime.Now.TimeOfDay.Hours + "_" + DateTime.Now.TimeOfDay.Minutes + "_" + DateTime.Now.TimeOfDay.Seconds;
        string outfile = folder + camSwitcher.participantID + "/" + camSwitcher.cam + "/" + camSwitcher.participantID + "_" + camSwitcher.cam + "_" + datetime + ".svo";
        Debug.Log("Outfile: " + outfile);
        zedManager.zedCamera.EnableRecording(outfile);

    }


}
