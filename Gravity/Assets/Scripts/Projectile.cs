using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Projectile : MonoBehaviour
{
    public Slider powerControl;    

    private bool isPressed = false;

    private Rigidbody2D rig;

    public float MaxPower = 8.0f;

    private Vector2 ShootDir;

    private float ProjectPower;

    private void Awake()
    {
        if (!this.GetComponent<Rigidbody2D>())
            Debug.LogError("you SHould get a Rig2D for a Project");
    }

    // Start is called before the first frame update
    void Start()
    {
        rig = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isPressed)
            DragProject();
    }

    private void DragProject()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        float mousePower = Vector2.Distance(mousePosition, this.transform.position);

        if(mousePower > MaxPower)
        {
            mousePower = MaxPower;
        }

 

        ProjectPower = mousePower * 3.0f;  // for shoot every thing;

        Vector2 ProjectDir = (mousePosition - this.transform.position).normalized;

        ShootDir = ProjectDir;        
    }

    private void OnMouseDown()
    {
        isPressed = true;
    }


    private void OnMouseUp()
    {
        isPressed = false;
        ReleaseProject();
    }

    private void ReleaseProject()
    {
        rig.AddForce( -ShootDir * ProjectPower * powerControl.value, ForceMode2D.Impulse);
    }


    /* this function is for test to stop Spin */
    public void StopSpin()
    {
        rig.velocity = Vector2.zero;
        rig.rotation = 0;
    }
     
}
