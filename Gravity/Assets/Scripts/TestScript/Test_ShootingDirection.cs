using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class Test_ShootingDirection : MonoBehaviour
{
    [SerializeField]
    private GameObject ShootMark;

    public float shootPower;

    private Scene sceneMain;
    private PhysicsScene sceneMainPhysics;
    private Scene scenePrediction;
    private PhysicsScene scenePredictionPhysics;

    private Vector3 lasPos;

    private Vector3 TestRocketDir;

    // Start is called before the first frame update
    void Start()
    {
        Physics.autoSimulation = false;
        //sceneMain = SceneManager.CreateScene("MainScene");
        //sceneMainPhysics = sceneMain.GetPhysicsScene();

        // LocalPhysicsMode.Physics3D,
        //   Simulate(float time) scenePrediction
        /*
        CreateSceneParameters sceneParam = new CreateSceneParameters(LocalPhysicsMode.Physics2D);
        scenePrediction = SceneManager.CreateScene("ScenePredicitonPhysics", sceneParam);
        scenePredictionPhysics = scenePrediction.GetPhysicsScene();
        */
    }

    // Update is called once per frame
    void Update()
    {
        MarkPosition();       
    }

    private void FixedUpdate()
    {
        if (!sceneMainPhysics.IsValid())
            return;

        sceneMainPhysics.Simulate(Time.fixedDeltaTime);

        if (Test_Manager.Instance.DirTest.isOn)
        {
            FlyingDirection();
            lasPos = LasPos();
        }

    }

    private Vector3 ShootingDirection()
    {
        float angle;

        //angle = Test_Manager.Instance.PrepareAngle.value;

        angle = AngleButtonInput.value;

        var DirectionQ = Quaternion.AngleAxis(angle, Vector3.forward);

        Vector3 Direction = -(DirectionQ * Vector2.up).normalized;   // 设置发射方向的函数 可以同时用来定义发设点
        Direction.z = 0;

        return Direction;
    }

    private void MarkPosition()
    {
        var markposition = new Vector3(ShootingDirection().x * 1.0f, ShootingDirection().y * 1.0f, 0) + this.transform.position;

        ShootMark.transform.position = markposition;

        ShootMark.transform.LookAt(markposition);
        var shootDir = ShootMark.transform.position - this.transform.position;


        float angle = AngleButtonInput.value;
        var DirectionQ = Quaternion.AngleAxis(angle, Vector3.forward);


        // Quaternion toRotate = Quaternion.FromToRotation(ShootMark.transform.up, shootDir);
        ShootMark.transform.rotation = Quaternion.Lerp(ShootMark.transform.rotation, DirectionQ, 0.2f );
    }

    public void Project()
    {
        var rig = this.GetComponent<Rigidbody2D>();

        rig.AddForce(ShootingDirection() * shootPower, ForceMode2D.Impulse);

        this.gameObject.GetComponent<Test_ball>().Flying();

        //prediction();
    }

    private void prediction()
    {
        if (!sceneMainPhysics.IsValid() || !scenePredictionPhysics.IsValid())
            return;

        /*
        GameObject predictionBall = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        SceneManager.MoveGameObjectToScene(predictionBall, scenePrediction);
        predictionBall.AddComponent<Rigidbody>().AddForce(ShootingDirection() * shootPower, ForceMode.Impulse);
        */

        GameObject predictionBall = GameObject.Instantiate(this.gameObject);

        if (predictionBall.GetComponent<Rigidbody2D>())
        {
            Debug.Log("there is a r2d with its mass = " + predictionBall.GetComponent<Rigidbody2D>().mass);
        }
        SceneManager.MoveGameObjectToScene(predictionBall, scenePrediction);
        predictionBall.AddComponent<Rigidbody2D>().AddForce(ShootingDirection() * shootPower, ForceMode2D.Impulse);
        
    }

    //改变方向
    private void FlyingDirection()
    {
        TestRocketDir = (transform.position - lasPos).normalized;
        Quaternion rot = Quaternion.FromToRotation(Vector3.up, TestRocketDir);
        transform.rotation = rot;
    }
    //计算上一帧火箭的位置 结合下一帧的位置就能得到运动的方向
    private Vector3 LasPos()
    {
        Vector3 lasPos = transform.position;
        return lasPos;
    }
}
