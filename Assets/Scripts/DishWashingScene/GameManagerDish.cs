using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManagerDish : MonoBehaviour
{
    [SerializeField] private Renderer plateRenderer; // Ссылка на тарелку
    [SerializeField] private TMP_Text gameOverText; // Текст завершения
    [SerializeField] private Button continueButton; // Кнопка продолжения
    private Material dirtMaterial; // Материал грязи
    public static bool isGamePaused = false;

    void Start()
    {
        // Прячем UI элементы
        gameOverText.gameObject.SetActive(false);
        continueButton.gameObject.SetActive(false);
        isGamePaused = false;

        if (plateRenderer == null)
        {
            Debug.LogError("Ошибка: Не назначен Renderer тарелки!");
            return;
        }

        // Получаем материалы тарелки
        Material[] materials = plateRenderer.materials;
        if (materials.Length > 1)
        {
            dirtMaterial = materials[1]; // Материал грязи
        }
        else
        {
            Debug.LogError("Ошибка: у тарелки нет второго материала (грязи)!");
        }

        // Добавляем слушатель для кнопки
        continueButton.onClick.AddListener(LoadMainScene);
    }

    void Update()
    {
        if (dirtMaterial != null && dirtMaterial.color.a <= 0f)
        {
            Debug.Log("Тарелка чистая! Мини-игра завершена.");
            ShowEndScreen();
        }
    }

    void ShowEndScreen()
    {
        gameOverText.gameObject.SetActive(true);
        continueButton.gameObject.SetActive(true);
        gameOverText.text = "Тарелка чистая!";
        isGamePaused = true;
    }

    public void LoadMainScene()
    {
        isGamePaused = false;
        SceneManager.LoadScene("SampleScene"); // Название основной сцены
    }
}
