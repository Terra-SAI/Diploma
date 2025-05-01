using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamManager : CameraManager
{
    //scene home 1
    [HideInInspector]
    public bool isOnDish = false;
    [HideInInspector]
    public bool isOnSocks = false;

    //scene home 2
    [HideInInspector]
    public bool isOnWash = false;
    [HideInInspector]
    public bool isOnLamp = false;

    [HideInInspector]
    public bool isOnCoder = false;

    //general scenes
    [HideInInspector]
    public bool isOnDialog = false;
    [HideInInspector]
    public bool isOnMainScene = false;
}
