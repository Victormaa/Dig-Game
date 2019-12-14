using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class helpController : MonoBehaviour
{
    [SerializeField]
    GameObject button;
    [SerializeField]
    GameObject video;

    private GameObject v;
    private float beginTime;
    private float interval = 14f;
    Button b;
    public bool isClose = false;
    // Start is called before the first frame update
    void Start()
    {
        beginTime = Time.time;
        b = button.GetComponent<Button>();
        b.onClick.AddListener(Close);
        v = Instantiate(video,transform.parent);

    }

    // Update is called once per frame
    void Update()
    {
        //print(Time.time);
        //if(Time.time - beginTime >= interval)
        //{
        //    print(111);
        //    Destroy(v);
        //    Destroy(gameObject);
        //}
        if (v == null)
        {
            Destroy(gameObject);
        }
    }
    void Close()
    {
        //Destroy(v);
        //Destroy(gameObject);
    }
}
