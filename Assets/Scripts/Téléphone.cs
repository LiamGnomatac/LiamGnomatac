using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Téléphone : MonoBehaviour
{
    public GameObject spotLight;
    [Range(120, 540)]
    public int vibrationTime;

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

    public void VibrationLocation(Transform pos)
    {
        Debug.Log("Vibre");
        pos.position = transform.position;
    }
}
