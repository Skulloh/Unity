using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BackGround : MonoBehaviour
{
    public Transform[] backGround;
    public Transform cam;
    public float fparallax = 0.4f;
    public float layerFraction = 5f;
    public float fSmooth = 5f;
    private Vector3 previousCamPos;
    // Start is called before the first frame update
    void Start()
    {
        previousCamPos = cam.position;
    }

    private void Awake()
    {
        cam = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        float fParrlaX = (previousCamPos.x - cam.position.x) * fparallax;
        for (int i = 0; i < backGround.Length; i++)
        {
            float fNewX = backGround[i].position.x + fParrlaX * (1 + i * layerFraction);
            Vector3 newPos = new Vector3(fNewX, backGround[i].position.y,backGround[i].position.z);
            backGround[i].position = Vector3.Lerp(backGround[i].position,newPos,fSmooth * Time.deltaTime);
        }
        previousCamPos = cam.position;
    }
}
