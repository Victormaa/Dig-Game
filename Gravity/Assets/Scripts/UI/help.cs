using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class help : MonoBehaviour
{
    public Canvas can;
    public VideoPlayer vid;
    // Start is called before the first frame update
    void Start()
    {
        can.renderMode = RenderMode.WorldSpace;
        vid.Play();
        vid.loopPointReached += CheckOver;
    }

    // Update is called once per frame
    void CheckOver(UnityEngine.Video.VideoPlayer vid)
    {
        can.renderMode = RenderMode.ScreenSpaceOverlay;
        Destroy(vid);
                    
    }
}
