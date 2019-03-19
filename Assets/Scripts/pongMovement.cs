using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pongMovement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.tag == "Pong Left")
        {
            transform.position = new Vector2(Mathf.Clamp(transform.position.x, -2, -2), Mathf.Clamp(transform.position.y, -4.5f, 4.6f));
        }
        if (gameObject.tag == "Pong Right")
        {
            transform.position = new Vector2(Mathf.Clamp(transform.position.x, 2, 2), Mathf.Clamp(transform.position.y, -4.5f, 4.6f));
        }

    }

    void OnMouseDrag()
    {

        float distance_to_screen = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        Vector3 pos_move = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance_to_screen));
        transform.position = new Vector3(pos_move.x, pos_move.y, pos_move.z);

    }

    private void OnCollisionEnter2D(Collision2D colli)
    {

        if(colli.gameObject.tag == "Player")
        {
            if(gameObject.tag == "Pong Left")
            {
                colli.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(2f, 2f);
            }
            if (gameObject.tag == "Pong Right")
            {
                colli.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(-2f, 2f);
            }
        }
    }


}
