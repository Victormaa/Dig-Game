using StateMachine;
using UnityEngine;

public class WinState : State<Test_ball>
{
    private static WinState _instance;

    private WinState()
    {
        if(_instance == null)
        {
            _instance = this;
        }
        return;
    }

    public static WinState Instance
    {
        get
        {
            if(_instance == null)
            {
                new WinState();
            }
            return _instance;
        }
    }

    public override void EnterState(Test_ball _owner)
    {
        _owner.WinCtrl();

        Test_Manager.Instance.WinUI.SetActive(true);
        Test_Manager.Instance.state4.isOn = true;
        Debug.Log("We are the champion my friends!!!! We'll keep on fighting till the end!!!");
    }

    public override void ExitState(Test_ball _owner)
    {
        Test_Manager.Instance.state4.isOn = false;
        Test_Manager.Instance.WinUI.SetActive(false);
        Debug.Log("damn! another level??");
    }

    public override void UpdateState(Test_ball _owner)
    {

    }

}
