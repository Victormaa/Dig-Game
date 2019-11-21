using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_Win : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        var hitObj = collision.gameObject;

        if(hitObj.tag == "Player")
        {
            // do things when you win you will do;
            hitObj.GetComponent<Test_ball>().Win();
            //Test_ball.Player.Win();
        }

    }
}
