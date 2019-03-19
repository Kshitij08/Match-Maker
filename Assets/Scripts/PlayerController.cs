using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    Rigidbody2D rb;
    float dirX;
    public float moveSpeedX = 20f;
    public bool mouseDrag = false;
    public bool Tilt = false;
    public bool reverseTilt = false;
    public bool magnetic = false;
    public bool pong = false;
    public bool portal = false;


    public float pongMinVelX = 1;
    public float pongMaxVelX = 5;
    public float pongMinVelY = 1;
    public float pongMaxVelY = 5;


    public GameObject portalExit;

    public int score = 0;
    public Text scoreTextLocal;

    public level1COntroller levelManager_1;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        if (magnetic)
        {
            rb.gravityScale = 1;
            Physics2D.gravity = new Vector2(0, 0);
        }

        if (pong)
        {
            Invoke("PongInitial", 1);
        }


    }

    // Update is called once per frame
    void Update()
    {

        if (Tilt)
        {
            dirX = Input.acceleration.x * moveSpeedX;
            transform.position = new Vector2(Mathf.Clamp(transform.position.x, -2f, 2f), Mathf.Clamp(transform.position.y, -4.5f, 4.6f));
        }

        if (magnetic)
        {
            //Make this using Buttons
            if (Input.GetKeyDown(KeyCode.J))
            {
                Physics2D.gravity = new Vector2(-3f, 1);
            }
            if (Input.GetKeyDown(KeyCode.L))
            {
                Physics2D.gravity = new Vector2(3f, 1);
            }
        }

        if(transform.position.y <= -5 || transform.position.y >= 5 || transform.position.x <= -2.25f || transform.position.x >= 2.25f)
        {
            if (pong)
            {

                transform.position = new Vector2(0, -2.5f);
                rb.velocity = new Vector2(0, 0);
                Invoke("PongInitial", 1);

            }
            if (magnetic)
            {
                transform.position = new Vector2(0, -4.5f);
                rb.velocity = new Vector2(0, 0);
                Physics2D.gravity = new Vector2(0, 0);
            }
        }

        if (!levelManager_1.tutPanel.active)
        {
            Debug.Log("AA");
            if (portal || magnetic)
            {
                rb.velocity = new Vector2(0, 0.5f);
            }
        }

        scoreTextLocal.text = score.ToString();



    }

    void FixedUpdate()
    {
        if (Tilt)
        {
            rb.velocity = new Vector2(dirX, rb.velocity.y);
        }
        if (reverseTilt)
        {
            rb.velocity = new Vector2(-dirX, rb.velocity.y);
        }

    }

    void OnMouseDrag()
    {
        if (mouseDrag)
        {
            float distance_to_screen = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
            Vector3 pos_move = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance_to_screen));
            transform.position = new Vector3(pos_move.x, pos_move.y, pos_move.z);
        }

    }



    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Left Obstacle" || col.gameObject.tag == "Right Obstacle")
        {
            if (SceneManager.GetActiveScene().name == "Level 1" || SceneManager.GetActiveScene().name == "Level 2" || SceneManager.GetActiveScene().name == "Level 3" || SceneManager.GetActiveScene().name == "Level 5" || SceneManager.GetActiveScene().name == "Level 6")
            {
                levelManager_1.scorePanel.SetActive(true);
                levelManager_1.scoreText.text = score.ToString();
                levelManager_1.GetComponent<AudioSource>().Play();
                Destroy(gameObject);
            }

        }
        if (col.gameObject.tag == "Goal")
        {
            levelManager_1.scorePanel.SetActive(true);
            levelManager_1.scoreText.text = score.ToString();
            
            Debug.Log("Win");
        }
        if(col.gameObject.tag == "Portal Enter")
        {
            Debug.Log("PORTAL");
            transform.position = portalExit.transform.position;
        }

        if(col.gameObject.tag == "Coin")
        {
            score = score + 10;
            
            Destroy(col.gameObject);
        }

    }
    
    void PongInitial()
    {
        int randVar = Random.Range(1, 11);

        if (pong && randVar <= 5)
        {
            rb.velocity = new Vector2(Random.Range(pongMinVelX, pongMaxVelX), Random.Range(pongMinVelY, pongMaxVelY));
            Debug.Log(rb.velocity);
        }
        if (pong && randVar > 5)
        {
            rb.velocity = new Vector2(-Random.Range(pongMinVelX, pongMaxVelX), Random.Range(pongMinVelY, pongMaxVelY));
            Debug.Log(rb.velocity);
        }
    }

    public void LeftButtonClick()
    {
        //Physics2D.gravity = new Vector2(0, 0.5f);
        transform.position = new Vector2(transform.position.x - 0.5f, transform.position.y);
    }
    public void RightButtonClick()
    {
        //Physics2D.gravity = new Vector2(0, 0.5f);
        
        transform.position = new Vector2(transform.position.x + 0.5f, transform.position.y);
    }



}
