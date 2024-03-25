using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Rigidbody playerRB;


    [SerializeField] private float jumpForce;
    [SerializeField] private float speed;

    bool isGrounded()
    {
        return Physics.Raycast(transform.position, -Vector3.up, 0.65f);
    }
    

    private void Awake()
    {
        playerRB = GetComponent<Rigidbody>();
    }


    private void Update()
    {
        Debug.DrawRay(transform.position, -Vector3.up, Color.red);
        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }

        if (Input.GetButtonDown("Fire1"))
        {
            Debug.Log(isGrounded());
        }
    }


    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal") * speed;
        float moveVertical = Input.GetAxis("Vertical") * speed;

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        playerRB.AddForce(movement * speed * Time.deltaTime);
    }

    private void Jump()
    {
        if (isGrounded() == true) 
        {
            playerRB.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

}
