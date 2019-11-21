using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test_TimeManager : MonoBehaviour
{
    private float _timeScale = 1;

    public Slider timeslider;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         timeslider.value = _timeScale;
    }

    public void TimeControl()
    {
        _timeScale = 0.35f;
        Time.timeScale = _timeScale;
        Time.fixedDeltaTime = Time.timeScale * 0.02f;
    }

    public void CancelTimeControl()
    {
        _timeScale = 1.0f;
        Time.timeScale = _timeScale;
    }

}
