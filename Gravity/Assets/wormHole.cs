using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class wormHole : MonoBehaviour
{
    public Collider2D wormhole;

    public Text winImage;

    // Start is called before the first frame update
    void Start()
    {
        wormhole = this.GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("collider");
        if (collision.tag == "Player")
            winImage.gameObject.SetActive(true);
    }
}
