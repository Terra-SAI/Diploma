using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndDialogue : MonoBehaviour
{
 //   private Animator animator;
    [SerializeField] DialogueTrigger dialogueTrigger;
    [SerializeField] private Animator diaAnim;
    [Space]
    [SerializeField] private GameObject amuletIcon1;
    [SerializeField] private GameObject amuletIcon2;

    [Space]
    [SerializeField] private GameObject putButton;
    [SerializeField] private GameObject runButton;
    private bool isShown = false;
    [Space]
    [SerializeField] private int boarder = 60;

    [Space]
    [SerializeField] private GameObject tree1;
    [SerializeField] private GameObject tree2;

    // Start is called before the first frame update
    void Start()
    {
        //animator = GetComponent<Animator>();
        amuletIcon1.gameObject.SetActive(true);
        amuletIcon2.gameObject.SetActive(true);
        putButton.gameObject.SetActive(false);
        runButton.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!dialogueTrigger.canCommunicate && IsAnimationPlaying(diaAnim, "Base Layer.hide"))
        {
            if (isShown) { return; }
            else
            { 
                isShown = true;
                putButton.gameObject.SetActive(true);
                if (SaveManager.Instance.GetProgress() <= boarder)
                {
                    runButton.gameObject.SetActive(true);
                }
            }
        }
    }

    public void Put()
    {
        amuletIcon1.gameObject.SetActive(false);
        amuletIcon2.gameObject.SetActive(false);
        putButton.gameObject.SetActive(false);
        runButton.gameObject.SetActive(false);

        SceneManager.LoadScene("13_Dead");

    }
    public void Run()
    {
        putButton.gameObject.SetActive(false);
        runButton.gameObject.SetActive(false);

        Renderer renderer = tree1.GetComponent<Renderer>();
        if (renderer != null)
        {
            Material mat = renderer.material;
            mat.DisableKeyword("_EMISSION");
            mat.globalIlluminationFlags = MaterialGlobalIlluminationFlags.EmissiveIsBlack;
            mat.SetColor("_EmissionColor", Color.black);
        }
        renderer = tree2.GetComponent<Renderer>();
        if (renderer != null)
        {
            Material mat = renderer.material;
            mat.DisableKeyword("_EMISSION");
            mat.globalIlluminationFlags = MaterialGlobalIlluminationFlags.EmissiveIsBlack;
            mat.SetColor("_EmissionColor", Color.black);
        }

    }
    public bool IsAnimationPlaying(Animator animator, string animationName)
    {
        // берем информацию о состоянии
        var animatorStateInfo = animator.GetCurrentAnimatorStateInfo(0);
        // смотрим, есть ли в нем имя какой-то анимации, то возвращаем true
        if (animatorStateInfo.IsName(animationName))
            return true;

        return false;
    }
}
