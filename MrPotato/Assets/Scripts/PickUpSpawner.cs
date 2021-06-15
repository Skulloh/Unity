using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpSpawner : MonoBehaviour
{
    public GameObject[] pickups;
    public float leftX = -10;
    public float rightX = 10;
    public float intervalTime = 5;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnPickup());     
    }

    IEnumerator spawnPickup()
    {
        yield return new WaitForSeconds(intervalTime);
        float randowx = Random.Range(leftX, rightX);
        Vector3 randomPos = new Vector3(randowx, 15, 0);
        int index = Random.Range(0,pickups.Length);
        Instantiate(pickups[index], randomPos, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
