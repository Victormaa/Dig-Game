using UnityEngine;
using StateMachine;

public class LandState : State<Test_ball>
{

    private static LandState _instance;

    private LandState()
    {
        if (_instance != null)
        {
            return;
        }

        _instance = this;
    }

    public static LandState Instance
    {
        get
        {
            if (_instance == null)
            {
                new LandState();
            }
            return _instance;
        }
    }

    public override void EnterState(Test_ball _owner)
    {
        //成功着陆则 进行道具拾取 以及前往此星球的发射点  
        
        Debug.Log("成功着陆则 进行道具拾取 以及前往此星球的发射点  ");


        //tell a story
        Debug.Log("We pick up a history monumental it writes: 'all people are Forbidan Fruit Guys! Damn! .......'");


        //go to preparing state

    }

    public override void ExitState(Test_ball _owner)
    {

    }

    public override void UpdateState(Test_ball _owner)
    {

    }


}
