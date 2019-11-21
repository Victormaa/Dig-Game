using StateMachine;
using UnityEngine;

public class PlanetState : State<Attractor>
{
    private static PlanetState _instance;

    

    private PlanetState()
    {
        if (_instance != null)
        {
            return;
        }

        _instance = this;
    }

    public static PlanetState Instance
    {
        get
        {
            if (_instance == null)
            {
                new PlanetState();
            }
            return _instance;
        }
    }


    public override void EnterState(Attractor _owner)
    {
        _owner.BeAttracted = false;
        Debug.Log("Entering PlanetState");
    }

    public override void ExitState(Attractor _owner)
    {
        Debug.Log("Exit PlanetState");
    }

    public override void UpdateState(Attractor _owner)
    {

    }
}