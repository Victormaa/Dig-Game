using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddForceSimulate : MonoBehaviour
{

    public float TestAddForce;

    void Start()
    {
        if (!this.GetComponent<Rigidbody2D>())
            Debug.LogError("The Attracted Obj Need a Rig!");      
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddForce(Transform forcesource)
    {
        Rigidbody2D rig = this.GetComponent<Rigidbody2D>();

        Vector2 dir = (forcesource.position - this.transform.position).normalized ;

        rig.AddForce(dir * TestAddForce * 0.3f, ForceMode2D.Impulse);
    }

}
