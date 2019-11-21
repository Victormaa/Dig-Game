using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test_ShootingDirection : MonoBehaviour
{
    [SerializeField]
    private GameObject ShootMark;

    public Slider AngleSlider;

    public float shootPower;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MarkPosition();

    }

    private Vector3 ShootingDirection()
    {
        float angle;

        angle = AngleSlider.value;

        var DirectionQ = Quaternion.AngleAxis(angle, Vector3.forward);

        Vector3 Direction = -(DirectionQ * Vector2.up).normalized;   // 设置发射方向的函数 可以同时用来定义发设点
        Direction.z = 0;

        return Direction;
    }

    private void MarkPosition()
    {
        var markposition = new Vector3(ShootingDirection().x * 0.5f, ShootingDirection().y * 0.5f, 0) + this.transform.position;

        ShootMark.transform.position = markposition;
    }

    public void Project()
    {
        var rig = this.GetComponent<Rigidbody2D>();

        rig.AddForce(ShootingDirection() * shootPower, ForceMode2D.Impulse);

        this.gameObject.GetComponent<Test_ball>().Flying();
    }
}
