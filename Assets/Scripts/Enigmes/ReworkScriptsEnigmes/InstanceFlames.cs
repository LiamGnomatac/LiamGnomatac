using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class InstanceFlames : MonoBehaviour
{
    private Interactable myInteractable;
    private bool hasBeenInHand = false;
    public GameObject flameVFX;
    private int numberOfFlames;
    public StoryElementMonologue monologue;
    // Start is called before the first frame update
    void Start()
    {
        myInteractable = GetComponent<Interactable>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasBeenInHand)
        {
            hasBeenInHand = (myInteractable.attachedToHand != null);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
            if(collision.gameObject.layer == 9 && hasBeenInHand)
            {
                Instantiate(flameVFX, transform.position, Quaternion.identity);
                numberOfFlames++;
                if(numberOfFlames > 5)
                {
                    RemonterM.s_Singleton.spawnFlames();
                    monologue.TriggerMonologue();
                    GetComponentInChildren<Light>().gameObject.SetActive(false);
                    Destroy(monologue);
                }
            }
    
        if(hasBeenInHand && collision.gameObject.layer == 9)
        {
            RemonterM.s_Singleton.spawnFlames();
        }
    }
}
