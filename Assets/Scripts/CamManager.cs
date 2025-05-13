using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamManager : CameraManager
{
    [HideInInspector]
    public bool isOnMain = false;

    //scene home 1
    [HideInInspector]
    public bool isOnDish = false;
    [HideInInspector]
    public bool isOnSocks = false;
    [HideInInspector]
    public bool isOnWindow = false;

    //scene home 2
    [HideInInspector]
    public bool isOnWash = false;
    [HideInInspector]
    public bool isOnLamp = false;

    [HideInInspector]
    public bool isOnCoder = false;
    [HideInInspector]
    public bool isOnMirror = false;

    //general scenes
    [HideInInspector]
    public bool isOnDialog = false;
    //[HideInInspector]
    //public bool isOnMainScene = false;
}
