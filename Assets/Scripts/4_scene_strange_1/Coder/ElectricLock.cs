using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ElectricLock : MonoBehaviour
{
    [SerializeField] private CamManager CamManager;

    [Space]
    [SerializeField] private GameObject mainCamera;
    [SerializeField] private GameObject coderCamera;

    [Space]
    [SerializeField] private TextMeshPro _passwordText;
    [SerializeField] private GameObject _panelField;
    [SerializeField] private int _password = 1234;

    [Space]
    [SerializeField] private GameObject _exitButton;
    [SerializeField] private GameObject textPanel;
    [SerializeField] private GameObject password;
    [Space]
    [SerializeField] private PaperGM gm;

    [Space]
    public bool isCodeCorrect;

    //   private Ray _playerRaycast;
    //  private BoxCollider _boxCollider;

    int countOfNumbers;
    bool passwordIsEntered;

	private void Start()
	{
       // _exitButton.SetActive(true);
        isCodeCorrect = false;
        password.gameObject.SetActive(false);
        //_boxCollider = GetComponent<BoxCollider>();
    }

    private void Update()
    {
        if (!CamManager.isOnCoder) return;
        if (isCodeCorrect) { return; }
        if (gm.isPaperDone) password.gameObject.SetActive(true);
        _exitButton.SetActive(true);
    }

    public void AddNumber(int num)
    {
        if(countOfNumbers >= 5 || passwordIsEntered) return;

        countOfNumbers++;
        _passwordText.text += num.ToString();
	}

    public void ClearText()
    {
        if(countOfNumbers == 0)
        {
            return;
		}

        _passwordText.text = "";
        countOfNumbers = 0;
	}

    public void CheckPassword()
    {
        if (_passwordText.text == _password.ToString())
        {
            // Меняем цвет альбедо
            _panelField.GetComponent<Renderer>().material.SetColor("_Color", Color.green);
            passwordIsEntered = true;
            Debug.Log("Пароль верный!");

            isCodeCorrect = true;
            ShowText();
        }
        else
        {
            Debug.Log("Пароль неверный, попробуйте снова.");
            ClearText();
        }
    }
    //public void ExitToScene()
    //{
    //    SceneManager.LoadScene("empty"); 
    //}

    public void LoadMainScene()
    {
        CamManager.Switch(coderCamera, mainCamera);
        CamManager.isOnCoder = false;
        _exitButton.gameObject.SetActive(false);
        password.gameObject.SetActive(false);
    }

    public void ShowText()
    {
        textPanel.SetActive(true);
        Invoke("HideText", 5f); // Запускаем таймер
    }

    private void HideText()
    {
        textPanel.SetActive(false);
    }
}
