using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class creatureDia : MonoBehaviour
{
    private Animator animator;
    [SerializeField] DialogueTrigger dialogueTrigger;
    [SerializeField] private Animator diaAnim;

    void Update()
    {
        if (IsAnimationPlaying(diaAnim, "Base Layer.hide"))
        {
            dialogueTrigger.canCommunicate = false;
            animator.SetBool("hasTalked", true);
      
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
