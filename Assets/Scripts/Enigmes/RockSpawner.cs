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
        Invoke("justOneTime", timeBeforeResetInvoke);
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
        Debug.Log("collision with" + other);
        if (hand && justOneTime)
        {
            Debug.Log("collide" + other);
            InvokeRock(hand);
            Invoke("OneTime", timeBeforeResetInvoke);
        }
        justOneTime = false;
    }

    private void OneTime()
    {
        justOneTime = true;
    }
 }
