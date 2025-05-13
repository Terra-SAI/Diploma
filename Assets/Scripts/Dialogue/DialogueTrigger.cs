using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DialogueCharacter
{
    public string name;
    public Sprite icon;
}

[System.Serializable]
public class DialogueLine
{
    public DialogueCharacter character;
    [TextArea(3, 10)]
    public string line;
}

[System.Serializable]
public class Dialogue
{
    public List<DialogueLine> dialogueLines = new List<DialogueLine>();
}

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    public bool canCommunicate = true;
    public bool isStarted = false;

    public void TriggerDialogue()
    {
        DialogueManager.Instance.StartDialogue(dialogue);
    }
    private void OnTriggerEnter(Collider collision)
    {
      //  Debug.Log("We are in");
        if (!isStarted && collision.tag == "Player")
        {
            TriggerDialogue();
            isStarted = true;
           // canCommunicate = false;
        }
    }

}