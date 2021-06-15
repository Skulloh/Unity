using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public Sprite damagedEnemy;
    public Sprite deadEnemy;
    private int HP = 2;
    private float minSpinForce = -200;
    private float maxSpinForce = 200;
    public GameObject UI_100Points;
    private bool isDead = false;
    private SpriteRenderer curBody;
    private Rigidbody2D enemyBody;
    private Transform frontCheck;
    public AudioClip[] EnemyClips;
    private void Awake()
    {
        enemyBody = GetComponent<Rigidbody2D>();
        frontCheck = transform.Find("frontCheck");
        curBody = transform.Find("body").GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        enemyBody.velocity = new Vector2(transform.localScale.x * moveSpeed, enemyBody.velocity.y);
        Collider2D[] collders = Physics2D.OverlapPointAll(frontCheck.position);
        foreach (Collider2D c in collders)
        {
            if (c.tag == "wall")
            {
                flip();
                break;
            }
        }

        if (HP == 1 && damagedEnemy != null)
            curBody.sprite = damagedEnemy;
        if (HP <= 0 && !isDead)
        {
            death();
            isDead = true;
        }
    }

    public void Hurt()
    {
        HP--;
    }

    void death()
    {
        isDead = true;
        curBody.sprite = deadEnemy;
        Collider2D[] cols = GetComponents<Collider2D>();
        foreach (Collider2D c in cols)
            c.isTrigger = true;
        enemyBody.AddTorque(Random.Range(minSpinForce,maxSpinForce));
        Vector3 UI100Pos = new Vector3(transform.position.x, transform.position.y+1.5f,0);
        Instantiate(UI_100Points, UI100Pos, Quaternion.identity);
        int i = Random.Range(0, EnemyClips.Length);
        AudioSource.PlayClipAtPoint(EnemyClips[i],transform.position);
    }

    void flip()
    {
        Vector3 enemyScale = transform.localScale;
        enemyScale.x *= -1;
        transform.localScale = enemyScale;  
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
