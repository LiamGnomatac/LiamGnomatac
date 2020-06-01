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
        thisRock = Instantiate(rock, value.transform);//transform.position, Quaternion.identity);
        value.hand.hand.AttachObject(thisRock, GrabTypes.Grip);
    }

    private void OnTriggerEnter(Collider other)
    {
        HandCollider hand = other.GetComponentInParent<HandCollider>();
        Debug.Log("collision with" + other);
        if (hand)
        {
            Debug.Log("collide" + other);
            InvokeRock(hand);
        }
    }
}
