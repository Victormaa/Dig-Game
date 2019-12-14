using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SlowDown : MonoBehaviour
{

    public GameObject[] Planets;

    public GameObject CurrentPlanet;

    private GameObject BeforePlanet;

    [SerializeField]
    float canChangedGraModifier = 0;

    private bool isbeforeset = false;

    public bool SlowDownAble = false;
    // Start is called before the first frame update
    void Start()
    {
        Planets = GameObject.FindGameObjectsWithTag("Planet");

    }

    // Update is called once per frame
    void Update()
    {
        if (!Test_Manager.GameIsPaused)
        {
            CheckClossest();
            // find the closest planet and then check if the distance is in effective distance;
            isinRadius();
            SetSlow();
            setStrike();
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

    //set the slow down radius
    void SetSlow()
    {
        var currentGra = CurrentPlanet.GetComponent<Test_Gravity>();

        if (isinRadius())
        {
            currentGra.IsAbleSlowDown = true;
        }
        else
        {
            currentGra.timeMana.CancelTimeControl();
            currentGra.IsAbleSlowDown = false;
            //Test_Manager.Instance.FlyingUI.SetActive(false);
            currentGra.Canvastem.SetActive(false);
        }
    }

    public bool isinRadius()
    {
        var currentGra = CurrentPlanet.GetComponent<Test_Gravity>();

        var infactDis = Vector2.Distance(CurrentPlanet.transform.position, this.transform.position);
        var effectDis = currentGra.soiRadius + canChangedGraModifier;   //0.5 = adjust control spetrum;

        return infactDis <= effectDis;
    }

    private void setStrike()
    {
        if (!isbeforeset)
        {
            BeforePlanet = CurrentPlanet;
            isbeforeset = true;
        }
        if (isinRadius())
        {
            if (Test_Manager.ischangingG)
            {
                if (Test_Manager.CurisLarger)
                {
                    //这里的CurisLarger是用来判断引力增大还是减小了来做颜色替换
                    CurrentPlanet.GetComponent<Renderer>().material.color = new Color((float)227 / 255, (float)104 / 255, (float)104 / 255,1);
                }
                else
                {
                    CurrentPlanet.GetComponent<Renderer>().material.color = new Color((float)120 / 255, (float)255 / 255, (float)120 / 255, 1);
                }
            }
            
        }
        else
        {
            CurrentPlanet.GetComponent<Renderer>().material.color = Color.white;
        }

        if(BeforePlanet != CurrentPlanet)
        {
            BeforePlanet.GetComponent<Renderer>().material.color = Color.white;
            BeforePlanet = CurrentPlanet;
        }
    }


}
