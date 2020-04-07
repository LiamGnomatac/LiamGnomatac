using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject torchLight;
    public GameObject cellphone;
    public bool torchLightIsBroke;

    [HideInInspector]
    public Transform targetForTaurus;

    public static GameManager s_Singleton;

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
    // Start is called before the first frame update
    void Start()
    {
        targetForTaurus.position = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            AppearTorchLight();
        }
    }

    public void AppearTorchLight()
    {
        if(!torchLightIsBroke)
        {
            torchLight.GetComponent<LampeTorche>().ToggleTorchLightAppear();
            torchLight.GetComponent<LampeTorche>().spotLight.SetActive(false);
        }
        else
        {
            cellphone.GetComponent<Téléphone>().ToggleTorchLightAppear();
            cellphone.GetComponent<Téléphone>().spotLight.SetActive(false);
        }
    }

    public void AppearLight()
    {
        if (!torchLightIsBroke)
        {
            torchLight.GetComponent<LampeTorche>().ToggleLightAppear();
        }
        else
        {
            cellphone.GetComponent<Téléphone>().ToggleLightAppear();
        }
    }
}
