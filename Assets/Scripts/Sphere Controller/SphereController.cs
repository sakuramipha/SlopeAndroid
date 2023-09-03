using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereController : MonoBehaviour
{
    
    private Rigidbody rigidBody;
    public float SteerForceLeft = -480;
    public float SteerForceRight = 480;

    public static SphereController instance;
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    private void Awake()
    {
        instance = this;
    }

    void Update()
    {
        if(Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D))
        {
            return;
        }

        if (Input.GetKey(KeyCode.A))
        {
            SteerLeft();
            return;
        }

        if (Input.GetKey(KeyCode.D))
        {
            SteerRight();
            return;
        }
    }

    void SteerLeft()
    {
        Debug.Log("Steering Left");
        rigidBody.AddForce(SteerForceLeft, 0, 0, ForceMode.Force);
    }

    void SteerRight()
    {
        Debug.Log("Steering Right");
        rigidBody.AddForce(SteerForceRight, 0, 0, ForceMode.Force);
    }

}
