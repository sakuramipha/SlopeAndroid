using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class t_Spawner : MonoBehaviour
{
    public Transform SpawnPos;

    public GameObject Slope;
    public GameObject DeathTower;
    public GameObject SideObstacles;
    public GameObject MiddleObstacles;


    // Start is called before the first frame update
    void Start()
    {
        Spawn5Obsticles();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Spawn5Obsticles()
    {
        float randomNumber = Random.Range(-5, 5);

        SpawnPos.Translate(randomNumber, -7, 20);

        spawnObject(Slope);

        spawnObject(DeathTower, new(-20, 10, 0));
        spawnObject(DeathTower, new(20, 10, 0));

        SpawnPos.Translate(0, 0, 14.14214f, Space.Self);

        spawnObject(Slope);

        SpawnPos.Translate(0, 0, 14.14214f, Space.Self);

        spawnObject(Slope);

        SpawnPos.Translate(0, 0, 14.14214f, Space.Self);

        spawnObject(Slope);

        SpawnPos.Translate(0, 0, 14.14214f, Space.Self);

        spawnObject(Slope);

        SpawnPos.Translate(0, 0, 14.14214f, Space.Self);

        spawnObject(Slope);

        SpawnPos.Translate(0, 0, 14.14214f, Space.Self);

        spawnObject(Slope);

        SpawnPos.Translate(0, 0, 14.14214f, Space.Self);

        spawnObject(Slope);

        SpawnPos.Translate(0, 0, 14.14214f, Space.Self);

        spawnObject(Slope);

        SpawnPos.Translate(0, 0, 14.14214f, Space.Self);

        spawnObject(Slope);

        SpawnPos.Translate(0, 0, 14.14214f, Space.Self);

        spawnObject(Slope);

        spawnObject(SideObstacles);

        SpawnPos.Translate(0, 0, 14.14214f, Space.Self);

        spawnObject(Slope);

        SpawnPos.Translate(0, 0, 14.14214f, Space.Self);

        spawnObject(Slope);

    }

    void spawnObject(GameObject objectToInstantiate, Vector3 additionalTranslation = new())
    {
        GameObject spawned =  Instantiate(objectToInstantiate);
        spawned.transform.position = SpawnPos.position;

        spawned.transform.Translate(additionalTranslation);
    }
}
