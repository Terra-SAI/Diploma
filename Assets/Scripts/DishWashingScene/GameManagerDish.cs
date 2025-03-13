using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManagerDish : MonoBehaviour
{
    [SerializeField] private Renderer plateRenderer; // ������ �� �������
    [SerializeField] private TMP_Text gameOverText; // ����� ����������
    [SerializeField] private Button continueButton; // ������ �����������
    private Material dirtMaterial; // �������� �����
    public static bool isGamePaused = false;

    void Start()
    {
        // ������ UI ��������
        gameOverText.gameObject.SetActive(false);
        continueButton.gameObject.SetActive(false);
        isGamePaused = false;

        if (plateRenderer == null)
        {
            Debug.LogError("������: �� �������� Renderer �������!");
            return;
        }

        // �������� ��������� �������
        Material[] materials = plateRenderer.materials;
        if (materials.Length > 1)
        {
            dirtMaterial = materials[1]; // �������� �����
        }
        else
        {
            Debug.LogError("������: � ������� ��� ������� ��������� (�����)!");
        }

        // ��������� ��������� ��� ������
        continueButton.onClick.AddListener(LoadMainScene);
    }

    void Update()
    {
        if (dirtMaterial != null && dirtMaterial.color.a <= 0f)
        {
            Debug.Log("������� ������! ����-���� ���������.");
            ShowEndScreen();
        }
    }

    void ShowEndScreen()
    {
        gameOverText.gameObject.SetActive(true);
        continueButton.gameObject.SetActive(true);
        gameOverText.text = "������� ������!";
        isGamePaused = true;
    }

    public void LoadMainScene()
    {
        isGamePaused = false;
        SceneManager.LoadScene("SampleScene"); // �������� �������� �����
    }
}
