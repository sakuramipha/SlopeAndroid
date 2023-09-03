using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorMover : MonoBehaviour
{
    public float WaitMin = 0;
    public float WaitMax = 3;

    private float waitTime;

    private SimpleTimer waitTimer = new();
    void Start()
    {
        waitTime = Random.Range(WaitMin, WaitMax);
        waitTimer.StartTimer(waitTime);
    }

    void Update()
    {
        if(waitTimer.IsExpired() && waitTimer.Started)
        {
            StartMoving();
        }
    }

    void StartMoving()
    {
        iTween.MoveBy(gameObject, iTween.Hash("x", 10, "time", 3, "easeType", iTween.EaseType.linear, "loopType", iTween.LoopType.pingPong));
    }
}
