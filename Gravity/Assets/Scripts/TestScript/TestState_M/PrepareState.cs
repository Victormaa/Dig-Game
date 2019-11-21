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

        Debug.Log("now is time for to a position and adjust direction and gravity of your under feet planet");

        Test_Manager.Instance.PrepareUI.SetActive(true);

        //让准备状态的物体都显示出来
        _owner.PreparingUI(true);

        if (!_owner.isOnPosition)
        {
            _owner.SettingPoint.position = _owner.SetLaunchPoint().position;
            _owner.isOnPosition = true;
        }
            
        var LaunchPoint = _owner.SettingPoint.position;

        _owner.StopMoving();
        _owner.transform.position = LaunchPoint;
        // should set there position to the point then prepare the thing;

        Test_Manager.Instance.state1.isOn = true;
    }

    public override void ExitState(Test_ball _owner)
    {
        Debug.Log("We exit the preparing state!  For now the exactly state is to Launching but never mind when we are testing");
        Test_Manager.Instance.state1.isOn = false;
        Test_Manager.Instance.PrepareUI.SetActive(false);
        _owner.PreparingUI(false);
    }

    public override void UpdateState(Test_ball _owner)
    {

    }

}
