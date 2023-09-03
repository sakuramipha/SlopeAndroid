using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedManager : MonoBehaviour
{
    public bool SpeedUp = false;
    public bool SpeedUpNoSpawn = false;

    private bool SpeedingUp = false;

    public float yForce = 0f;
    public float zForce = 0f;
    private SimpleTimer speedUpTimer = new();

    public Rigidbody Sphere;
    public Animator sphereAnimator;
    public Animation trailAnimator;

    private SphereController sphereController;

    public static SpeedManager instance;
    // Start is called before the first frame update
    void Start()
    {
        sphereController = SphereController.instance;
    }

    private void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if(SpeedUp)
        {
            SpeedingUp = true;
            SpeedUp = false;
            speedUpTimer.StartTimer(1.6f);

            yForce -= 150;
            zForce += 15;

            sphereController.SteerForceLeft -= 30;
            sphereController.SteerForceLeft += 30;

            sphereAnimator.SetTrigger("Fast FOV");
            trailAnimator.CrossFade("TrailOn", 0.15f, PlayMode.StopAll);
            TriggerSpeedUp();
        }

        if (SpeedUpNoSpawn)
        {
            SpeedUpNoSpawn = false;

            yForce -= 300 * Time.deltaTime;
            zForce += 30 * Time.deltaTime;

            sphereController.SteerForceLeft -= 100;
            sphereController.SteerForceLeft += 100;

            sphereAnimator.SetTrigger("Fast FOV");
            trailAnimator.CrossFade("TrailOn", 0.15f, PlayMode.StopAll);
            TriggerSpeedUp();
        }

        TriggerSpeedUp();

        if(speedUpTimer.IsExpired() && speedUpTimer.Started && SpeedingUp)
        {
            SpeedingUp = false;
            sphereAnimator.SetTrigger("Normal FOV");
            trailAnimator.CrossFade("TrailOff", 6f, PlayMode.StopAll);
        }
    }

    void TriggerSpeedUp()
    {
        Sphere.AddForce(0, yForce, zForce, ForceMode.Force);
    }
}
