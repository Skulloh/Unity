using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControll : MonoBehaviour
{
    public float moveForce = 365f;
    public float maxSpeed = 5f;
    public float JumpForce = 500f;
    private Rigidbody2D heroBody;
    private float fInput = 0.0f;
    private bool bFaceRight = true;
    private bool bJump = false;
    private bool bGournded = false;
    private Transform mGroundCheck;

    private Transform mGround;
    void Start()
    {
        heroBody = GetComponent<Rigidbody2D>();
        mGround = transform.Find("GroundCheck");
    }
    void FixedUpdate()
    {
        if(Mathf.Abs(fInput * heroBody.velocity.x) < maxSpeed)
        {
            heroBody.AddForce(Vector2.right * fInput * moveForce);
        }
        if (Mathf.Abs(fInput * heroBody.velocity.x) > maxSpeed)
        {
            heroBody.velocity = new Vector2(Mathf.Sign(heroBody.velocity.x) * maxSpeed, heroBody.velocity.y);
        }

        if (fInput < 0 && bFaceRight)
        {
            Flip();
        }
        if (fInput > 0 && !bFaceRight)
        {
            Flip();
        }
        
    }

    void Jump()
    {
        if(bJump && bGournded)
        {
            heroBody.AddForce(new Vector2(0f, JumpForce ) );
            bJump = false;
        }
    }

    void Flip()
    {
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
        bFaceRight = !bFaceRight;
    }


    void Update()
    {
        fInput = Input.GetAxis("Horizontal");
        bGournded = Physics2D.Linecast(transform.position, mGround.position, 1 << LayerMask.NameToLayer("Ground"));
        bJump = Input.GetButtonDown("Jump");
        Jump();
    }
}
