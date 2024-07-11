using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wheel : MonoBehaviour
{
    public bool steer;
    public bool invertSteer;
    public bool power;

    public float Torque { get; set; }
    public float SteerAngle { get; set; }

    private WheelCollider wheelCollider;
    private Transform wheelTransform;


    private void Start()
    {
        wheelCollider = GetComponent<WheelCollider>();
        wheelTransform = GetComponentInChildren<MeshRenderer>().GetComponent<Transform>();
    }
    private void Update()
    {
        wheelCollider.GetWorldPose(out Vector3 positionWheelCollider, out Quaternion rotationWheelCollider);
        wheelTransform.position = positionWheelCollider;
        wheelTransform.rotation = rotationWheelCollider;
    }

    private void FixedUpdate()
    {
        if (steer)
        {
            wheelCollider.steerAngle = SteerAngle * (invertSteer ? -1 : 1);
        }
        if(power)
        {
            wheelCollider.motorTorque = Torque;
        }
    }
}
