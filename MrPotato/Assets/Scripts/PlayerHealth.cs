using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlayerHealth : MonoBehaviour
{
    private float health = 100f;
    public float hurtBloodPoint = 20f;
    private SpriteRenderer healthbar;
    private Vector3 healthBarScale;
    public float damagRepeat = 0.5f;
    private float lastHurt;
    private Animator anim;
    public AudioClip[] ouchClips;
    public float hurtForce = 100f;
    
    void Start()
    {
        healthbar = GameObject.Find("HealthBar").GetComponent<SpriteRenderer>();
        healthBarScale = healthbar.transform.localScale;
        lastHurt = Time.time;
        anim = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            if (Time.time > lastHurt + damagRepeat)
            {
                if (health > 0 )
                {
                    TakeDamage(collision.gameObject.transform);
                    lastHurt = Time.time;
                    if (health <= 0)
                    {
                        anim.SetTrigger("Die");
                        Collider2D[] colliders = GetComponents<Collider2D>();
                        foreach (Collider2D c in colliders)
                        {
                            c.isTrigger = true;
                        }
                        SpriteRenderer[] sp = GetComponentsInChildren<SpriteRenderer>();
                        foreach (SpriteRenderer s in sp)
                        {
                            s.sortingLayerName = "UI";
                            GetComponent<PlayerControll>().enabled = false;
                            GetComponentInChildren<Gun>().enabled = false;
                        }
                    }
                }
            }
        }
    }

    void TakeDamage(Transform enemy)
    {
        health -= hurtBloodPoint;
        UpdateHealthBar();
        Vector3 hurtVector = transform.position - enemy.position + Vector3.up;
        Vector2 hurtV2 = new Vector2(hurtVector.x, hurtVector.y);
        GetComponent<Rigidbody2D>().AddForce(hurtV2 * hurtForce);
        int i = Random.Range(0, ouchClips.Length);
        AudioSource.PlayClipAtPoint(ouchClips[i],transform.position);
    }

    void UpdateHealthBar()
    {
        healthbar.material.color = Color.Lerp(Color.red, Color.magenta, 1 - health * 0.01f);
        healthbar.transform.localScale = new Vector3(health * 0.01f, 1, 1);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
