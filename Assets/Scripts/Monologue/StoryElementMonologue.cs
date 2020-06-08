using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryElementMonologue : MonoBehaviour
{
    public Monologues monologue;
    public bool activateWithTrigger = false;

    public void TriggerMonologue()
    {
        SentenceManager.s_Singleton.StartMonologue(monologue);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player") && activateWithTrigger)
        {
            TriggerMonologue();
            Destroy(gameObject);
        }
    }
}
