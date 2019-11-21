using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandingRing : MonoBehaviour
{
    float landingcolliderRadius;

    private bool isLandRadiusY = false;

    bool isReadytoLand = true;
    // Start is called before the first frame update
    void Start()
    {
        landingcolliderRadius = this.GetComponent<CircleCollider2D>().radius;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(landingcolliderRadius);
        if (!isLandRadiusY)
        {
            this.GetComponent<CircleCollider2D>().radius = this.GetComponent<CircleCollider2D>().radius + (1.5f * landingcolliderRadius);
            isLandRadiusY = true;
        }

        /*  for testing the rounding tracking for a temperory time;
        if (this.GetComponent<CircleCollider2D>().radius != (2.5f * landingcolliderRadius))
        {
            isLandRadiusY = false;
        }
        */
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
            Debug.Log(" detact land or crush for the next step");

        if (isReadytoLand)
        {
            //set current planet
            
        //如果下次再需要着陆等动作的话请check Slowdown代码 那里有能帮忙找到current planet;
        }
    }

}
