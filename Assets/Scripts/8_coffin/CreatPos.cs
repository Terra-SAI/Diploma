using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatPos : MonoBehaviour
{
    [SerializeField] private GameObject creatureLeft;
    [SerializeField] private GameObject creatureRight;

    [Space]
    [SerializeField] private float posX = 0f;
    void Start()
    {
        creatureLeft.gameObject.SetActive(true);
        creatureRight.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x >= posX)
        {
            creatureLeft.gameObject.SetActive(false);
            creatureRight.gameObject.SetActive(true);
        }
        else
        {
            creatureLeft.gameObject.SetActive(true);
            creatureRight.gameObject.SetActive(false);
        }

    }
}
