using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightTrigger : MonoBehaviour
{
    public StoryElementMonologue[] monologue;
    private int i;
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("LightTrigger"))
        {
            monologue[i].TriggerMonologue();
            if(monologue.Length == 0)
            {
                Destroy(this);
            }
        }
    }
}
