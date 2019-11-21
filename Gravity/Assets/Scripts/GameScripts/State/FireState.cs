using StateMachine;
using UnityEngine;

public class FireState : State<Role>
{
    private static FireState _instance;

    private FireState()
    {
        if (_instance != null)
        {
            return;
        }

        _instance = this;
    }

    public static FireState Instance
    {
        get
        {
            if (_instance == null)
            {
                new FireState();
            }
            return _instance;
        }
    }


    public override void EnterState(Role _owner)
    {
        Debug.Log("Entering FireState");
    }

    public override void ExitState(Role _owner)
    {
        Debug.Log("Exit FireState");
    }

    public override void UpdateState(Role _owner)
    {
        //Do stuff need every frame
    }
}