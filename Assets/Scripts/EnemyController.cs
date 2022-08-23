using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Rigidbody rigidBody;
    private GameObject player;

    public float speed;
    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        player = GameObject.Find("Player");
    }

    private void FixedUpdate()
    {
        if(transform.position.y <= -5f)
        {
            Destroy(gameObject);
        }
        Vector3 moveTowards = (player.transform.position - transform.position).normalized;
        moveTowards.y = 0;
        rigidBody.AddForce(moveTowards * speed);
    }
}
