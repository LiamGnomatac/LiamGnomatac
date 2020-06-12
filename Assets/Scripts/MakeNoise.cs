using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class MakeNoise : MonoBehaviour
{
    public bool justOneHit = false;

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("collision with" + collision);
        if (GetComponent<Interactable>().attachedToHand != null || collision.gameObject.GetComponentInParent<HandCollider>())
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


}
