using Unity.VisualScripting;
using UnityEngine;

public class PlayerCollisions : MonoBehaviour
{
    public PlayerController movement;
    public GameManager gameManager;
    

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Enemy")
        {
            movement.enabled = false;
           
            Debug.Log("shit");
            FindFirstObjectByType<GameManager>().GameOver();
            //connect this to Game Manager and trigger GameOver
        }
    }
}
