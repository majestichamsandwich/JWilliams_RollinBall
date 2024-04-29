using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Rigidbody playerRB;
    public Transform cam;
    public GameManager gameManager;


    [SerializeField] private float jumpForce;
    [SerializeField] private float speed;
    [SerializeField] private float rayDistance;
    Vector3 velocity;

    private bool isJumping;
    public bool isPoweredUp;
    public float powerBounceStrength;
    public float powerupTime = 7f;

    [SerializeField] private LayerMask ground;


    bool isGrounded()
    {
        return Physics.Raycast(transform.position, -Vector3.up, rayDistance);
    }
    

    private void Awake()
    {
        playerRB = GetComponent<Rigidbody>();
    }


    private void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            Jump();
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


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PowerUp"))
        {
            isPoweredUp = true;
            Destroy(other.gameObject);
            StartCoroutine(PowerUpCountDownRoutine());
        }
    }


    IEnumerator PowerUpCountDownRoutine()
    {
        yield return new WaitForSeconds(powerupTime);
        isPoweredUp = false;
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && isPoweredUp == true)
        {
            Rigidbody enemyRB = collision.gameObject.GetComponent<Rigidbody>();

            Vector3 bounceDir = (collision.gameObject.transform.position - transform.position);
            enemyRB.AddForce(bounceDir * powerBounceStrength, ForceMode.Impulse);
        }
    }
}
