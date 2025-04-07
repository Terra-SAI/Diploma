using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManagerDish : MonoBehaviour
{
    [SerializeField] private CamManager cameraManager;
    [SerializeField] private GameObject cameraMain;
    [SerializeField] private GameObject dishCamera;
    [SerializeField] private Renderer plateRenderer; // Ссылка на тарелку
    [SerializeField] private TMP_Text gameOverText; // Текст завершения
    [SerializeField] private GameObject continueButton; // Кнопка продолжения
    [SerializeField] private GameObject dishes;
    private Material dirtMaterial; // Материал грязи
    public static bool isGamePaused = false;
    public bool isFinished = false;

    void Start()
    {
        // Прячем UI элементы
        gameOverText.gameObject.SetActive(false);
        continueButton.gameObject.SetActive(false);
        isGamePaused = false;
        // Получаем материалы тарелки
        Material[] materials = plateRenderer.materials;
        dirtMaterial = materials[1]; // Материал грязи
    }

    void Update()
    {
        if (!cameraManager.isOnDish)
        {
            return;
        }
        if (dirtMaterial != null && dirtMaterial.color.a <= 0f)
        {
           isFinished = true;
            dishes.SetActive(false);
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
       
        cameraManager.isOnDish = false;
        gameOverText.gameObject.SetActive(false);
        continueButton.gameObject.SetActive(false);

        cameraManager.Switch(dishCamera, cameraMain);
     
        isGamePaused = false;
    }
}
