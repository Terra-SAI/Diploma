using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Outline))]
public class Interaclable : MonoBehaviour
{
     private Outline outline;

    private void OnEnable()
    {
        outline = GetComponent<Outline>();
        outline.OutlineWidth = 0f;
    }

    public void OnHoverEnter()
    {
        outline.OutlineWidth = 2f;
    }

    public void OnHoverExit()
    {
        outline.OutlineWidth = 0f;
    }
}
