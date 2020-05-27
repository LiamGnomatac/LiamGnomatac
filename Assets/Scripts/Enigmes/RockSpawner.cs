using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

 public class RockSpawner : MonoBehaviour
 {
    public GameObject rock;

    private void InvokeRock(HandCollider value)
    {
        GameObject thisRock;
        thisRock = Instantiate(rock, transform.position, Quaternion.identity);
        value.hand.hand.AttachObject(thisRock, GrabTypes.Grip);
    }

    private void OnTriggerEnter(Collider other)
    {
        HandCollider hand = other.GetComponentInParent<HandCollider>();
        if (hand)
        {
            InvokeRock(hand);
        }
    }
}
