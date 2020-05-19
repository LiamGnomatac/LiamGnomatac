using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public enum SliderStates { Idle, Pulled, EndReach, ComingBack};

public class PullRock : MonoBehaviour
{
    public float speed;
    //[HideInInspector]
    public SliderStates myState;
    public LinearMapping linearMapping;

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
            linearMapping.value = 0;
        }
        if (hand && hand.isActive && transform.position != GetComponentInParent<Transform>().GetComponentInChildren<LinearDrive>().startPosition.position && myState != SliderStates.Pulled)
        {
            EnigmesManager.s_Singleton.rockIsPull = true;
            SetPulled();
        }
        if(!hand && myState != SliderStates.Idle)
        {
            SetComingBack();
            ReturnToPosition();
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

    private void ReturnToPosition()
    {
        transform.position = Vector3.MoveTowards(transform.position, GetComponent<LinearDrive>().startPosition.position, Time.deltaTime * speed);
    }
}
