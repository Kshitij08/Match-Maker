using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    public GameObject go1;
    public GameObject go2;
    public GameObject go3;
    GameObject go4;

    public GameObject obstacle;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)){
            go1.transform.position = new Vector2(go1.transform.position.x + 2, go1.transform.position.y);
            go2.transform.position = new Vector2(go2.transform.position.x + 2, go2.transform.position.y);
            go3.transform.position = new Vector2(go3.transform.position.x + 2, go3.transform.position.y);
            Rigidbody2D obstacleClone = (Rigidbody2D)Instantiate(obstacle.GetComponent<Rigidbody2D>(), transform.position, transform.rotation);
            obstacleClone.GetComponent<Transform>().position = new Vector2(transform.position.x + 2, transform.position.y);

            go4 = go3;
            Destroy(go4);
            go3 = go2;
            go2 = go1;
            go1 = obstacleClone.gameObject;
           
        }
    }
}
