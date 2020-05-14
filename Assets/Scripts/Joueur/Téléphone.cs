﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Téléphone : MonoBehaviour
{
    public GameObject spotLight;
    public GameObject lightTrigger;
    [Range(120, 360)]
    public float vibrationTime;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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

    private void ChooseVibrationTime()
    {
        vibrationTime = Random.Range(vibrationTime, 30f);
    }

    public void VibrationLocation()
    {
        Debug.Log("Vibre");
        TaureauScript.s_Singleton.SetDestination(transform.position);
    }

    private void OnEnable()
    {
        Debug.Log("Load");
        ChooseVibrationTime();
        Invoke("VibrationLocation", vibrationTime);
    }

    private void OnDisable()
    {
        Debug.Log("Cancel");
        CancelInvoke();
    }
}
