using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightSpwnner : MonoBehaviour
{

    public GameObject obstacleS;
    public GameObject obstacleM;
    public GameObject obstacleL;
    public int spawnVelocityMin = 2;
    public int spawnVelocityMax = 5;
    int spawnVelocity;
    public float initDelay;
    public float spawnTime;

    //public float scaleMin = 0.3f;
    //public float scaleMax = 0.7f;
    //float scaleValue;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRight", initDelay, spawnTime);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnRight()
    {

        int x = Random.Range(0, 3);

        if(x == 0)
        {
            spawnVelocity = Random.Range(spawnVelocityMin, spawnVelocityMax);
            Rigidbody2D obstacleClone = (Rigidbody2D)Instantiate(obstacleS.GetComponent<Rigidbody2D>(), transform.position, transform.rotation);
            obstacleClone.velocity = new Vector2(-spawnVelocity, 0);
            obstacleClone.tag = "Left Obstacle";
        }

        if (x == 1)
        {
            spawnVelocity = Random.Range(spawnVelocityMin, spawnVelocityMax);
            Rigidbody2D obstacleClone = (Rigidbody2D)Instantiate(obstacleM.GetComponent<Rigidbody2D>(), transform.position, transform.rotation);
            obstacleClone.velocity = new Vector2(-spawnVelocity, 0);
            obstacleClone.tag = "Left Obstacle";
        }

        if (x == 2)
        {
            spawnVelocity = Random.Range(spawnVelocityMin, spawnVelocityMax);
            Rigidbody2D obstacleClone = (Rigidbody2D)Instantiate(obstacleL.GetComponent<Rigidbody2D>(), transform.position, transform.rotation);
            obstacleClone.velocity = new Vector2(-spawnVelocity, 0);
            obstacleClone.tag = "Left Obstacle";
        }



    }
}
