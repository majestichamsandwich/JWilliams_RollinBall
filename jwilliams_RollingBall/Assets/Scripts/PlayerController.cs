using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Rigidbody playerRB;
    public Transform cam;


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
        float moveHorizontal = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        float moveVertical = Input.GetAxis("Vertical") * Time.deltaTime * speed;

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        if(movement.magnitude > 0.1f)
        {
            float targetAngle = Mathf.Atan2(movement.x, movement.z) * Mathf.Rad2Deg + cam.eulerAngles.y;

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;

            playerRB.AddForce(moveDir * speed * Time.deltaTime);
        }

      
    }

    private void Jump()
    {
        if (isGrounded() == true) 
        {
            playerRB.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

}
