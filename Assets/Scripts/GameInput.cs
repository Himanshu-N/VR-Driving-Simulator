using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInput : MonoBehaviour
{
    public static GameInput Instance { get; private set;}
    CarInputAction carInputAction;

    private void Awake()
    {
        Instance = this;
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
