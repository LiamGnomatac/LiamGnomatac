using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class MakeNoise : MonoBehaviour
{
    public bool justOneHit = false;
    private Hand hand;

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("collision with" + collision);
        if (hand || GetComponent<Interactable>().attachedToHand != null || collision.gameObject.GetComponentInParent<HandCollider>())
        {
            justOneHit = true;
            Debug.Log(justOneHit);
            if (GetComponent<StoryElementMonologue>())
            {
                GetComponent<StoryElementMonologue>().TriggerMonologue();
                Destroy(GetComponent<StoryElementMonologue>());
            }
        }
        if(collision.gameObject.layer == LayerMask.NameToLayer("Salle") && justOneHit)
        {
            Debug.Log("bruit");
            Vector3 pos = transform.position;
            TaureauScript.s_Singleton.SetDestination(pos);
            justOneHit = false;
        }
    }
    private void OnHandHoverBegin(Hand hand)
    {
        this.hand = hand;
    }

    private void OnHandHoverEnd(Hand hand)
    {
        this.hand = null;
    }


}
