using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Video;

public class video : MonoBehaviour
{
    
    public VideoPlayer vid;
    public string sceneName;

    void Start() { vid.loopPointReached += CheckOver; }

    void CheckOver(UnityEngine.Video.VideoPlayer vp)
    {
        Destroy(GetComponent<VideoPlayer>());
        Application.LoadLevel(sceneName);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.LoadLevel(sceneName);
        }
    }
}
    
