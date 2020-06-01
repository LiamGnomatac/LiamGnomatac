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

    

    public bool showController = false;

    
    

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
        DontDestroyOnLoad(this);


        

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

    

    public void TpRelativePoint(Transform pos)
    {
        tpRelativePoint.position = pos.position;
    }

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
