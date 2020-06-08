using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampeTorche : MonoBehaviour
{
    public GameObject spotLight;
    public GameObject lightTrigger;


    public static LampeTorche s_Singleton;

    private void Awake()
    {
        if (s_Singleton != null)
        {
            Destroy(gameObject);
        }
        else
        {
            s_Singleton = this;
        }
    }

    public void ToggleLightAppear()
    {
        spotLight.SetActive(!spotLight.activeSelf);
        lightTrigger.SetActive(!lightTrigger.activeSelf);
    }

    public void ToggleTorchLightAppear()
    {
        gameObject.SetActive(!gameObject.activeSelf);
    }
}
