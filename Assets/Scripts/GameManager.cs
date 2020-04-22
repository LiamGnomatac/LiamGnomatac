using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class GameManager : MonoBehaviour
{
    public GameObject torchLight;
    public GameObject cellphone;
    [HideInInspector]
    public bool torchLightIsBroke;

    public bool showController = false;

    [HideInInspector]
    public bool firstEIsComplete = false , secondEIsComplete = false, thirdEIsComplete = false;
    
    //[HideInInspector]
    public bool buttonOneE2, buttonTwoE2, buttonThreeE2, buttonFourE2;
    public bool pullRock1;
    public bool rockSort;
    
    public Transform targetForTaurus = null;

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
        
        /*if(Input.GetMouseButtonDown(0))
        {
            AppearTorchLight();
        }*/
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

 
    public void DownButtonOne()
    {
        buttonOneE2 = !buttonOneE2;
    }
    public void DownButtonTwo()
    {
        buttonTwoE2 = !buttonTwoE2;
    }
    public void DownButtonThree()
    {
        buttonThreeE2 = !buttonThreeE2;
    }
    public void DownButtonFour()
    {
        buttonFourE2 = !buttonFourE2;
    }

    public void ResetButton()
    {
        buttonOneE2 = false;
        buttonTwoE2 = false;
        buttonThreeE2 = false;
        buttonFourE2 = false;
    }

    public void ActivateButton()
    {
        if(!pullRock1)
        {
            ResetButton();
            return;
        }
        else
        {
            if (buttonTwoE2)
            {
                Debug.Log("2");
                if (buttonFourE2)
                {
                    Debug.Log("4");
                    if (buttonThreeE2)
                    {
                        Debug.Log("3");
                        if (buttonOneE2)
                        {
                            Debug.Log("1");
                            rockSort = true;
                            Debug.Log("première parti ok");
                        }
                        return;
                    }
                    if (buttonOneE2)
                    {
                        ResetButton();
                    }
                    return;
                }
                if (buttonThreeE2 || buttonOneE2)
                {
                    ResetButton();
                }
                return;
            }
            if (buttonFourE2 || buttonThreeE2 || buttonOneE2)
            {
                ResetButton();
            }
        }
    }
}
