using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public Transform GravityPoint;

    public Transform ProjectilePoint;

    public Transform Role;
    public GameObject GravityButton;
    public GameObject ProjectileButton;

    public GameObject pauseUI;
    //private bool isPause = false;
    //private bool isRunning = true;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void GravityTest()
    {
        //Initialize Gravity mode;
        if (GravityButton.activeInHierarchy == true)
            Debug.Log("Now is the Gravity Mode");
        else
        {
            Role.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            ProjectileButton.SetActive(false);
            Role.position = GravityPoint.position;
            GravityButton.SetActive(true);
        }      
    }
    
    public void ProjectileTest()
    {
        //Initialize Projectile mode;
        if (ProjectileButton.activeInHierarchy == true)
            Debug.Log("Now is the Projectile Mode");
        else
        {
            Role.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            GravityButton.SetActive(false);
            Role.position = ProjectilePoint.position;
            ProjectileButton.SetActive(true);
        }
    }
}
