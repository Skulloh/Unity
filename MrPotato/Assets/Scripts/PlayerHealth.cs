using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private float health = 100f;
    public float hurtBloodPoint = 20f;
    private SpriteRenderer healthBar;
    private Vector3 healthBarScale;
    // Start is called before the first frame update
    void Start()
    {
        healthBar = GameObject.Find("HealthBar").GetComponent<SpriteRenderer>();
        healthBarScale = healthBar.transform.localScale;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            if (health > 0)
            {
                takeDamage();
            }
            else
            {
                
            }
        }
    }

    void takeDamage()
    {
        health -= hurtBloodPoint; 
        UpdateHealthBar();
    }

    void UpdateHealthBar()
    {
        healthBar.material.color = Color.Lerp(Color.green, Color.red, 1 - health * 0.01f);
        healthBar.transform.localScale = new Vector3(health * 0.01f, 1, 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
