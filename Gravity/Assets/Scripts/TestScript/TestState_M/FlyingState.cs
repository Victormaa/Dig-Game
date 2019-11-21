using UnityEngine;
using StateMachine;

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
        
        _owner.ModifyFlyFunc(true);
        Debug.Log("Now is flying a lot of thing could be down there");
    }

    public override void ExitState(Test_ball _owner)
    {
        Debug.Log("We are out of flying state! Are we win or lose???");
        _owner.ModifyFlyFunc(false);
        Test_Manager.Instance.state2.isOn = false;
        
    }

    public override void UpdateState(Test_ball _owner)
    {
        
    }
}
