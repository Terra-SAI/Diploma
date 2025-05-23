using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Bowl : MonoBehaviour
{
    [SerializeField] private float foodInBowl = 0f;
    [SerializeField] private float requiredFood = 80f;

    [SerializeField] private TMP_Text percentText; // UI-элемент, отображающий % заполнения

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("red"))
        {
            foodInBowl += 1f;
            Debug.Log(foodInBowl);
           // Destroy(other.gameObject);

           UpdateUI();
        }
    }

    void UpdateUI()
    {
        float percent = Mathf.Clamp01(foodInBowl / requiredFood) * 100f;
        percentText.text = "Заполнено: " + Mathf.RoundToInt(percent) + "%";

        if (percent >= requiredFood)
        {
            Debug.Log("Миска заполнена!");
            // Можно вызвать анимацию, экран победы и т.д.
        }
    }
}
