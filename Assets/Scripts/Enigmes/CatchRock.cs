using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class CatchRock : MonoBehaviour
{
    public LeadStatue statues;
    public bool isMain;
    public GameObject caillasse; 

    // Start is called before the first frame update
    void Start()
    {
        caillasse.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name);
        if (other.gameObject.GetComponent<Throwable>())
        {
            Debug.Log("contact");
            if (isMain)
            {
                EnigmesManager.s_Singleton.isPressMain = true;
                caillasse.SetActive(true);
                //GetComponent<Renderer>().material.color = Color.green;
                if (GetComponent<StoryElementMonologue>())
                {
                    GetComponent<StoryElementMonologue>().TriggerMonologue();
                    Destroy(GetComponent<StoryElementMonologue>());
                }
            }
            else
            {
                EnigmesManager.s_Singleton.isPress = true;
                caillasse.SetActive(true);
                //GetComponent<Renderer>().material.color = Color.green;
            }
            statues.StatueAreCatchable();
        }
    }
}
