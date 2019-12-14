using StateMachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Test_ball : MonoBehaviour
{
    StateMachine<Test_ball> _state { get; set; }

    private Transform PlanetLaunchPoint;

    public GameObject InitialPlanet;

    public GameObject CurrentPlanet;
    public SlowDown _SlowDown;//for getting a current planet from this script

    public Toggle resetToggle;

    public Transform SettingPoint;

    private Vector3 ball_sparwnPosition;

    [HideInInspector]
    public bool isOnPosition = false;


    #region begion to work 11/16
    [SerializeField]
    private GameObject Preparestuff;

    // it used to be a switch to control whether players could hit jet ability
    private bool IsAbleJet = false;

    public float JetPower = 12;
    #endregion

    #region 1210 for the explosions

    [SerializeField]
    Sprite[] agentIcon_Sprites;

    [SerializeField]
    SpriteRenderer Rocketrenderer;

    Animator rocketanimator;
    #endregion



    private void Awake()
    {
        startInit();
    }
    // Start is called before the first frame update
    void Start()
    {
        _state = new StateMachine<Test_ball>(this);
        _state.ChangeState(PrepareState.Instance);
    }

    void startInit()
    {
        InitialPlanet = GameObject.Find("aerolite");
        if (this.GetComponent<SlowDown>())
        {
            _SlowDown = this.GetComponent<SlowDown>();
        }
        else
        {
            Debug.LogError("you need a slow down on the player");
        }

        //Rocketrenderer.sprite = agentIcon_Sprites[0];
        if (Rocketrenderer.gameObject.GetComponent<Animator>())
        {
            rocketanimator = Rocketrenderer.gameObject.GetComponent<Animator>();
        }
        else
        {
            Debug.LogError("there is a animator missing in the object with renderer");
        }
       
    }

    // Update is called once per frame
    void Update()
    {
        if (!Test_Manager.GameIsPaused)
            _state.Update();

        if (resetToggle.isOn)
        {
            //Test();
        }
        else
        {
            // for the final part we should put the rocket rewards jet out side of the if;
            //if(IsAbleJet)
                //Jet();
        }
        CurrentPlanet = _SlowDown.CurrentPlanet;
    }

    #region Jet Input for now it didn't used
    private void Jet()
    {
        if (Input.GetMouseButtonDown(1))
        {
            var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            var JetDir = (mousePos - this.transform.position).normalized;
            JetDir.z = 0;

            var rig = this.GetComponent<Rigidbody2D>();

            rig.AddForce(JetDir * JetPower, ForceMode2D.Impulse);
        }
        
    }
    #endregion

    #region Test() for design
    private void Test()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 ball_comebackposition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            ball_comebackposition.z = 0;

            ball_sparwnPosition = ball_comebackposition;

            Rigidbody2D theball = this.GetComponent<Rigidbody2D>();
            if (theball.velocity.magnitude < 0.01)
            {
                this.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
            }
            else
            {
                StopMoving();
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            //for test
            _state.ChangeState(PrepareState.Instance);

            this.transform.position = ball_sparwnPosition;
        }
    }
    #endregion

    public void StopMoving()
    {        
        this.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        this.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePosition;
        this.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    public Transform SetLaunchPoint()
    {
        return InitialPlanet.transform.Find("LaunchPoint").transform;
    }

    public void Preparing()
    {
        rocketanimator.SetBool("isexplosed", false);
        rocketanimator.SetBool("isinHole", false);
        //取消准备状态的Jet和slowdown的操作
        IsAbleJet = false;

        // make the animator turnback to the original
        

        // 主角来到发射点  发射点可以调整方向   方向调整完之后可以调整引力大小  可以点击发射按钮  
    }

    public void RePrepare()
    {
        _state.ChangeState(PrepareState.Instance);
    }

    public void PreparingUI(bool b)
    {
        Preparestuff.SetActive(b);

        // 。。。。
        isOnPosition = false;
    }

    public void Flying()
    {
        isOnPosition = false;        

        _state.ChangeState(FlyingState.Instance);       
    }

    public void ModifyFlyFunc(bool b)
    {
        IsAbleJet = b;
        var gravitycontrol = this.gameObject.GetComponent<SlowDown>();

        //gravitycontrol.SlowDownAble = b;

        if(gravitycontrol.CurrentPlanet == null)
        {
            
        }
        else
        {
            gravitycontrol.CurrentPlanet.GetComponent<Test_Gravity>().IsAbleSlowDown = b;
        }
        
    }

    public void Crushing()
    {
        rocketanimator.SetBool("isexplosed", true);
        //撞毁 返回上一个星球的发射点
        _state.ChangeState(CrushState.Instance);
    }

    public void ModifyCrushCtrl()
    {
        
        StopMoving(); 
    }

    public void Win()
    {
        rocketanimator.SetBool("isinHole", true);
        _state.ChangeState(WinState.Instance);        
    }

    public void WinCtrl()
    {
        Invoke("StopMoving", 0.5f);
        //StopMoving();
        Test_Manager.Instance.DirTest.isOn = false;

    }

}
