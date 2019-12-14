using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;

public class HelpVideo : MonoBehaviour
{
    public Texture video0;
    public Texture video1;
    public GameObject rawimage;
    private RawImage image;

    public VideoPlayer v;
    public VideoPlayer v1;
    //private float beginTime;
    private float interval = 8f;
    private bool isplay = false;
    // Start is called before the first frame update
    void Start()
    {
        image = rawimage.GetComponent<RawImage>();
        image.texture = video0;
    }

    // Update is called once per frame
    void Update()
    {
        v.loopPointReached += CheckOver;
        //if (Time.time - beginTime >= interval && !isplay)
        //{
        //    image.texture = video1;
        //    v1.Play();
        //    isplay = true;
        //}

    }
    void CheckOver(UnityEngine.Video.VideoPlayer v)
    {
        image.texture = video1;
        v1.Play();
        v1.loopPointReached += CheckOver1;
    }
    void CheckOver1(UnityEngine.Video.VideoPlayer v)
    {
        Destroy(gameObject);
    }

}
