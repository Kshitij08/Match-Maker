using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class levelSelectScreen : MonoBehaviour
{

    public void OnLevel1Click()
    {
        SceneManager.LoadScene("Level 1");
    }
    public void OnLevel2Click()
    {
        SceneManager.LoadScene("Level 2");
    }
    public void OnLevel3Click()
    {
        SceneManager.LoadScene("Level 3");
    }
    public void OnLevel4Click()
    {
        SceneManager.LoadScene("Level 4");
    }
    public void OnLevel5Click()
    {
        SceneManager.LoadScene("Level 5");
    }
    public void OnLevel6Click()
    {
        SceneManager.LoadScene("Level 6");
    }

}
