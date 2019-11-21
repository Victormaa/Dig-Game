using StateMachine;
using UnityEngine;

public class PreFireState : State<Role>
{
    private static PreFireState _instance;



    private PreFireState()
    {
        if(_instance != null)
        {
            return;
        }

        _instance = this;
    }

    public static PreFireState Instance
    {
        get
        {
            if(_instance == null)
            {
                new PreFireState();
            }
            return _instance;
        }
    }


    public override void EnterState(Role _owner)
    {
        Debug.Log("Entering PreFireState");
    }

    public override void ExitState(Role _owner)
    {
        Debug.Log("Exit PreFireState");
    }

    public override void UpdateState(Role _owner)
    {
        //Do stuff need every frame
    }
}
