using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUp : MonoBehaviour
{
    public bool TriggerSpeedUp = true;
    public bool SpawnMap = true;
    private bool spedUpAlready = false;
    private SpeedManager speedManager;
    private MapManager mapManager;
    void Start()
    {
        mapManager = MapManager.instance;
        speedManager = SpeedManager.instance;
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (!spedUpAlready)
        {
            spedUpAlready = true;
            if (SpawnMap)
            {
                mapManager.GenerateMap();
                speedManager.SpeedUp = true;
            } else
            {
                speedManager.SpeedUpNoSpawn = true;
            }
            
        }
    }
}
