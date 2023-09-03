using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingsManager : MonoBehaviour
{
    public GameObject buildings;
    public GameObject SpawnPos;

    void Start()
    {
        SpawnObsticle(buildings);
        transform.Translate(0, -2190, 2190);
    }

    private void OnCollisionEnter(Collision collision)
    {
        transform.position = new(SpawnPos.transform.position.x, transform.position.y, transform.position.z);
        GameObject building = SpawnObsticle(buildings);
        transform.Translate(0, -2190, 2190);
    }

    private GameObject SpawnObsticle(GameObject obsticle)
    {
        return Instantiate(obsticle, position: transform.position, obsticle.transform.rotation);

    }
}
