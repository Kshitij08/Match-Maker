using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class level1COntroller : MonoBehaviour
{


    public GameObject tutPanel;
    public GameObject spawnPoi;

    public GameObject scorePanel;
    public Text scoreText;
    PlayerController pc;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            tutPanel.SetActive(false);
            spawnPoi.SetActive(true);
        }

        if(SceneManager.GetActiveScene().name != "Splash Screen")
        {
            if (Input.GetKey(KeyCode.Escape))
            {
                SceneManager.LoadScene("Splash Screen");
            }

        }
        if(SceneManager.GetActiveScene().name == "Splash Screen")
        {
            if (Input.GetKey(KeyCode.Escape))
            {
                Application.Quit();
            }
        }

    }


    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Menu()
    {
        SceneManager.LoadScene("Level Select");
    }

    public void NextLevel()
    {
        if(SceneManager.GetActiveScene().name == "Level 1")
        {
            SceneManager.LoadScene("Level 2");
        }
        if (SceneManager.GetActiveScene().name == "Level 2")
        {
            SceneManager.LoadScene("Level 3");
        }
        if (SceneManager.GetActiveScene().name == "Level 3")
        {
            SceneManager.LoadScene("Level 4");
        }
        if (SceneManager.GetActiveScene().name == "Level 4")
        {
            SceneManager.LoadScene("Level 5");
        }
        if (SceneManager.GetActiveScene().name == "Level 5")
        {
            SceneManager.LoadScene("Level 6");
        }
        if (SceneManager.GetActiveScene().name == "Level 6")
        {
            SceneManager.LoadScene("Splash Screen");
        }
    }


}
