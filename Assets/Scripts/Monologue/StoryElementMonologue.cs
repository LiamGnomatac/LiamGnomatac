using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class StoryElementMonologue : MonoBehaviour
{
    public Monologues monologue;
    public bool activateWithTrigger = false;
    public bool activeGrab = false;

    public void TriggerMonologue()
    {
        if(SentenceManager.s_Singleton)
        {
            SentenceManager.s_Singleton.StartMonologue(monologue);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player") && activateWithTrigger)
        {
            TriggerMonologue();
            Destroy(gameObject);
        }

        if(activeGrab && GetComponent<Interactable>().attachedToHand != null)
        {
            TriggerMonologue();
            Destroy(this);
        }
    }
}
