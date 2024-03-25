using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public Transform player;

    [SerializeField] private float offsetx;
    [SerializeField] private float offsety;
    [SerializeField] private float offsetz;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform. position = player.transform.position + new Vector3(offsetx, offsety, -offsetz);
    }
}
