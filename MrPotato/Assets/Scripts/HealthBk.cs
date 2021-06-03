using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBk : MonoBehaviour
{
    private Transform playerTransform;
    public Vector3 offset = new Vector3(0, 1, 1);

    private void Awake()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = playerTransform.position + offset;
    }
}
