using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WindowIter : MonoBehaviour
{
    public dialog_new_trigger dialog;

    [SerializeField] private Window_GM Window_GM;
    [SerializeField] private CamManager CamManager;

    [Space]
    [SerializeField] private GameObject mainCamera;
    [SerializeField] private GameObject windowCamera;

    [Space]
    [SerializeField] private int normalParam = 10;
    private int count;
    [Space]
    [SerializeField] private int nerves;
    [SerializeField] private GameObject exitButton;
    [SerializeField] private GameObject enterButton;

    [Space]
    [SerializeField] private float distance = 70f;
    // Start is called before the first frame update
    void Start()
    {
        count = 0;
        exitButton.gameObject.SetActive(false);
        enterButton.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = mainCamera.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 1000))
            {
                var commItem = hit.collider.GetComponent<WindowItem>();

                if (commItem != null && Vector3.Distance(this.transform.position, commItem.transform.position) <= distance)
                {
                    if (count < nerves) {
                        if (!Window_GM.isWindowDone)
                        {
                            CamManager.isOnMain = false;
                            CamManager.isOnWindow = true;
                            CamManager.Switch(mainCamera, windowCamera);
                        }
                        else
                        {
                            StartDialog();
                            count++;
                        }
                    }
                    else
                    {
                        exitButton.gameObject.SetActive(true);
                        enterButton.gameObject.SetActive(true);
                    }
                }
            }
        }
    }
    private void StartDialog()
    {
        dialog.TriggerDialogue(); 
    }

    public void GoOut()
    {
        Scene scene = SceneManager.GetActiveScene();
        SaveManager.Instance.AddToProgress(normalParam);
        SaveManager.Instance.SaveGame(scene.name, SaveManager.Instance.GetProgress());
        SceneManager.LoadScene("000_DEAD");
    }

    public void GoIn()
    {
        enterButton.gameObject.SetActive(false);
        exitButton.gameObject.SetActive(false);
    }
}
