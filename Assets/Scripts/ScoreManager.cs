using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ScoreManager : MonoBehaviour
{
    public float Score = 0;
    public static ScoreManager instance;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        
    }
    void Update()
    {
        
    }

    public void IncrementScore()
    {
        Score += 1;
    }
}
