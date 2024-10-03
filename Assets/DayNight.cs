using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNight : MonoBehaviour
{
    [SerializeField] Material daySkybox;
    [SerializeField] Material nightSkybox;
    [SerializeField] new Light light;
    // Start is called before the first frame update
    private void Start()
    {
        if (MainMenu.daytrue)
        {
            //lighting to day
            RenderSettings.skybox = daySkybox;
            light.intensity = 1.0f;
        }
        else
        {
            //lighting to night
            RenderSettings.skybox = nightSkybox;
            light.intensity = 0.0f;
        }
    }
}
