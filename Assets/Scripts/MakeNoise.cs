using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class MakeNoise : MonoBehaviour
{
    private Interactable myInteractable;
    private bool hasBeenInHand = false;
    private bool touchedGround = false;
    //private Hand hand;
    private void Start()
    {
        myInteractable = GetComponent<Interactable>();
    }
    private void Update()
    {
        if (!hasBeenInHand)
        {
            hasBeenInHand = (myInteractable.attachedToHand != null);
            if (hasBeenInHand)
            {
                touchedGround = false;
                Debug.Log("sol " + touchedGround);
                if (GetComponent<StoryElementMonologue>())
                {
                    GetComponent<StoryElementMonologue>().TriggerMonologue();
                    Destroy(GetComponent<StoryElementMonologue>());
                }
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("collision with" + collision);
        if(collision.gameObject.layer == LayerMask.NameToLayer("Salle") && hasBeenInHand && !touchedGround)
        {
            //Debug.Log(transform.position);
            TaureauScript.s_Singleton.GetRockPosition(transform.position);
            hasBeenInHand = false;
            touchedGround = true;
        }
    }
    /*private void OnHandHoverBegin(Hand hand)
    {
        this.hand = hand;
    }

    private void OnHandHoverEnd(Hand hand)
    {
        this.hand = null;
    }*/


}
