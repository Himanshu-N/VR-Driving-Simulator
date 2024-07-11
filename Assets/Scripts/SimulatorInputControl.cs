using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class SimulatorInputControl : MonoBehaviour
{
    SimulatorInputAction simulatorInputAction;
    private int factor1000, factor10;
    private void Awake()
    {
        simulatorInputAction = new SimulatorInputAction();
        simulatorInputAction.Car.Enable();
    }
    private void Start()
    {
        factor1000 = 1415;
        factor10 = 5;
    }
    private void Update()
    {
        Vector2 steeringVector = simulatorInputAction.Car.Steering.ReadValue<Vector2>(); //Gives a vector2(x,y) with y having a dead zone near 0, while x is changing continously
        float steerValue = steeringVector.x * factor1000; //therefore using the x value and scaling it to 1000

        float accelerationFloat = simulatorInputAction.Car.Acceleration.ReadValue<float>(); //Gives values from -1 to 1 for full range of motion, having a small dead zone near 0
        float accelerationValue = (accelerationFloat + 1) * factor10;
        Debug.Log(accelerationValue);
    }
}
