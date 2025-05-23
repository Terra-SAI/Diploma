using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Bowl : MonoBehaviour
{
    [SerializeField] private float foodInBowl = 0f;
    [SerializeField] private float requiredFood = 500f;

    [SerializeField] public TMP_Text percentText; // UI-элемент, отображающий % заполнения

    [Space]
    public bool isBowlFilled = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("red"))
        {
            foodInBowl += 1f;
           UpdateUI();
        }
    }

    void UpdateUI()
    {

        float percent = Mathf.Clamp01(foodInBowl / requiredFood) * 100f; 
        if (foodInBowl >= requiredFood)
        {
            Debug.Log("Миска заполнена!");
            percentText.text = "Корм засыпан";
            isBowlFilled = true;
        }
       else percentText.text = "Заполнено: " + Mathf.RoundToInt(percent) + "%";

        
    }
}
