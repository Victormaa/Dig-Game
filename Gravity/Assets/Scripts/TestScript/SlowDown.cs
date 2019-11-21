using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SlowDown : MonoBehaviour
{
    [SerializeField]
    private GameObject[] Planets;

    public GameObject CurrentPlanet;

    public bool SlowDownAble = false;
    // Start is called before the first frame update
    void Start()
    {
        Planets = GameObject.FindGameObjectsWithTag("Planet");

    }

    // Update is called once per frame
    void Update()
    {
        if (SlowDownAble)
        {
            CheckClossest();
            SetSlow();
        }       
    }

    void CheckClossest()
    {
        float comparedDis = 100000;
        int closestInt = 0;

        if (CurrentPlanet == null)
        {
            

            for (int i = 0; i < Planets.Count(); i++)
            {
                var dis = Vector2.Distance(this.transform.position, Planets[i].transform.position);

                if (dis < comparedDis)
                {
                    comparedDis = dis;
                    closestInt = i;
                }
            }
            CurrentPlanet = Planets[closestInt];
        }
        else
        {
            CurrentPlanet.GetComponent<Test_Gravity>().IsAbleSlowDown = false;
        }
            



        for (int i = 0; i < Planets.Count(); i++)
        {
            var dis = Vector2.Distance(this.transform.position, Planets[i].transform.position);

            if (dis < comparedDis)
            {
                comparedDis = dis;
                closestInt = i;
            }
        }
        CurrentPlanet = Planets[closestInt];
    }

    void SetSlow()
    {
        var currentGra = CurrentPlanet.GetComponent<Test_Gravity>();
        var infactDis = Vector2.Distance(CurrentPlanet.transform.position, this.transform.position);
        var effectDis = currentGra.soiRadius;
        if (infactDis <= effectDis + 0.5f)
        {
            currentGra.IsAbleSlowDown = true;
        }
        else
        {
            currentGra.timeMana.CancelTimeControl();
            Test_Manager.Instance.FlyingUI.SetActive(false);
            currentGra.Canvastem.SetActive(false);
        }          
    }
}
