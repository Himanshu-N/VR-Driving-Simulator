using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardInput : MonoBehaviour
{
    CarInputAction carInputAction;

    private void Awake()
    {
        carInputAction = new CarInputAction();
        carInputAction.Car.Enable();
    }

    public Vector2 GetInputVectorNormalised()
    {
        Vector2 inputVector = carInputAction.Car.Move.ReadValue<Vector2>();
        inputVector = inputVector.normalized;
        return inputVector;
    }
}
