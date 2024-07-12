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
    private MeshRenderer[] wheelComponentMeshRenderererArray;


    private void Start()
    {
        wheelCollider = GetComponent<WheelCollider>();
        wheelComponentMeshRenderererArray = GetComponentsInChildren<MeshRenderer>();
    }
    private void Update()
    {
        wheelCollider.GetWorldPose(out Vector3 positionWheelCollider, out Quaternion rotationWheelCollider);
        foreach (MeshRenderer wheelComponent in wheelComponentMeshRenderererArray)
        {
            wheelComponent.transform.position = positionWheelCollider;
            wheelComponent.transform.rotation = rotationWheelCollider;
        }
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
