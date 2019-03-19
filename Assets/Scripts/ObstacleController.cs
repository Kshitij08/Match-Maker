using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    public float destroyTime = 2f;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, destroyTime);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x <= -5 || transform.position.x >= 5)
        {
            Destroy(gameObject);
        }

    }

}
