using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonRotation : MonoBehaviour
{
    private float angle;
    private float projectionAngle;
    // Start is called before the first frame update
        
        
    /*
    [SerializeField]
    Sprite[] agentIcon_Sprites;

    [SerializeField]
    Image agentIcon;


    Vector2 startPoint = new Vector2();
    Vector2 endPoint = new Vector2();

    public void TaskOnClickDown()
    {
        
        endPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        var adjust = endPoint.x - startPoint.x;
        Debug.Log(adjust);
    }

    public void TaskOnClickUp()
    {
        agentIcon.sprite = agentIcon_Sprites[0];
        agentIcon.color = Color.white;
    }

    public void TaskOnClick()
    {
        agentIcon.sprite = agentIcon_Sprites[1];
        agentIcon.color = new Color((float)224 / 255, (float)224 / 255, (float)224 / 255, 1);
    }
    */

    // Update is called once per frame
    void FixedUpdate()
    {
        angle = AngleButtonInput.value;
        projectionAngle = -(float)((angle - 90)*1.5);
        float rotateAngleInZ = projectionAngle;
        Vector3 rotationInZ = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, rotateAngleInZ);
        transform.eulerAngles = rotationInZ;
    }

}
