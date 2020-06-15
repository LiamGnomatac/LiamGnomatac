using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

 public class RockSpawner : MonoBehaviour
 {
    public GameObject rock;
    public float timeBeforeResetInvoke = 1;
    private bool justOneTime = false;

    private void Start()
    {
        Invoke("OneTime", timeBeforeResetInvoke);
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
        Debug.Log("collide" + other);

        if ((hand && justOneTime) || (justOneTime && GetComponent<Interactable>().attachedToHand != null))
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
        Debug.Log("tu peux attraper une pierre");
    }
 }
