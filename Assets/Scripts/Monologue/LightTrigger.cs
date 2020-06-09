using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightTrigger : MonoBehaviour
{
    public List<StoryElementMonologue> monologue;
    private int i;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == 10)
        {
            monologue[i].TriggerMonologue();
            monologue.RemoveAt(i);
            if(monologue.Count == 0)
            {
                Destroy(this);
            }
        }
    }
}
