using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public enum SliderStates { Idle, Pulled, EndReach, ComingBack};

public class PullRock : MonoBehaviour
{
    public float speed;
    [HideInInspector]
    public SliderStates myState;
    public LinearMapping linearMapping;

    private Hand hand;
    private Vector3 posStart;
    private Vector3 posEnd;
    private float distStartPos;
    private float distStartEnd;
    private float distDecimal;

    // Start is called before the first frame update
    void Start()
    {
        posStart = GetComponentInParent<Transform>().GetComponentInChildren<LinearDrive>().startPosition.position;
        posEnd = GetComponentInParent<Transform>().GetComponentInChildren<LinearDrive>().endPosition.position;
        distStartEnd = Vector3.Distance(posStart, posEnd);
        SetIdle();
        EnigmesManager.s_Singleton.rockIsPull = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position == posStart && myState !=SliderStates.Idle)
        {
            SetIdle();
            EnigmesManager.s_Singleton.rockIsPull = false;
            linearMapping.value = 0;
        }
        if(transform.position == posEnd && hand && hand.isActive || transform.position == posEnd && GetComponent<Interactable>().attachedToHand != null )
        {
            SetEndReach();
            return;
        }
        if (hand && hand.isActive && transform.position != posStart && myState != SliderStates.Pulled || GetComponent<Interactable>().attachedToHand != null && transform.position != posStart && myState != SliderStates.Pulled)
        {
            EnigmesManager.s_Singleton.rockIsPull = true;
            SetPulled();
            if (GetComponent<StoryElementMonologue>())
            {
                GetComponent<StoryElementMonologue>().TriggerMonologue();
                Destroy(GetComponent<StoryElementMonologue>());
            }
        }
        if (!hand && GetComponent<Interactable>().attachedToHand == null && transform.position != posStart && myState != SliderStates.Idle)
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
        //Obj return to startPos
        transform.position = Vector3.MoveTowards(transform.position, GetComponent<LinearDrive>().startPosition.position, Time.deltaTime * speed);
        //Reset linearMapping value for return
        distStartPos = Vector3.Distance(posStart, transform.position);
        distDecimal = distStartPos / distStartEnd;
        linearMapping.value = distDecimal;
    }
}
