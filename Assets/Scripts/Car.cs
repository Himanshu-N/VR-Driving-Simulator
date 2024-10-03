using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    [SerializeField] Transform centreOfMass;
    [SerializeField] KeyboardInput Game_Input;
    [SerializeField] SimulatorInputControl simulatorInputControl;

    public float motorTorque;
    public float steerMax;
    public float brakeMax;
    private float throttleInput, brakeInput;
    private float steeringInput;
    private Rigidbody _rigidbody;
    private Wheel[] wheels;

    private enum Mode
    {
        Keyboard,
        Controller,
    }
    [SerializeField] private Mode mode;

    private void Start()
    {
        wheels = GetComponentsInChildren<Wheel>();
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.centerOfMass = centreOfMass.localPosition;
    }


    private void Update()
    {
        switch (mode)
        {
            case Mode.Keyboard:
                steeringInput = Game_Input.GetInputVectorNormalised().x;
                throttleInput = Game_Input.GetInputVectorNormalised().y;
                brakeInput = Game_Input.GetBrakeValue();

                break;
            case Mode.Controller:
                steeringInput = simulatorInputControl.steerValue;
                //throttleInput = simulatorInputControl.accelerationValue; // to be used when reverse option is there
                throttleInput = simulatorInputControl.accelerationValue - simulatorInputControl.clutchValue; // clutch will be used for reverse torque temporarily.

                brakeInput = simulatorInputControl.brakeValue;
                break;
        }

        foreach (Wheel wheel in wheels)
        {
            wheel.Torque = throttleInput * motorTorque;
            wheel.GetComponentInParent<WheelCollider>().brakeTorque = brakeInput * brakeMax;
            wheel.SteerAngle = steeringInput * steerMax;
        }
    }
}
