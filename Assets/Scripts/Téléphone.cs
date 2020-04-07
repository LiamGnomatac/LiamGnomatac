using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Téléphone : MonoBehaviour
{
    public GameObject spotLight;
    [Range(10, 30)]
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
        GameManager.s_Singleton.targetForTaurus.position = transform.position;
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
