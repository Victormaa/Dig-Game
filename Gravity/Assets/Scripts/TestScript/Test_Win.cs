using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
            // do things when you win you will do;s
   
                hitObj.GetComponent<Test_ball>().Win();
            if(SceneManager.GetActiveScene().name == "Level5")
            {
                hitObj.GetComponent<Test_ball>().WinCtrl();
                Test_Manager.Instance.LastImage.SetActive(true);
            }
            
            //hitObj.transform = new Vector2()
            //Test_ball.Player.Win();
        }

    }
}
