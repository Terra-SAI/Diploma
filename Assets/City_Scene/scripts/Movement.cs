using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    [SerializeField] private float playerSpeed = 10f; 
    [SerializeField] private float maxZ = 130f; // Максимальная граница
    private Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
       // animator = GetComponent<Animator>();
        rb.freezeRotation = true;
    }

    // Update is called once per frame
    //void FixedUpdate()
    //{
    //    if (transform.position.z < maxZ)
    //    {
    //        Vector3 movement = new Vector3(0f, 0f, 0.1f).normalized;
    //        if (movement.magnitude > 0.01f)
    //        {
    //            Quaternion targetRotation = Quaternion.LookRotation(movement);
    //            rb.transform.rotation = targetRotation;
    //            rb.AddForce(movement * playerSpeed, ForceMode.VelocityChange);
    //        }
    //    }
    //    //float moveHorizontal = Input.GetAxis("Horizontal");
    //   // float moveVertical = Input.GetAxis("Vertical");


    //}
    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x,transform.position.y, maxZ), playerSpeed * Time.deltaTime);

    }
}
