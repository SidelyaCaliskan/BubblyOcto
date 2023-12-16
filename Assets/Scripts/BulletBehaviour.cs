using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    private Rigidbody2D myRigidBody;
    [SerializeField] private float bulletSpeedX = 10f;
    [SerializeField] private float bulletSpeedY = 0f;
    private PlayerMovement player;
    private float xSpeed;
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        player = FindObjectOfType<PlayerMovement>();
        xSpeed = player.transform.localScale.x * bulletSpeedX;
    }
    
    void Update()
    {
        myRigidBody.velocity = new Vector2(xSpeed, bulletSpeedY);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            Destroy(other.gameObject);
        }
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Destroy(gameObject);
    }
}
