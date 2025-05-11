using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Dialogue_scene : MonoBehaviour
{
    [SerializeField] private Animator animator;
    
    public Dialogue dialogue;
    

    private void Start()
    {
        TriggerDialogue();
    }

    private void Update()
    {
        if (IsAnimationPlaying("Base Layer.hide"))
        {
            SaveManager.Instance.SaveGame("07_RoomEvening", SaveManager.Instance.GetProgress());
            SceneManager.LoadScene("07_RoomEvening");
        }
    }
    public void TriggerDialogue()
    {
        DialogueManager.Instance.StartDialogue(dialogue);
    }
    public bool IsAnimationPlaying(string animationName)
    {
        // берем информацию о состоянии
        var animatorStateInfo = animator.GetCurrentAnimatorStateInfo(0);
        // смотрим, есть ли в нем имя какой-то анимации, то возвращаем true
        if (animatorStateInfo.IsName(animationName))
            return true;

        return false;
    }
}
