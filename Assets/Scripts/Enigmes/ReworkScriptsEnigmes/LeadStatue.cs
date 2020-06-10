using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class LeadStatue : MonoBehaviour
{
    public EncensCS encens;
    public GameObject monologueToDestroy;
    public List<GameObject> statuettes;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < statuettes.Count; i++)
        {
            if (!statuettes[i].GetComponent<Interactable>())
            {
                statuettes[i].AddComponent<Interactable>();
            }
        }
    }

    public void StatueAreCatchable()
    {
        if (EnigmesManager.s_Singleton.isPressMain && EnigmesManager.s_Singleton.isPress)
        {
            for (int i = 0; i < statuettes.Count; i++)
            {
                if (!statuettes[i].GetComponent<Throwable>())
                {
                    statuettes[i].AddComponent<Throwable>();
                    statuettes[i].GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                    encens.FilledWithOil();
                    encens.TurnOn();
                    statuettes[i].GetComponent<Renderer>().material.color = Color.green;
                }
            }
            if (GetComponent<StoryElementMonologue>())
            {
                Destroy(monologueToDestroy);
                GetComponent<StoryElementMonologue>().TriggerMonologue();
                Destroy(GetComponent<StoryElementMonologue>());
            }
        }
    }
}
