using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodGM : MonoBehaviour
{
    [SerializeField] private CamManager camManager;
    [SerializeField] private GameObject cameraMain;
    [SerializeField] private GameObject foodCamera;
    [Space]
    public bool isOn = false;
    public bool isFinished = false;

    [Space]
    [SerializeField] private Bowl bowl;
    [Space]
    [SerializeField] private GameObject continueButton;
    void Start()
    {
       
     
        foodCamera.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        isOn = camManager.isOnFood;
        if (isOn) { continueButton.gameObject.SetActive(true); bowl.percentText.gameObject.SetActive(true); }
            isFinished = bowl.isBowlFilled;
    }
    public void LoadMainScene()
    {

        camManager.isOnMain = true;
        camManager.isOnFood = false;
        bowl.percentText.gameObject.SetActive(false);
        continueButton.gameObject.SetActive(false);
        camManager.Switch(foodCamera, cameraMain);

    }
}
