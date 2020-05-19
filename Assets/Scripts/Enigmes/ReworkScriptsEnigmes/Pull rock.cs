using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public enum SliderStates { Idle, Pulled, EndReach, ComingBack};

public class Pullrock : MonoBehaviour
{
    [HideInInspector]
    public SliderStates myState;

    private Hand hand;

    // Start is called before the first frame update
    void Start()
    {
        SetIdle();
        EnigmesManager.s_Singleton.rockIsPull = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position == GetComponentInParent<Transform>().GetComponentInChildren<LinearDrive>().startPosition.position && myState !=SliderStates.Idle)
        {
            SetIdle();
            EnigmesManager.s_Singleton.rockIsPull = false;
        }
        else if (hand && hand.isActive && transform.position != GetComponentInParent<Transform>().GetComponentInChildren<LinearDrive>().startPosition.position && myState != SliderStates.Pulled)
        {
            SetPulled();
        }
        else if (!hand && !hand.isActive && myState != SliderStates.Idle)
        {
            SetComingBack();
        }
        
    }

    public void SetIdle()
    {
        if (myState == SliderStates.Idle)
            return;

        myState = SliderStates.Idle;
        Debug.Log("Idle");
    }

    public void SetPulled()
    {
        if (myState == SliderStates.Pulled)
            return;

        myState = SliderStates.Pulled;
        Debug.Log("Pulled");
    }

    public void SetEndReach()
    {
        if (myState == SliderStates.EndReach)
            return;

        myState = SliderStates.EndReach;
        Debug.Log("EndReach");
    }

    public void SetComingBack()
    {
        if (myState == SliderStates.ComingBack)
            return;

        myState = SliderStates.ComingBack;
        Debug.Log("ComingBack");
    }

    private void OnHandHoverBegin(Hand hand)
    {
        this.hand = hand;
    }

    private void OnHandHoverEnd(Hand hand)
    {
        this.hand = null;
    }
}
