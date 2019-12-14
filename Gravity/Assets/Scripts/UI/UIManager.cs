using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    // this script actually is the mainmenuManager    1209 mwp

    [SerializeField]
    GameObject helpCanvas;

    [SerializeField]
    bool tempMusicToggle = true;

    [SerializeField]
    AudioClip bgm;

    [SerializeField]
    float bgmLoopingPoint = 30;

    //Volume change
    [SerializeField]
    AudioMixer masterMixer;

    [SerializeField]
    Test_level thelevel;

    // Start is called before the first frame update
    void Start()
    {

        if (tempMusicToggle)
        {
            MusicManager.instance.PlayMusic(bgm, bgmLoopingPoint);
        }

    }

    // Start is called before the first frame update
    public void OnstartGame(string SceneName)
    {
        if (MusicManager.instance)
        {
            MusicManager.instance.StopMusicSmooth();
        }

        thelevel.level = 3;

        Time.timeScale = 1;

        SceneManager.LoadScene(SceneName);
        //Application.LoadLevel(SceneName);
        

    }
    public void OnstartGame()
    {
        Application.Quit();
    }

    public void loadHelp()
    {
        Instantiate(helpCanvas, new Vector3(0, 0, 0), Quaternion.identity);
    }
}
