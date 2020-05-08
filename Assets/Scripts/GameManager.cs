using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class GameManager : MonoBehaviour
{

    #region Variables
    [HideInInspector]
    public int objKeyLaunch = 0;
    [HideInInspector]
    public bool monsterCanMove;

    public GameObject torchLight;
    public GameObject cellphone;

    public bool showController = false;

    [HideInInspector]
    public bool torchLightIsBroke;
    #region Variable Enigme
    public GameObject statuette, statuette2;

    //[HideInInspector]
    public bool firstEIsComplete = false , secondEIsComplete = false, thirdEIsComplete = false;
    
    //[HideInInspector]
    public bool buttonOneE2, buttonTwoE2, buttonThreeE2, buttonFourE2;
    //[HideInInspector]
    public bool pullRock1, rockSort;
    [HideInInspector]
    public int statueIsStatic;

    [HideInInspector]
    public bool isPressMain, isPress;

    //public Vector3 objEnigmaTorche, objEnigmaStatuette1, objEnigmaStatuette2;
    #endregion

    public Vector3 targetForTaurus;

    [HideInInspector]
    public Transform tpRelativePoint;
    #endregion

    #region Singleton
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
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        //objEnigmaStatuette1 = statuette.transform.position;
        //objEnigmaStatuette2 = statuette2.transform.position;
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

    #region Torche
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
    #endregion

    public void TpRelativePoint(Transform pos)
    {
        tpRelativePoint.position = pos.position;
    }

    #region Enigme
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
                Debug.Log("encore 3");
                if (buttonFourE2)
                {
                    Debug.Log("plus que 2");
                    if (buttonThreeE2)
                    {
                        Debug.Log("plus qu'un");
                        if (buttonOneE2)
                        {
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
    public void StatueAreCatchable()
    {
        if(isPressMain && isPress)
        {
            if (!statuette.GetComponent<Interactable>())
            {
                statuette.AddComponent<Interactable>();
                statuette.AddComponent<Throwable>();
                statuette2.AddComponent<Interactable>();
                statuette2.AddComponent<Throwable>();
            }

        }
    }
    #endregion

    #region Mort
    /*public void ResetEnigmaOnDeath()
    {

    }

    private void SetToFalseBool()
    {
        firstEIsComplete = false;
        secondEIsComplete = false;
        thirdEIsComplete = false;

        buttonOneE2 = false;
        buttonTwoE2 = false;
        buttonThreeE2 = false;
        buttonFourE2 = false;

        pullRock1 = false;
        rockSort = false;

        statueIsStatic = 0;

        isPressMain = false;
        isPress = false;
    }

    private void NullTargetToTaurus()
    {
        targetForTaurus = null;
    }

    private void EnigmaObjReturnToPosition()
    {
        statuette.transform.position = objEnigmaStatuette1;
        statuette2.transform.position = objEnigmaStatuette2;

    }*/

    #endregion
}
