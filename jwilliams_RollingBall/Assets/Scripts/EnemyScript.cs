using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{

    public float speed;
    private Rigidbody enemyRB;
    private GameObject player;


    private void Awake()
    {
        enemyRB = GetComponent<Rigidbody>();
    }

    void Start()
    {
        player = GameObject.Find("Player");
    }

  
    private void FixedUpdate()
    {
        if(player != null)
        {
            enemyRB.AddForce((player.transform.position - transform.position).normalized * speed);
        }
    }
}
