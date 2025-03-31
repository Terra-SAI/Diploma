using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureMovement : MonoBehaviour
{
    private Animator animator;
    [SerializeField] DialogueTrigger dialogueTrigger;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!dialogueTrigger.canCommunicate)
        {
            animator.SetBool("hasTalked", true);
        }
    }
}
