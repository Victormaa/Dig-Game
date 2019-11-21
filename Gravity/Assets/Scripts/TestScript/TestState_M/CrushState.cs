using StateMachine;
using UnityEngine;

public class CrushState : State<Test_ball>
{
    private static CrushState _instance;

    private CrushState()
    {
        if(_instance == null)
        {
            _instance = this;
        }
        return;
    }

    public static CrushState Instance
    {
        get
        {
            if (_instance == null)
            {
                new CrushState();
            }
            return _instance;
        }
    }

    public override void EnterState(Test_ball _owner)
    {

        Test_Manager.Instance.state3.isOn = true;
        _owner.ModifyCrushCtrl();
        Test_Manager.Instance.CrushUI.SetActive(true);
        Debug.Log("Crushing!!!! now is time to retry! Go back to the preparestate.");

    }

    public override void ExitState(Test_ball _owner)
    {
        Test_Manager.Instance.state3.isOn = false;
        Test_Manager.Instance.CrushUI.SetActive(false);
        Debug.Log("Exist Crush State. Go back to prepare;");
    }

    public override void UpdateState(Test_ball _owner)
    {

    }
}
