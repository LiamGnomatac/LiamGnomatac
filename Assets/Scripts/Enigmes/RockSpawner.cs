using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

 public class RockSpawner : MonoBehaviour
 {
    public GameObject rock;

    private void InvokeRock(Hand value)
    {
        GameObject thisRock;
        thisRock = Instantiate(rock, transform.position, Quaternion.identity);
        value.AttachObject(thisRock, GrabTypes.Grip);
    }

    private void OnTriggerEnter(Collider other)
    {
        Hand hand = other.GetComponent<Hand>();
        if (hand)
        {
            InvokeRock(hand);
        }
    }
}
