using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer 
{
    private float _startTime = 0f;
    //private bool _startTimer;
    //public bool TimerEnded
    //{
    //    get;
    //    private set;
    //}

    public bool StartTimer(float endTime)
    {
        Debug.Log("Timer ON");
        while (_startTime < endTime)
        {
            _startTime += Time.deltaTime;
            Debug.Log((int)_startTime);
        }
        _startTime = 0;
        Debug.Log("Timer OFF");
        return true;

    }
}
