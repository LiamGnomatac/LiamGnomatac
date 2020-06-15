using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class GetOutRock : MonoBehaviour
{
    public float speed;
    [HideInInspector]
    public SliderStates myState;
    public LinearMapping linearMapping;
    public Door door;
    public bool isReturn;

    private Hand hand;
    private Transform posStart;
    private Transform posEnd;
    private Vector3 posEndWait;
    private float distStartPos;
    private float distStartEnd;
    private float distDecimal;

    // Start is called before the first frame update
    void Start()
    {
        posStart = GetComponentInParent<Transform>().GetComponentInChildren<LinearDrive>().startPosition;
        posEnd = GetComponentInParent<Transform>().GetComponentInChildren<LinearDrive>().endPosition;
        posEndWait = posEnd.position;
        posEnd.position = posStart.position;
        distStartEnd = Vector3.Distance(posStart.position, posEnd.position);
        SetIdle();
        if(isReturn)
        {
            door.Open();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position == posStart.position && myState != SliderStates.Idle)
        {
            SetIdle();
            linearMapping.value = 0;
        }
        if (transform.position == posEnd.position && hand && hand.isActive || transform.position == posEnd.position && GetComponent<Interactable>().attachedToHand != null)
        {
            SetEndReach();
            return;
        }
        if (hand && hand.isActive && transform.position != posStart.position && myState != SliderStates.Pulled || GetComponent<Interactable>().attachedToHand != null && transform.position != posStart.position && myState != SliderStates.Pulled)
        {
            SetPulled();
            GetOut();
            if(GetComponent<StoryElementMonologue>())
            {
                GetComponent<StoryElementMonologue>().TriggerMonologue();
                Destroy(GetComponent<StoryElementMonologue>());
            }
        }
        if (!hand && GetComponent<Interactable>().attachedToHand == null && transform.position != posStart.position && myState != SliderStates.Idle)
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
        distStartPos = Vector3.Distance(posStart.position, transform.position);
        distDecimal =  distStartEnd / distStartPos;
        linearMapping.value = distDecimal;
    }

    public void ReplaceEndPos()
    {
        posEnd.position = posEndWait;
        linearMapping.value = 0;
    }

    private void GetOut()
    {
        if (!isReturn)
        {
            Debug.Log("Door E2 is open");
            door.Open();
        }
        else if(isReturn)
        {
            Debug.Log("close door");
            door.Close();
        }
    }


}