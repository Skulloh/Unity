using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float maxDistanceX = 2;
    public float maxDistanceY = 2;
    public float xSpeed = 4;
    public float ySpeed = 4;
    public Vector2 maxXandY = new Vector2(-7,-7);
    public Vector2 minXandY = new Vector2(-8,8);
    private float SmoothX = 1;
    private float SmoothY = 1;
    public Transform PlayerTran;
    bool NeedMoveX()
    {
        return Mathf.Abs(transform.position.x - PlayerTran.position.x) > maxDistanceX;
    }

    bool NeedMoveY()
    {
        return Mathf.Abs(transform.position.y - PlayerTran.position.y) > maxDistanceY;
    }
    void Start()
    {
        
    }

    private void Awake()
    {
        PlayerTran = GameObject.FindGameObjectWithTag("Player").transform;
    }
    
    void Update()   
    {
        
    }
    
    private void TrackPlayer()
    {
        float newX  = transform.position.x;
        float newY  = transform.position.y;
       if (NeedMoveX())
           newX = Mathf.Lerp(transform.position.x, PlayerTran.position.x,xSpeed * Time.deltaTime);
       if (NeedMoveY())
           newX = Mathf.Lerp(transform.position.y, PlayerTran.position.y,ySpeed * Time.deltaTime);
       transform.position  = new  Vector3(newX,newY,transform.position.z);
       
    }
    private void FixedUpdate()
    {
        TrackPlayer();
    }
   
         
}
