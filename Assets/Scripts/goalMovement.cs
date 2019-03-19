using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class goalMovement : MonoBehaviour
{

    public bool goalMov = false;
    public bool spawnHearts = false;

    public GameObject heart;

    // Start is called before the first frame update
    void Start()
    {
        if (goalMov)
        {
            InvokeRepeating("GoalMovement", 1, 3);
        }

        if (spawnHearts)
        {
            InvokeRepeating("HeartsSpawnner", 1, 2);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void GoalMovement()
    {
        gameObject.transform.position = new Vector2(Random.Range(-2f, 2f), Random.Range(-1f, 4.5f));
    }

    void HeartsSpawnner()
    {
        Rigidbody2D obstacleClone = (Rigidbody2D)Instantiate(heart.GetComponent<Rigidbody2D>(), transform.position, transform.rotation);

        int L = Random.Range(0, 2);
        if(L == 0)
        {
            obstacleClone.velocity = new Vector2(Random.Range(-0.5f, 0), Random.Range(-0.75f, -0.25f));
            obstacleClone.tag = "Coin";
        }
        if (L == 1)
        {
            obstacleClone.velocity = new Vector2(Random.Range(0,  0.5f), Random.Range(-0.75f, -0.25f));
            obstacleClone.tag = "Coin";
        }
    }

}
