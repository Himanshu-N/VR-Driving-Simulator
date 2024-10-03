using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VisualsValues : MonoBehaviour
{
    [SerializeField] Image steerP;
    [SerializeField] Image steerN;
    [SerializeField] Image acceleration;
    [SerializeField] Image brake;
    [SerializeField] Image clutch;
    [SerializeField] SimulatorInputControl simulatorInputControl;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        steerP.fillAmount = simulatorInputControl.steerValue;
        steerN.fillAmount = -simulatorInputControl.steerValue;
        acceleration.fillAmount = simulatorInputControl.accelerationValue;  
        brake.fillAmount = simulatorInputControl.brakeValue;
        clutch.fillAmount = simulatorInputControl.clutchValue;
    }
}
