using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Direction : MonoBehaviour
{
    public Transform RocketRear;

    public Transform LeftDirection;

    public Transform RightDirection;

    public Transform DirCursor;

    public GameObject DirectionMark;

    public Slider AngleSlider;

    [HideInInspector]
    public Vector2 ShootingDir;

    private Vector2 LeftMax;

    private Vector2 RightMax;

    public float markpositionvalue = 2;

    private void Awake()
    {
        InitialDirection();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void InitialDirection()
    {
        LeftMax = LeftDirection.position - RocketRear.position;
        RightMax = RightDirection.position - RocketRear.position;
    }

    // Update is called once per frame
    void Update()
    {
        SetShootDir();
    }

    private void SetShootDir()
    {
        Vector2 dir = (RightDirection.position - LeftDirection.position).normalized;
        float distance = Vector2.Distance(RightDirection.position, LeftDirection.position);
        DirCursor.position = new Vector2(LeftDirection.position.x + dir.x * distance * AngleSlider.value, LeftDirection.position.y + dir.y * distance * AngleSlider.value);

        float angle = Vector2.Angle(LeftMax, RightMax);

        #region 两种错误方式
        /*
        float xDis = LeftDirection.position.x - RightDirection.position.x;
        float yDis = LeftDirection.position.y - RightDirection.position.y;

        DirCursor.position = new Vector2(LeftDirection.position.x - xDis * AngleSlider.value, LeftDirection.position.y + yDis * AngleSlider.value);
         */

        /* 原本错误的方式
        float distance =  Vector2.Distance(LeftMax, RightMax);

        distance = distance * AngleSlider.value;

        DirCursor.position = new Vector2(LeftDirection.position.x + distance, LeftDirection.position.y);
        */
        #endregion

        if (Input.GetKeyDown(KeyCode.Space))
            Debug.Log(DirCursor.position);

        ShootingDir = DirCursor.position - RocketRear.position;

        DirectionMark.transform.position = new Vector3(RocketRear.position.x + ShootingDir.normalized.x, RocketRear.position.y + ShootingDir.normalized.y, 0);
    }

}
