using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MCamera : MonoBehaviour
{
    private Transform player;
    public float MaxDistanceX = 2;
    public float MaxDistanceY = 2;
    private float SmoothX = 1;
    private float SmoothY = 1;
    public Vector2 MinCamXandY = new Vector2(-7,-7);
    public Vector2 MaxCamXandY = new Vector2(9,9);
    bool NeedMoveX()
    {
        return Mathf.Abs(transform.position.x - player.position.x) > MaxDistanceX;
    }
    bool NeedMoveY()
    {	
        return Mathf.Abs(transform.position.y - player.position.y) > MaxDistanceY;
    }

    void Start()
    {

    }
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    
    void Update()
    {

    }
    
    private void TrackPlayer()
    {
        float CamNewX = transform.position.x;
        float CamNewY = transform.position.y;
        if (NeedMoveX())
            CamNewX = Mathf.Lerp(transform.position.x,player.position.x, SmoothX * Time.deltaTime);
        if (NeedMoveY())
            CamNewY = Mathf.Lerp(transform.position.y, player.position.y, SmoothY * Time.deltaTime);
        
        transform.position = new Vector3(CamNewX, CamNewY,transform.position.z);

    }

    private void FixedUpdate()
    {
        TrackPlayer();
    }
}

