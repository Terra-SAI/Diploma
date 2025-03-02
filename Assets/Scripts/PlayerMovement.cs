using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float playerSpeed = 10f;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>(); // �������� Rigidbody
        rb.freezeRotation = true; // ��������� ���������� ��������, ����� ��������� �������
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal"); // �������� �������� �������������� ��� (A � D ��� ������� ����� � ������)
        float moveVertical = Input.GetAxis("Vertical"); // �������� �������� ������������ ��� (W � S ��� ������� ����� � ����)

        Vector3 movement = new Vector3(moveHorizontal, 0f, moveVertical).normalized;

        if (movement.magnitude > 0.01f)
        {
            Quaternion targetRotation = Quaternion.LookRotation(movement);
            rb.transform.rotation = targetRotation;
        }
        rb.AddForce(movement * playerSpeed);
        //rb.AddForceAtPosition(movement * playerSpeed, rb.position);



    }
}
