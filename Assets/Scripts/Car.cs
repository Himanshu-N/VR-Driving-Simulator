using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    [SerializeField] Transform centreOfMass;
    [SerializeField] GameInput Game_Input;

    public float motorTorque = 1f;
    public float steerMax = 20f;
    private float throttleInput ;
    private float steeringInput;
    private Rigidbody _rigidbody;
    private Wheel[] wheels;

    private void Start()
    {
        wheels = GetComponentsInChildren<Wheel>();
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.centerOfMass = centreOfMass.localPosition;
    }


    private void Update()
    {
        steeringInput = Game_Input.GetInputVectorNormalised().x;
        throttleInput = Game_Input.GetInputVectorNormalised().y;

        foreach (Wheel wheel in wheels)
        {
            wheel.Torque = throttleInput * motorTorque;
            wheel.SteerAngle = steeringInput * steerMax;
        }
    }
}
