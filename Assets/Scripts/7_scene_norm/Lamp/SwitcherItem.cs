using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitcherItem : MonoBehaviour
{
    private bool canActivate = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canActivate = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canActivate = false;
        }
    }
}
