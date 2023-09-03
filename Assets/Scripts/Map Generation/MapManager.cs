using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    public Obsticles obstacles;
    public GameObject SpawnPos;
    public static MapManager instance;
    public float BlockLength = 14.14214f;
    public int MaxRepeats = 4;
    public int SpeedUpCount = 0;
    public int repeats = 0;
    public int LapsComplete = -1;
    public int spawns;

    private bool GenerateLongSections = true;

    private void Start()
    {
        GenerateDropTunnel();

    }

    public void Awake()
    {
        instance = this;
    }

    public void GenerateMap()
    {
        SpeedUpCount += 1;
        LapsComplete += 1;

        SpeedUpCountCheck();

        GenerateEasyRun();
    }

    void SpeedUpCountCheck()
    {
        if (SpeedUpCount == MaxRepeats)
        {
            repeats = MaxRepeats;
        }
        else
        {
            repeats = SpeedUpCount;
        }
    }

    private GameObject SpawnObsticle(GameObject obsticle)
    {
        return Instantiate(obsticle, position: SpawnPos.transform.position, obsticle.transform.rotation);

    }

    private void GenerateEasyRun()
    {
        int selectedObsticle = Random.Range(0, 3);

        switch (selectedObsticle)
        {
            case 0:
                SpawnEasyObsticle();
                break;

            case 1:
                SpawnThin();
                break;

            case 2:
                SpawnTiltLeft();
                break;

            case 3:
                SpawnTiltRight();
                break;
        }
    }

    private void GenerateMediumRun()
    {
        int selectedObsticle = Random.Range(0, 2);

        switch (selectedObsticle)
        {
            case 0:
                SpawnTreblock();
                break;

            case 1:
                SpawnDeathTunnel();
                break;

            case 2:
                SpawnDogleg();
                break;
        }
    }
    void OneLapSwitch()
    {
        if (LapsComplete >= 1) // Next run
        {
            SpeedUpCountCheck();
            GenerateMediumRun();
        }
        else if (LapsComplete < 1) // Tunnel run
        {
            GenerateSpeedTunnel();
        }
    }

    void TwoLapSwitch()
    {
        if (LapsComplete >= 2) // Next run
        {
            SpeedUpCountCheck();
            //GenerateHardRun();
        }
        else if (LapsComplete < 2) // Tunnel run
        {
            GenerateSpeedTunnel();
        }
    }

    private void GenerateDropTunnel()
    {
        SpawnPos.transform.Translate(0, -6, 0, Space.Self);

        SpawnObsticle(obstacles.dropTunnel);
        SpawnObsticle(obstacles.tunnelArcLong);
        SpawnObsticle(obstacles.tunnelArcLongDanger);
        SpawnObsticle(obstacles.slopeSpeedArrows);
        SpawnObsticle(obstacles.speedUpNoSpawn);

        SpawnPos.transform.Translate(0, 0, BlockLength, Space.Self);
        SpawnObsticle(obstacles.slopeSpeedArrows);

        SpawnPos.transform.Translate(0, 0, BlockLength, Space.Self);
        SpawnObsticle(obstacles.slopeSpeedArrows);

        SpawnPos.transform.Translate(0, 0, BlockLength, Space.Self);
        SpawnObsticle(obstacles.slopeSpeedArrows);

        SpawnPos.transform.Translate(0, 0, BlockLength, Space.Self);
        SpawnObsticle(obstacles.slopeSpeedArrows);

        SpawnPos.transform.Translate(0, 0, BlockLength, Space.Self);
        SpawnObsticle(obstacles.slopeSpeedArrows);
        SpawnObsticle(obstacles.speedUp);

        SpawnObsticle(obstacles.jump);
        SpawnObsticle(obstacles.score);
    }

    void GenerateSpeedTunnel()
    {
        spawns += 1;
        SpawnPos.transform.Translate(0, -2, 20);

        //GameObject deathTower1 = SpawnObsticle(obstacles.deathTower);
        //deathTower1.transform.Translate(-10, 20, -10);

        //GameObject deathTower2 = SpawnObsticle(obstacles.deathTower);
        //deathTower2.transform.Translate(10, 20, -10);

        SpawnObsticle(obstacles.slope);

        SpawnPos.transform.Translate(0, 0, BlockLength);
        SpawnObsticle(obstacles.slope);

        SpawnPos.transform.Translate(0, 0, BlockLength);
        SpawnObsticle(obstacles.slope);

        SpawnPos.transform.Translate(0, 0, BlockLength);

        SpawnObsticle(obstacles.slopeSpeedArrows);
        SpawnObsticle(obstacles.tunnelArc);
        SpawnObsticle(obstacles.tunnelArcDanger);
        SpawnObsticle(obstacles.speedUp);

        SpawnPos.transform.Translate(0, 0, BlockLength);
        SpawnObsticle(obstacles.slope);

        SpawnPos.transform.Translate(0, 0, BlockLength);
        SpawnObsticle(obstacles.slope);

        SpawnPos.transform.Translate(0, 0, BlockLength);
        SpawnObsticle(obstacles.slope);

        SpawnPos.transform.Translate(0, 0, BlockLength);

        SpawnObsticle(obstacles.jump);
        SpawnObsticle(obstacles.score);
    }

    // Early obsticles
    #region

    void SpawnEasyObsticle()
    {
        repeats -= 1;

        SpawnPos.transform.Translate(0, -2, 20, Space.Self);

        SpawnObsticle(obstacles.slope);

        // death towers
        GameObject tower1 = SpawnObsticle(obstacles.deathTower);
        tower1.transform.Translate(-20, 10, 0);

        GameObject tower2 = SpawnObsticle(obstacles.deathTower);
        tower2.transform.Translate(20, 10, 0);


        SpawnPos.transform.Translate(0, 0, BlockLength, Space.Self);
        SpawnObsticle(obstacles.slope);

        // Obsticle
        GameObject obsticle = SpawnObsticle(obstacles.obsticleLeft);
        obsticle.transform.Translate(Random.Range(0, 6.5f), 0, 0);


        SpawnPos.transform.Translate(0, 0, BlockLength, Space.Self);

        SpawnObsticle(obstacles.slope);
        SpawnObsticle(obstacles.score);

        // Repeat easy obsticle?
        if (repeats <= 0) // Next run
        {
            OneLapSwitch();
        }
        else // Repeat run
        {
            SpawnEasyObsticle();
        }

        repeats -= 1;
    }

    void SpawnThin()
    {
        repeats -= 1;
        SpawnPos.transform.Translate(0, -2, 10, Space.Self);

        SpawnObsticle(obstacles.thin);

        SpawnPos.transform.Translate(-2.6f, 0, 80, Space.Self);

        SpawnObsticle(obstacles.score);

        SpawnPos.transform.Translate(0, 0, -5, Space.Self);

        // Repeat thin?
        Debug.Log("repeats = "+repeats);
        Debug.Log(repeats <= 0);
        if (repeats <= 0) // Next Run
        {
            // Repeat easy obsticle?
            if (repeats <= 0) // Next run
            {
                OneLapSwitch();
            }
        }
        else // Repeat run
        {
            SpawnThin();
        }

        repeats -= 1;
    }

    void SpawnTiltLeft()
    {
        repeats -= 1;
        Debug.Log(repeats - 1);
        SpawnPos.transform.Translate(0, -6, 20, Space.Self);

        SpawnObsticle(obstacles.slopeWideTiltLeft);
        SpawnPos.transform.Translate(0, 0, BlockLength, Space.Self);

        SpawnObsticle(obstacles.slopeWideTiltLeft);
        SpawnPos.transform.Translate(0, 0, BlockLength, Space.Self);

        SpawnObsticle(obstacles.slopeWideTiltLeft);
        SpawnPos.transform.Translate(0, 0, BlockLength, Space.Self);

        SpawnObsticle(obstacles.slopeWideTiltLeft);
        SpawnPos.transform.Translate(0, 0, BlockLength, Space.Self);

        SpawnObsticle(obstacles.slopeWideTiltLeft);
        SpawnPos.transform.Translate(0, 0, BlockLength, Space.Self);

        SpawnObsticle(obstacles.score);

        SpawnPos.transform.Translate(0, -2, -10, Space.Self);

        // Repeat tilt?
        if (repeats <= 0) // Next run
        {
            OneLapSwitch();
        }
        else // Repeat run
        {
            int random = Random.Range(0, 1);

            switch (random)
            {
                case 0:
                    SpawnTiltLeft();
                    break;

                case 1:
                    SpawnTiltRight();
                    break;
            }
        }
    }

    void SpawnTiltRight()
    {
        repeats -= 1;
        SpawnPos.transform.Translate(0, -6, 20, Space.Self);

        SpawnObsticle(obstacles.slopeWideTiltRight);
        SpawnPos.transform.Translate(0, 0, BlockLength, Space.Self);

        SpawnObsticle(obstacles.slopeWideTiltRight);
        SpawnPos.transform.Translate(0, 0, BlockLength, Space.Self);

        SpawnObsticle(obstacles.slopeWideTiltRight);
        SpawnPos.transform.Translate(0, 0, BlockLength, Space.Self);

        SpawnObsticle(obstacles.slopeWideTiltRight);
        SpawnPos.transform.Translate(0, 0, BlockLength, Space.Self);

        SpawnObsticle(obstacles.slopeWideTiltRight);
        SpawnPos.transform.Translate(0, 0, BlockLength, Space.Self);

        SpawnObsticle(obstacles.score);

        SpawnPos.transform.Translate(0, -2, -10, Space.Self);

        // Repeat tilt?
        if (repeats <= 0) // Next run
        {
            OneLapSwitch();
        }
        else // Repeat run
        {
            int random = Random.Range(0, 1);

            switch (random)
            {
                case 0:
                    SpawnTiltLeft();
                    break;

                case 1:
                    SpawnTiltRight();
                    break;
            }
        }
    }
    #endregion

    // Medium obsticles

    void SpawnTreblock()
    {
        repeats -= 1;
        float xOffset = Random.Range(-5, 5);

        SpawnPos.transform.Translate(xOffset, -7, 20, Space.Self);

        SpawnObsticle(obstacles.slope);

        // death towers
        GameObject deathTower1 = SpawnObsticle(obstacles.deathTower);
        deathTower1.transform.Translate(-20, 10, 0);

        GameObject deathTower2 = SpawnObsticle(obstacles.deathTower);
        deathTower2.transform.Translate(20, 10, 0);


        SpawnPos.transform.Translate(0, 0, BlockLength, Space.Self);
        SpawnObsticle(obstacles.slope);

        SpawnPos.transform.Translate(0, 0, BlockLength, Space.Self);
        SpawnObsticle(obstacles.slope);

        SpawnPos.transform.Translate(0, 0, BlockLength, Space.Self);
        SpawnObsticle(obstacles.slope);

        SpawnPos.transform.Translate(0, 0, BlockLength, Space.Self);
        SpawnObsticle(obstacles.slope);

        SpawnPos.transform.Translate(0, 0, BlockLength, Space.Self);
        SpawnObsticle(obstacles.slope);

        SpawnPos.transform.Translate(0, 0, BlockLength, Space.Self);
        SpawnObsticle(obstacles.slope);

        SpawnPos.transform.Translate(0, 0, BlockLength, Space.Self);
        SpawnObsticle(obstacles.slope);
        SpawnObsticle(obstacles.obsticleLeftRight);

        SpawnPos.transform.Translate(0, 0, BlockLength, Space.Self);
        SpawnObsticle(obstacles.slope);

        SpawnPos.transform.Translate(0, 0, BlockLength, Space.Self);
        SpawnObsticle(obstacles.slope);
        SpawnObsticle(obstacles.obsticleMiddle);

        SpawnPos.transform.Translate(0, 0, BlockLength, Space.Self);
        SpawnObsticle(obstacles.slope);

        SpawnPos.transform.Translate(0, 0, BlockLength, Space.Self);
        SpawnObsticle(obstacles.slope);

        SpawnPos.transform.Translate(0, 0, BlockLength, Space.Self);
        SpawnObsticle(obstacles.slope);

        SpawnPos.transform.Translate(0, 0, BlockLength, Space.Self);
        SpawnObsticle(obstacles.slope);

        SpawnPos.transform.Translate(0, 0, BlockLength, Space.Self);
        SpawnObsticle(obstacles.slope);

        SpawnPos.transform.Translate(0, 0, BlockLength, Space.Self);
        SpawnObsticle(obstacles.slope);

        SpawnPos.transform.Translate(0, 0, BlockLength, Space.Self);
        SpawnObsticle(obstacles.slope);
        SpawnObsticle(obstacles.obsticleLeftRight);
        SpawnObsticle(obstacles.score);

        // Repeat treblock?
        if (repeats <= 0) // Next run
        {
            TwoLapSwitch();
        }
        else // Repeat run
        {
            SpawnTreblock();
        }

        repeats -= 1;
    }

    void SpawnDeathTunnel()
    {
        repeats -= 1;
        float xOffset = Random.Range(-5, 5);
        SpawnPos.transform.Translate(xOffset, -7, 20, Space.Self);

        SpawnObsticle(obstacles.slope);

        // death towers
        GameObject deathTower1 = SpawnObsticle(obstacles.deathTower);
        deathTower1.transform.Translate(-20, 10, 0);

        GameObject deathTower2 = SpawnObsticle(obstacles.deathTower);
        deathTower2.transform.Translate(20, 10, 0);


        SpawnPos.transform.Translate(0, 0, BlockLength, Space.Self);
        SpawnObsticle(obstacles.slope);

        SpawnPos.transform.Translate(0, 0, BlockLength, Space.Self);
        SpawnObsticle(obstacles.slope);

        SpawnPos.transform.Translate(0, 0, BlockLength, Space.Self);
        SpawnObsticle(obstacles.slope);

        SpawnPos.transform.Translate(0, 0, BlockLength, Space.Self);
        SpawnObsticle(obstacles.slope);

        SpawnPos.transform.Translate(0, 0, BlockLength, Space.Self);
        SpawnObsticle(obstacles.slope);
        SpawnObsticle(obstacles.tunnel);
        SpawnObsticle(obstacles.tunnelRoof);

        SpawnPos.transform.Translate(0, 0, BlockLength, Space.Self);
        SpawnObsticle(obstacles.slope);

        SpawnPos.transform.Translate(0, 0, BlockLength, Space.Self);
        SpawnObsticle(obstacles.slope);

        SpawnPos.transform.Translate(0, 0, BlockLength, Space.Self);
        SpawnObsticle(obstacles.jumpGapMid);
        SpawnObsticle(obstacles.score);

        // Repeat death tunnel?
        if (repeats <= 0) // Next run
        {
            TwoLapSwitch();
        }
        else // Repeat run
        {
            SpawnDeathTunnel();
        }
    }

    void SpawnDogleg()
    {
        repeats -= 1;
        float xOffset = Random.Range(-5, 5);

        SpawnPos.transform.Translate(xOffset, -5, 9);
        SpawnObsticle(obstacles.dogleg);

        SpawnPos.transform.Translate(0, 0, 76.84f);
        SpawnPos.transform.Translate(-2.6f, 0, 80);

        SpawnObsticle(obstacles.score);

        // Repeat dogleg?
        if (repeats <= 0) // Next run
        {
            TwoLapSwitch();
        }
        else // Repeat run
        {
            SpawnDogleg();
        }
    }

    void SpawnDoglegMirrored()
    {
        repeats -= 1;
        float xOffset = Random.Range(-5, 5);
        SpawnPos.transform.Translate(xOffset, -3, 9);
        SpawnObsticle(obstacles.thinNoJump);
        SpawnPos.transform.Translate(0, 0, 76.84f);
        GameObject snake = SpawnObsticle(obstacles.dogleg);
        snake.transform.localScale = new(-1, 1, 1);
        SpawnPos.transform.Translate(-2.6f, 0, 80, Space.Self);
        SpawnObsticle(obstacles.score);
    }

    // Late obsticles
    #region
    private void CreateThinSwitchA()
    {
        Instantiate(obstacles.thinNoJump, position: SpawnPos.transform.position, obstacles.thinNoJump.transform.rotation);
        Instantiate(obstacles.obsticleThin, position: SpawnPos.transform.position, obstacles.obsticleThin.transform.rotation);

        SpawnPos.transform.Translate(10,-5, 0, Space.Self);

        Instantiate(obstacles.thinNoJump, position: SpawnPos.transform.position, obstacles.thinNoJump.transform.rotation);

        SpawnPos.transform.Translate(10, -5, 0, Space.Self);

        Instantiate(obstacles.thinNoJump, position: SpawnPos.transform.position, obstacles.thinNoJump.transform.rotation);

        SpawnPos.transform.Translate(-2.6f, 0, 60, Space.Self);
    }

    private void CreateThinSwitchB()
    {
        Instantiate(obstacles.thinNoJump, position: SpawnPos.transform.position, obstacles.thinNoJump.transform.rotation);

        SpawnPos.transform.Translate(10, -5, 0, Space.Self);

        Instantiate(obstacles.thinNoJump, position: SpawnPos.transform.position, obstacles.thinNoJump.transform.rotation);
        Instantiate(obstacles.obsticleThin, position: SpawnPos.transform.position, obstacles.obsticleThin.transform.rotation);

        SpawnPos.transform.Translate(10, -5, 0, Space.Self);
        Instantiate(obstacles.thinNoJump, position: SpawnPos.transform.position, obstacles.thinNoJump.transform.rotation);


        SpawnPos.transform.Translate(-2.6f, 0, 60, Space.Self);
    }

    private void CreateThinSwitchC()
    {
        Instantiate(obstacles.thinNoJump, position: SpawnPos.transform.position, obstacles.thinNoJump.transform.rotation);

        SpawnPos.transform.Translate(10, -5, 0, Space.Self);

        Instantiate(obstacles.thinNoJump, position: SpawnPos.transform.position, obstacles.thinNoJump.transform.rotation);

        SpawnPos.transform.Translate(10, -5, 0, Space.Self);

        Instantiate(obstacles.thinNoJump, position: SpawnPos.transform.position, obstacles.thinNoJump.transform.rotation);
        Instantiate(obstacles.obsticleThin, position: SpawnPos.transform.position, obstacles.obsticleThin.transform.rotation);

        SpawnPos.transform.Translate(-2.6f, 0, 60, Space.Self);
    }
    #endregion
}

[System.Serializable]
public class Obsticles
{
    public GameObject dropTunnel;
    public GameObject tunnelArcLong;
    public GameObject tunnelArcLongDanger;


    public GameObject slope;
    public GameObject slopeSpeedArrows;
    public GameObject thin;
    public GameObject dogleg;

    public GameObject speedUp;
    public GameObject speedUpNoSpawn;

    public GameObject thinNoJump;
    public GameObject obsticleThin;

    public GameObject deathTower;

    public GameObject obsticleLeft;
    public GameObject obsticleLeftRight;
    public GameObject obsticleMiddle;

    public GameObject slopeWideTiltLeft;
    public GameObject slopeWideTiltRight;

    public GameObject tunnelArc;
    public GameObject tunnelArcDanger;

    public GameObject tunnel;
    public GameObject tunnelRoof;

    public GameObject jump;
    public GameObject jumpGapMid;

    public GameObject score;
}
