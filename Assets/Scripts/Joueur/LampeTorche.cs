using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampeTorche : MonoBehaviour
{
    public GameObject spotLight;

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
    }

    public void ToggleTorchLightAppear()
    {
        gameObject.SetActive(!gameObject.activeSelf);
    }
}
