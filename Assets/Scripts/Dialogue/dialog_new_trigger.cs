using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dialog_new_trigger : MonoBehaviour
{
    public Dialogue dialogue;

    public void TriggerDialogue()
    {
        DialogueManager.Instance.StartDialogue(dialogue);
    }
}
