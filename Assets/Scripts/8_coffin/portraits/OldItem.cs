using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class OldItem : MonoBehaviour
{
    public GameObject tooltipUI;

    [SerializeField] TMP_Text tooltipText;
    [SerializeField] string itemText;

    [SerializeField] private float tooltipTimer = 5f; // ¬рем€ в секундах, через которое панель скрываетс€

    private bool canActivate = false;

    [Space]
    public GameObject oldP;
    public GameObject backP;
    public GameObject heart;
    public int count = 0;

    private void Start()
    {
        oldP.SetActive(true);
        backP.SetActive(false);
        heart.SetActive(false);
    }
    public void ActivateComment()
    {
        if (canActivate)
        {
            tooltipUI.SetActive(true);
            tooltipText.text = itemText;

            StartCoroutine(CommentCoroutine());
        }
    }

    private void DeactivateComment()
    {
        tooltipUI.SetActive(false);
    }

    IEnumerator CommentCoroutine()
    {
        yield return new WaitForSecondsRealtime(tooltipTimer);
        DeactivateComment();
    }

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
