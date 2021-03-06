using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlayerControll : MonoBehaviour
{
    public float moveForce = 365f;
    public float maxSpeed = 5f;
    public float JumpForce = 500f;
    private Rigidbody2D heroBody;
    private float fInput = 0.0f;
    public bool bFaceRight = true;
    private bool bJump = false;
    private bool bGournded = false;
    private Transform mGroundCheck;
    private Animator anim;
    private Transform mGround;
    public AudioClip[] JumoClips;
    void Start()
    {
        heroBody = GetComponent<Rigidbody2D>();
        mGround = transform.Find("GroundCheck");
        anim = GetComponent<Animator>();
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
        //if (heroBody.velocity.x > 0.1)
        
        anim.SetFloat("speed" ,Mathf.Abs(heroBody.velocity.x));
    }

    void Jump()
    {
        if(bJump && bGournded)
        {
            heroBody.AddForce(new Vector2(0f, JumpForce ) );
            anim.SetTrigger("jump");
            bJump = false;
            int i = Random.Range(0, JumoClips.Length);
            AudioSource.PlayClipAtPoint(JumoClips[i],transform.position);
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
