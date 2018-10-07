﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour{
    Rigidbody2D rb;
    bool onGroundSentinel;
    bool jumpingSentinel;
    float timeJumping;
    public float impulse;
    public float retard;
    public float retardOnAir;
    public float jumpImpulse;
    public float minJump;
    public float maxJump;
    public float bounceForce;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            onGroundSentinel = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            onGroundSentinel = false;
        }
    }

    private void Awake(){
        timeJumping = -minJump;
        rb = this.GetComponent<Rigidbody2D>();
        onGroundSentinel = false;
        jumpingSentinel = false;
        rb.freezeRotation = true;
    }

    private void FixedUpdate()
    {
        if (onGroundSentinel && Input.GetButton("Jump"))
        {
            onGroundSentinel = false;
            timeJumping = Time.time;
            jumpingSentinel = true;
        }
        float xMove = Input.GetAxis("Horizontal");
        Vector2 vxMove = new Vector2(xMove, 0.0F);
        if (!Input.GetButton("Jump"))
        {
            jumpingSentinel = false;
        }
        if (onGroundSentinel)
        {
            rb.AddForce(vxMove * impulse);
            rb.AddForce(Vector2.right * rb.GetPointVelocity(this.transform.position) * -retard);
        }
        else
        {
            rb.AddForce(vxMove * impulse * retardOnAir);
            rb.AddForce(Vector2.right * rb.GetPointVelocity(this.transform.position) * -retard * retardOnAir);
        }
        if ((jumpingSentinel || timeJumping + minJump > Time.time) && !(timeJumping + maxJump < Time.time))
        {
            rb.AddForce(Vector2.up * jumpImpulse);
        }
    }
}
