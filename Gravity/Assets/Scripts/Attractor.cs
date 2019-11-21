using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using StateMachine;

public class Attractor : MonoBehaviour
{
    public Slider gravityControl;

    public Toggle EnableButton;

    public float forcePower;

    public float attractRadius;

    public Transform Role;

    public bool BeAttracted = false;

    StateMachine<Attractor> stateMachine { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        stateMachine = new StateMachine<Attractor>(this);
        stateMachine.ChangeState(PlanetState.Instance);
    }

    // Update is called once per frame
    void Update()
    {
        if(EnableButton.isOn && BeAttracted)
            if ((Vector2.SqrMagnitude(this.transform.position - Role.position)) < attractRadius)
                Attract(Role);


        stateMachine.Update();
    }

    public void Attract(Transform AttractedObj)
    {
        if (!AttractedObj.GetComponent<Rigidbody2D>())
            Debug.LogError("The Attracted Obj Need a Rig!");

        Rigidbody2D ObjRig = AttractedObj.GetComponent<Rigidbody2D>();
        Vector2 AttractDir = (this.transform.position - AttractedObj.position).normalized;

            ObjRig.AddForce(AttractDir * forcePower * gravityControl.value * 0.01f, ForceMode2D.Impulse);    
    }

    public void ChangeState()
    {
        stateMachine.ChangeState(PlanetEmptyState.Instance);
    }

    public void ToPlanetState()
    {
        stateMachine.ChangeState(PlanetState.Instance);
    }
}
