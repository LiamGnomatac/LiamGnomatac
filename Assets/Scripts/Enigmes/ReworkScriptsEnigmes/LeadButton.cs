using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class LeadButton : MonoBehaviour
{
    public GetOutRock getOut;
    public EncensCS encens;
    public List<GameObject> buttonList;

    private bool buttonOneE2, buttonTwoE2, buttonThreeE2, buttonFourE2;

    public void DownButtonOne()
    {
        buttonOneE2 = true;
    }
    public void DownButtonTwo()
    {
        buttonTwoE2 = true;
    }
    public void DownButtonThree()
    {
        buttonThreeE2 = true;
    }
    public void DownButtonFour()
    {
        buttonFourE2 = true;
    }

    public void ResetButton()
    {
        buttonOneE2 = false;
        buttonTwoE2 = false;
        buttonThreeE2 = false;
        buttonFourE2 = false;
        UnlockButton();
    }

    public void ActivateButton()
    {
        if (!EnigmesManager.s_Singleton.rockIsPull)
        {
            ResetButton();
            return;
        }
        else
        {
            if (buttonOneE2)
            {
                Debug.Log("encore 3");
                if (buttonTwoE2)
                {
                    Debug.Log("plus que 2");
                    if (buttonThreeE2)
                    {
                        Debug.Log("plus qu'un");
                        if (buttonFourE2)
                        {
                            getOut.ReplaceEndPos();
                            encens.FilledWithOil();
                            Debug.Log("première parti ok");
                        }
                        return;
                    }
                    if (buttonFourE2)
                    {
                        ResetButton();
                    }
                    return;
                }
                if (buttonThreeE2 || buttonFourE2)
                {
                    ResetButton();
                }
                return;
            }
            if (buttonFourE2 || buttonThreeE2 || buttonTwoE2)
            {
                ResetButton();
            }
        }
    }

    public void UnlockButton()
    {
        Debug.Log("reset script");
        for (int i = 0; i < buttonList.Count; i++)
        {
            buttonList[i].GetComponent<HoverButton>().enabled = true;
            buttonList[i].GetComponent<Interactable>().enabled = true;
            buttonList[i].GetComponent<ButtonLock>().LockUp();
        }
    }
}
