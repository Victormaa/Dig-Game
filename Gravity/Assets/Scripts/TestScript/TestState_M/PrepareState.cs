using UnityEngine;
using StateMachine;

public class PrepareState : State<Test_ball>
{
    private static PrepareState _instance;

    private PrepareState()
    {
        if (_instance != null)
        {
            return;
        }
        _instance = this;
    }

    public static PrepareState Instance
    {
        get
        {
            if (_instance == null)
            {
                new PrepareState();
            }
            return _instance;
        }
    }

    public override void EnterState(Test_ball _owner)
    {
        _owner.Preparing();

        Test_Manager.IsRocketCrushed = false;

        Debug.Log("now is time for to a position and adjust direction and gravity of your under feet planet");

        Test_Manager.Instance.PrepareUI.interactable = true;

        Test_Manager.Instance.resetangle();

        Test_Manager.Instance.DirTest.isOn = false;

        //让准备状态的物体都显示出来
        _owner.PreparingUI(true);

        if (!_owner.isOnPosition)
        {
            _owner.SettingPoint.position = _owner.SetLaunchPoint().position;
            _owner.SettingPoint.rotation = _owner.SetLaunchPoint().rotation;
            _owner.isOnPosition = true;
        }
            
        var LaunchPoint = _owner.SettingPoint.position;

        _owner.StopMoving();
        _owner.transform.position = LaunchPoint;
        _owner.transform.rotation = _owner.SettingPoint.rotation;
        // should set there position to the point then prepare the thing;

        Test_Manager.Instance.state1.isOn = true;

        Test_Manager.Instance.setNorCur();

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
    }

    public override void ExitState(Test_ball _owner)
    {
        Test_Manager.Instance.DirTest.isOn = true;
        Debug.Log("We exit the preparing state!  For now the exactly state is to Launching but never mind when we are testing");
        Test_Manager.Instance.state1.isOn = false;
        Test_Manager.Instance.PrepareUI.interactable = false;
        _owner.PreparingUI(false);

        // for test the thing work or not;
        /*
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        */

    }

    public override void UpdateState(Test_ball _owner)
    {
        Test_Manager.Instance.PrepareUI.interactable = true;
    }

}
