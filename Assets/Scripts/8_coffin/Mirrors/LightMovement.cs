using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightMovement : MonoBehaviour
{
    [SerializeField] private GameObject[] mirrors;
    [SerializeField] private GameObject[] mirrorsTarget;
    [SerializeField] private GameObject[] lightRays;

    [SerializeField] private float offset = 2f;

    [SerializeField] private CamManager cameraManager;

    public bool isAlive = false;

    void Start()
    {
        lightRays[0].SetActive(true);
        lightRays[1].SetActive(true);
        for (int i = 2; i < lightRays.Length; i++)
        {
            lightRays[i].SetActive(false);
        }
    }

    void Update()
    {
        if (!cameraManager.isOnMirror) return;
        if (isAlive) return;
        if (mirrors[2].transform.position.y < mirrorsTarget[2].transform.position.y + offset && mirrors[2].transform.position.y > mirrorsTarget[2].transform.position.y - offset)
        {
            lightRays[1].SetActive(false);
            lightRays[2].SetActive(true);
            lightRays[3].SetActive(true);
            if (mirrors[0].transform.position.y < mirrorsTarget[0].transform.position.y + offset && mirrors[0].transform.position.y > mirrorsTarget[0].transform.position.y - offset)
            {
                lightRays[3].SetActive(false);
                lightRays[4].SetActive(true);
                lightRays[5].SetActive(true);
                if (mirrors[1].transform.position.y < mirrorsTarget[1].transform.position.y + offset && mirrors[1].transform.position.y > mirrorsTarget[1].transform.position.y - offset)
                {
                    lightRays[5].SetActive(false);
                    lightRays[6].SetActive(true);
                    isAlive = true;
                    Debug.Log("i am!");
                }
                else {
                    lightRays[5].SetActive(true);
                    lightRays[6].SetActive(false);
                }
            }
            else {
                lightRays[3].SetActive(true);
                for (int i = 4; i < lightRays.Length; i++) lightRays[i].SetActive(false);
            }
        }
        else {
            lightRays[1].SetActive(true);
            for (int i = 2; i < lightRays.Length; i++) lightRays[i].SetActive(false);

        }
    }
}
