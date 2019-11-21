using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateMachine;

public class Role : MonoBehaviour
{
    public Attractor Planet1;
    public Attractor Planet2;

    StateMachine<Role> stateMachine { get; set; }

    public float temporaryspeed;

    private Vector2 temperaryPosition;
    private Quaternion temperaryRotation;

    private Vector2 RocketDir;

    public float RotateSpeed;

    float rotateTime;

    private Rigidbody2D Rig;

    public Transform RockHead;

    public Transform RocketRear;

    private void Awake()
    {
        temperaryPosition = this.transform.position;
        temperaryRotation = this.transform.rotation;
        Initialize();
    }

    private void Initialize()
    {
        RocketRear = this.transform.Find("Rear");
        RockHead = this.transform.Find("Head");
        if (!this.GetComponent<Rigidbody2D>())
        {
            Debug.LogError("There need a rigibody2d in our role");
        }
        else
        {
            Rig = this.GetComponent<Rigidbody2D>();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        stateMachine = new StateMachine<Role>(this);
        stateMachine.ChangeState(PreFireState.Instance);
    }

    // Update is called once per frame
    void Update()
    {
        //FlyingDirection();
        stateMachine.Update();
    }

    #region For Control the flying Direction
    private void FlyingDirection()
    {
        Vector2 TestRocketDir;
        Vector2 Rocketup = this.transform.up;
        rotateTime += Time.deltaTime * RotateSpeed;
        if (Rig.velocity.magnitude > temporaryspeed)
        {
            TestRocketDir = Rig.velocity.normalized;
            Quaternion test = Quaternion.FromToRotation(Rocketup, TestRocketDir) * this.transform.rotation;
            this.transform.rotation = Quaternion.Lerp(this.transform.rotation, test, rotateTime);
        }

        TestRocketDir = new Vector2(0, 0);
        //Vector2 TestRocketDir = (RockHead.position - RocketRear.position).normalized;        
        //this.transform.rotation = Quaternion.FromToRotation(Rocketup, TestRocketDir) * this.transform.rotation;
        //Quaternion targetDir = Quaternion.LookRotation(TestRocketDir);
        //this.transform.rotation = Quaternion.Lerp(transform.rotation, targetDir, Time.deltaTime * RotateSpeed);
    }
    #endregion

    #region Temporary UI
    public void temperaryReset()
    {
        Rig.velocity = Vector2.zero;
        Rig.rotation = 0;
        this.transform.position = temperaryPosition;
        this.transform.rotation = temperaryRotation;
        Planet1.ToPlanetState();
        Planet2.ToPlanetState();
    }
    #endregion
}
