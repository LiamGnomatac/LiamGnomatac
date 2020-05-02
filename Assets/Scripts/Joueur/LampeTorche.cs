using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampeTorche : MonoBehaviour
{
    public GameObject spotLight;
    public GameObject lightTrigger;

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
}
