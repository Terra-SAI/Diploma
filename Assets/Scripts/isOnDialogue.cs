using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class isOnDialogue : MonoBehaviour
{
    [SerializeField] private Animator diaAnim;

    [Space]
    [SerializeField] private CamManager camManager;


    // Update is called once per frame
    void Update()
    {
        if (IsAnimationPlaying(diaAnim, "Base Layer.show"))
        {
            camManager.isOnDialog = true;
        }
        else if (IsAnimationPlaying(diaAnim, "Base Layer.hide"))
        {
            camManager.isOnDialog = false;
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
