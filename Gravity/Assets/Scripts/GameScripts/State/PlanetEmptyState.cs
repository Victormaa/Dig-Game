using StateMachine;
using UnityEngine;

public class PlanetEmptyState : State<Attractor>
{
    private static PlanetEmptyState _instance;



    private PlanetEmptyState()
    {
        if (_instance != null)
        {
            return;
        }

        _instance = this;
    }

    public static PlanetEmptyState Instance
    {
        get
        {
            if (_instance == null)
            {
                new PlanetEmptyState();
            }
            return _instance;
        }
    }


    public override void EnterState(Attractor _owner)
    {
        _owner.BeAttracted = true;
        Debug.Log("Entering PlanetEmptyState");
    }

    public override void ExitState(Attractor _owner)
    {
        Debug.Log("Exit PlanetEmptyState");
    }

    public override void UpdateState(Attractor _owner)
    {

    }
}