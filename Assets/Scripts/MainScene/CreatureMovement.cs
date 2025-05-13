using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureMovement : MonoBehaviour
{
    private Animator animator;
    [SerializeField] DialogueTrigger dialogueTrigger;
    [SerializeField] private Animator diaAnim;

    [SerializeField] private GameObject amuletIcon1;
    [SerializeField] private GameObject amuletIcon2;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        amuletIcon1.gameObject.SetActive(false);
        amuletIcon2.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (IsAnimationPlaying(diaAnim, "Base Layer.hide"))
        {
            dialogueTrigger.canCommunicate = false;
            animator.SetBool("hasTalked", true);
            amuletIcon1.gameObject.SetActive(true);
            amuletIcon2.gameObject.SetActive(true);
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
