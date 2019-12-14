using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class StreamVideo : MonoBehaviour
{
    public RawImage thevideoPanel;

    public VideoPlayer thevideo;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(PlayVideo());
        thevideo.loopPointReached += CheckOver;
    }

    void CheckOver(UnityEngine.Video.VideoPlayer vp)
    {
        thevideoPanel.gameObject.SetActive(false);
    }

    IEnumerator PlayVideo()
    {
        thevideo.Prepare();

        WaitForSeconds wait = new WaitForSeconds(1);
        
        while (!thevideo.isPrepared)
        {
            yield return wait;            
            break;
        }
        thevideoPanel.color = new Color(1, 1, 1, 1);
        thevideoPanel.texture = thevideo.texture;
        thevideo.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
