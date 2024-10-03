using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class SimulatorInputControl : MonoBehaviour
{
    SimulatorInputAction simulatorInputAction;
    private float oneFactor1, oneFactor2;
    public float steerValue, accelerationValue, brakeValue, clutchValue; //public for using in sample controller input scene

    private void Awake()
    {
        simulatorInputAction = new SimulatorInputAction();
        simulatorInputAction.Car.Enable();
    }
    private void Start()
    {
        oneFactor1 = 1.415f;
        oneFactor2 = 0.5f;
    }
    private void Update()
    {
        Vector2 steeringVector = simulatorInputAction.Car.Steering.ReadValue<Vector2>(); //Gives a vector2(x,y) with y having a dead zone near 0, while x is changing continously
        steerValue = steeringVector.x * oneFactor1; //therefore using the x value and scaling it to 1

        float accelerationFloat = simulatorInputAction.Car.Acceleration.ReadValue<float>(); //Gives values from 1 to -1 for full range of motion, having a small dead zone near 0
        accelerationValue = 1 - ((accelerationFloat + 1) * oneFactor2); //scaling it to 0-1

        float brakeFloat = simulatorInputAction.Car.Brake.ReadValue<float>(); //Gives values from 1 to -1 for full range of motion, having a small dead zone near 0, and end values are hard to get
        brakeValue = 1- ((brakeFloat + 1) * oneFactor2); //scaling it to 0-1

        float clutchFloat = simulatorInputAction.Car.Clutch.ReadValue<float>(); //Gives values from -1 to 1 for full range of motion
        clutchValue = (clutchFloat + 1) * oneFactor2;//scaling it to 0-1

        //Debug.Log("Acc: "+accelerationValue + ", Brake:"+ brakeValue + ", Clutch:" + clutchValue);
        //Debug.Log("Steering: " + steerValue);
    }
}
