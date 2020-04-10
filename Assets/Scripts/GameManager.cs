using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class GameManager : MonoBehaviour
{
    public GameObject torchLight;
    public GameObject cellphone;
    public bool torchLightIsBroke;
    public bool showController = false;

    [HideInInspector]
    public Transform targetForTaurus;

    [HideInInspector]
    public Transform tpRelativePoint;

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

        //Montrer ou cacher les controllers VR

        foreach( var hand in Player.instance.hands)
        {
            if (showController)
            {
                hand.ShowController();
                hand.SetSkeletonRangeOfMotion(Valve.VR.EVRSkeletalMotionRange.WithController);
            }
            else
            {
                hand.HideController();
                hand.SetSkeletonRangeOfMotion(Valve.VR.EVRSkeletalMotionRange.WithoutController);
            }
        }



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

    public void TpRelativePoint(Transform pos)
    {
        tpRelativePoint.position = pos.position;
    }
}
