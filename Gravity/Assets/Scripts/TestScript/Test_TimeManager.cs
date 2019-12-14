using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test_TimeManager : MonoBehaviour
{

    [SerializeField]
    float targetTimeScale = 0.35f;

    [SerializeField]
    float currentTimeScale;

    [SerializeField]
    float timeshrinkSmth = 0.05f;

    public Slider timeslider;
    // Start is called before the first frame update
    void Start()
    {
        currentTimeScale = Time.timeScale;
    }

    // Update is called once per frame
    void Update()
    {
         timeslider.value = currentTimeScale;
    }

    public void TimeControl()
    {
        Debug.Log("this is logging");
        if(currentTimeScale > targetTimeScale)
        {
            currentTimeScale -= timeshrinkSmth;
            Time.timeScale = currentTimeScale;
            Time.fixedDeltaTime = Time.timeScale * 0.02f;
        }
        else
        {
            currentTimeScale = targetTimeScale;
            Time.timeScale = currentTimeScale;
            Time.fixedDeltaTime = Time.timeScale * 0.02f;
        }
            
    }

    public void CancelTimeControl()
    {
        currentTimeScale = 1.0f;
        Time.timeScale = currentTimeScale;
    }

}
