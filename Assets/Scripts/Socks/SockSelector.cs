using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SockSelector : MonoBehaviour
{
    private List<GameObject> selectedSocks = new List<GameObject>();

    public bool isSockFind = false;

    public void SelectSock(GameObject sock)
    {
        if (!isSockFind)
        {
            if (selectedSocks.Contains(sock)) return;

            selectedSocks.Add(sock);

            if (selectedSocks.Count == 2)
            {
                CompareSocks();
            }
        }
    }

    private void CompareSocks()
    {
        Renderer r1 = selectedSocks[0].GetComponentInChildren<Renderer>();
        Renderer r2 = selectedSocks[1].GetComponentInChildren<Renderer>();

        if (r1 == null || r2 == null)
        {
            Debug.LogWarning("Один из носков не содержит Renderer");
            ClearSelection();
            return;
        }

        Color c1 = r1.material.color;
        Color c2 = r2.material.color;

        bool sameColor = ColorsApproximatelyEqual(c1, c2);

        if (sameColor)
        {
            Debug.Log("Успех! Игрок нашёл нужные носки");
            isSockFind = true;

            // Тут можно вызвать событие победы
        }
        else
        {
            Debug.Log("Неверно. Это не те носки");
        }

        ClearSelection();
    }

    private bool ColorsApproximatelyEqual(Color a, Color b, float tolerance = 0.05f)
    {
        return Mathf.Abs(a.r - b.r) < tolerance &&
               Mathf.Abs(a.g - b.g) < tolerance &&
               Mathf.Abs(a.b - b.b) < tolerance;
    }

    private void ClearSelection()
    {
        foreach (GameObject sock in selectedSocks)
        {
            DraggableSock draggable = sock.GetComponent<DraggableSock>();
            if (draggable != null)
            {
                draggable.DisableEmission();
            }
        }

        selectedSocks.Clear();
    }
    
}
