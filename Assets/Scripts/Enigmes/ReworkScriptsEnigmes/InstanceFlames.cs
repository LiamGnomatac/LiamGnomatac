using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class InstanceFlames : MonoBehaviour
{
    public GameObject flameVFX;
    private bool canMakeFlame;
    private int numberOfFlames;
    public StoryElementMonologue monologue;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (GetComponent<Interactable>().attachedToHand != null)
        {
            canMakeFlame = true;
            if(collision.gameObject.layer == 9)
            {
                Instantiate(flameVFX, transform.position, Quaternion.identity);
                numberOfFlames++;
                if(numberOfFlames > 5)
                {
                    RemonterM.s_Singleton.GoToCredits();
                    monologue.TriggerMonologue();
                    GetComponentInChildren<Light>().gameObject.SetActive(false);
                    Destroy(monologue);
                    Destroy(this);
                }
            }
        }
        if(canMakeFlame && collision.gameObject.layer == 9)
        {
            RemonterM.s_Singleton.spawnFlames();
        }
    }
}
