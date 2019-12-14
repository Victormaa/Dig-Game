using UnityEngine;
using StateMachine;
using UnityEngine.UI;

public class FlyingState : State<Test_ball>
{
    private static FlyingState _instance;

    private FlyingState()
    {
        if (_instance != null)
        {
            return;
        }

        _instance = this;
    }

    public static FlyingState Instance
    {
        get
        {
            if(_instance == null)
            {
                new FlyingState();
            }
            return _instance;
        }
    }

    public override void EnterState(Test_ball _owner)
    {
        Test_Manager.Instance.state2.isOn = true;

        Test_Manager.RocketStatus = RocketAction.Launching;

        Test_Manager.Instance.SoundEffect();

        Test_Manager.Instance.setHandActive(true);

        _owner.ModifyFlyFunc(true);
        Debug.Log("Now is flying a lot of thing could be down there");

    }

    public override void ExitState(Test_ball _owner)
    {
        Debug.Log("We are out of flying state! Are we win or lose???");
        _owner.ModifyFlyFunc(false);
        Test_Manager.Instance.state2.isOn = false;
        Test_Manager.Instance.setNorCur();
        Test_Manager.Instance.setHandActive(false);
        Test_Manager.Instance.setoriginalGravity();
    }

    float thevalue;

    public override void UpdateState(Test_ball _owner)
    {
        // do something at flying state like when your mouse click down you should adjust the gravity;
        var timeMana = _owner.CurrentPlanet.GetComponent<Test_Gravity>().timeMana;

        var startPoint = new Vector2();
        var endPoint = new Vector2();
        var currentplanet = _owner.CurrentPlanet.GetComponent<Test_Gravity>();

        var originalvalue = (currentplanet.maxModifier - currentplanet.originalG);

        if (Input.GetMouseButtonDown(0))
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;

            Test_Manager.ischangingG = true;

            startPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //reset the value of the planet gravity
        }

        if (Input.GetMouseButton(0))
        {            
            endPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            var adjust = endPoint.x - startPoint.x;
            /***
             * 
             * this area is for the mouse control the whole button
             ***/

            var modifierctrl = currentplanet.Canvastem.transform.Find("Slider");

            var maxMo = modifierctrl.GetComponent<Slider>().maxValue;

            var right_difference = maxMo - originalvalue;

            var left_difference = originalvalue;

            if (adjust < 0)
            {
                Test_Manager.Instance.setDownCur();
                Test_Manager.CurisLarger = false;
                thevalue = adjust / 22 * left_difference + originalvalue;   // 22 is the value from middle to left
            }
            else
            {
                Test_Manager.Instance.setUpCur();
                Test_Manager.CurisLarger = true;
                thevalue = adjust / 13 * right_difference + originalvalue;   // 13 is the value from middle to right
            }
            /***
             * 
             * this area is for the mouse control the whole button
             ***/        

            Test_Manager.Instance.adjustvalue.text = "the x value" + adjust.ToString();

            Test_Manager.Instance.adjustVector.text = thevalue.ToString();

            timeMana.TimeControl();

            /*
            if (_owner._SlowDown.isinRadius())
            {
                currentplanet.GravityMouse(thevalue);
                particlespeed = (Test_Manager.Instance.FlyingUI.GetComponent<Slider>().value / currentplanet.maxModifier) * 0.9f;
                particle.simulationSpeed = particlespeed;
            }
            else
            {
                currentplanet.GravityMouse(originalvalue);
                particlespeed = (originalvalue / currentplanet.maxModifier) * 0.9f;
                particle.simulationSpeed = particlespeed;
            }
            */
        }

        if (Input.GetMouseButtonUp(0))
        {
            Test_Manager.Instance.setHandOffToggle();

            Test_Manager.ischangingG = false;

            // keep the adjust  value;
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            timeMana.CancelTimeControl();
        }

        if (_owner._SlowDown.isinRadius())
        {
            currentplanet.GravityMouse(thevalue);

        }
        else
        {
            currentplanet.GravityMouse(originalvalue);
        }
    }
}
