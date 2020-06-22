using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

 public class RockSpawner : MonoBehaviour
 {
    public GameObject rock;
    public float timeBeforeResetInvoke = 1;
    private Interactable myInteractable;
    private bool justOneTime = false;

    private void Start()
    {
        myInteractable = GetComponent<Interactable>();
        Invoke("OneTime", timeBeforeResetInvoke);
    }
    private void Update()
    {
        if (!justOneTime)
        {
            justOneTime = (myInteractable.attachedToHand != null);
            if (justOneTime)
            {
                if (GetComponent<StoryElementMonologue>())
                {
                    GetComponent<StoryElementMonologue>().TriggerMonologue();
                    Destroy(GetComponent<StoryElementMonologue>());
                }
            }
        }
    }
    private void InvokeRock(HandCollider value)
    {
        GameObject thisRock;
        thisRock = Instantiate(rock, transform.position, Quaternion.identity);
        value.hand.hand.AttachObject(thisRock, GrabTypes.Grip);
    }

    private void OnTriggerEnter(Collider other)
    {
        HandCollider hand = other.GetComponentInParent<HandCollider>();

        if (justOneTime && myInteractable.attachedToHand != null)
        {
            justOneTime = false;
            InvokeRock(hand);
            Invoke("OneTime", timeBeforeResetInvoke);
            if (GetComponent<StoryElementMonologue>())
            {
                GetComponent<StoryElementMonologue>().TriggerMonologue();
                Destroy(GetComponent<StoryElementMonologue>());
            }
        }
    }

    private void OneTime()
    {
        justOneTime = true;
        //Debug.Log("tu peux attraper une pierre");
    }
 }
