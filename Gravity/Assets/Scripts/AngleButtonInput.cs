using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;

public class AngleButtonInput : MonoBehaviour, IDragHandler
{ 
    //取得角度的接口 
    public static float value = 90f;

    private float min = 30f;
    private float max = 150;
    private float currentPosition;
    private float lastPosition;

    public float smoothturn;


    private void Start()
    {

    }

    public void OnDrag(PointerEventData eventData)
    {
        currentPosition = Input.mousePosition.x;
        value += (currentPosition - lastPosition) * smoothturn;
        if(value > max)
        {
            value = max;
        }
        if(value < min)
        {
            value = min;
        }
        lastPosition = Input.mousePosition.x;
    }

    public void setCursorVi()
    {
        Cursor.visible = true;
        
    }

    public void setCursorInVi()
    {
        Cursor.visible = false;
    }
}
