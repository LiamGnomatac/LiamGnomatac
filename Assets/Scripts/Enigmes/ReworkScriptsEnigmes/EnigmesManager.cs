using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnigmesManager : MonoBehaviour
{
    
    #region Variable Enigme
    
    [HideInInspector]
    public bool firstEIsComplete = false, secondEIsComplete = false, thirdEIsComplete = false;

    [HideInInspector]
    public bool buttonOneE2, buttonTwoE2, buttonThreeE2, buttonFourE2;
    [HideInInspector]
    public bool rockIsPull, rockSort;
    [HideInInspector]
    public int statueIsStatic;

    [HideInInspector]
    public int pillarBroke;

    [HideInInspector]
    public bool isPressMain, isPress;

    #endregion
    public static EnigmesManager s_Singleton;
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
        if (!rockIsPull)
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

    #endregion
}
