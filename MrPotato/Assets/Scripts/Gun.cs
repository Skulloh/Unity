using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Gun : MonoBehaviour
{
    public Rigidbody2D rocket;
    public Rigidbody2D smoke;
    public Rigidbody2D flame;
    private float fSpeed = 10;
    private PlayerControll playerCtrl;
    private Animator anim;
    private AudioSource ac;
    // Start is called before the first frame update
    void Start()
    {
        playerCtrl = transform.root.GetComponent<PlayerControll>();
        ac = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1")) 
        {
            Vector3 direction = new Vector3(0, 0, 0);
            if (playerCtrl.bFaceRight)
            {
                Rigidbody2D Rocketinstance = Instantiate(rocket,transform.position,Quaternion.Euler(direction));
                Rocketinstance.velocity = new Vector2(fSpeed,0);
                Rigidbody2D smokeinstance = Instantiate(smoke,transform.position,Quaternion.Euler(direction));
                smokeinstance.velocity = new Vector2(fSpeed,0);
                
                Rigidbody2D flameinstance = Instantiate(flame,transform.position,Quaternion.Euler(direction));
                flameinstance.velocity = new Vector2(fSpeed,0);
            }
            else
            {
                Rigidbody2D Rocketinstance = Instantiate(rocket,transform.position,Quaternion.Euler(direction));
                Rocketinstance.velocity = new Vector2(-fSpeed,0);
                Rigidbody2D smokeinstance = Instantiate(smoke,transform.position,Quaternion.Euler(direction));
                smokeinstance.velocity = new Vector2(-fSpeed,0);
                Rigidbody2D flameinstance = Instantiate(flame,transform.position,Quaternion.Euler(direction));
                flameinstance.velocity = new Vector2(-fSpeed,0);
            }
        }
        
    }
}
