using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pauseMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public static bool isPaused = false;
    //public GameObject menu;
    public string name;
    public string name1;
    private void Start()
    {
        //menu.SetActive(false);
    }
    void Update(){
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                resume();
            }
            else
            
            {
                pause();
            }
        }
    }
    void resume()
    {
        //menu.SetActive(false);
        //SceneManager.LoadScene(name1);
        SceneManager.LoadSceneAsync(name);
        isPaused = false;
    }

    void pause()
    {
        //menu.SetActive(true);
        SceneManager.LoadSceneAsync(name);
        isPaused = true;
    }






}

