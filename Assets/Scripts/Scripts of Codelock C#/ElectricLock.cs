using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ElectricLock : MonoBehaviour
{
    [SerializeField] private TextMeshPro _passwordText;
    [SerializeField] private GameObject _panelField;
    [SerializeField] private int _password = 1234;

    [SerializeField] private GameObject _exitButton;  // Ссылка на кнопку выхода

    //   private Ray _playerRaycast;
    //  private BoxCollider _boxCollider;

    int countOfNumbers;
    bool passwordIsEntered;

	private void Start()
	{
        _exitButton.SetActive(false);
        //_boxCollider = GetComponent<BoxCollider>();
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

            _exitButton.gameObject.SetActive(true);
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

    public void ExitToFinalScene()
    {
        SceneManager.LoadScene("empty");
    }
}
