using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VertMover : MonoBehaviour
{
    public float waitTime;

    private SimpleTimer waitTimer = new();
    void Start()
    {
        waitTimer.StartTimer(waitTime);
    }

    void Update()
    {
        if (waitTimer.IsExpired() && waitTimer.Started)
        {
            StartMoving();
        }
    }

    void StartMoving()
    {
        iTween.MoveBy(gameObject, iTween.Hash("y", 20, "time", 2, "easeType", iTween.EaseType.linear, "loopType", iTween.LoopType.pingPong, "space", Space.World));
    }
}
