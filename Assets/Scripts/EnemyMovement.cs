using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 1f;
    private Rigidbody2D myrigidBody;
    
    void Start()
    {
        myrigidBody = GetComponent<Rigidbody2D>();
    }
    
    void Update()
    {
        myrigidBody.velocity = new Vector2(moveSpeed, 0f);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        moveSpeed = -moveSpeed;
        FlipEnemyFacing();
    }

    private void FlipEnemyFacing()
    {
        transform.localScale = new Vector2(-(Mathf.Sign(myrigidBody.velocity.x)), 1f);
    }
}
