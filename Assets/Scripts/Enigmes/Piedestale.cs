using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class Piedestale : MonoBehaviour
{
    public GameObject statuette;
    public StoryElementMonologue monologueOpenDoor;
    public Door door;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == statuette && !statuette.GetComponent<Throwable>())
        {
            statuette.AddComponent<Throwable>();
        }
        if (other.gameObject == statuette)
        {
            Debug.Log(statuette.name);
            statuette.transform.position = transform.position;
            statuette.transform.Rotate(transform.rotation.eulerAngles);
            statuette.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            EnigmesManager.s_Singleton.statueIsStatic++;
        }
        if (EnigmesManager.s_Singleton.statueIsStatic >= 2)
        {
            Debug.Log("porte ouverte");
            door.Open();
            if(monologueOpenDoor)
            {
                monologueOpenDoor.TriggerMonologue();
                Destroy(monologueOpenDoor.gameObject);
            }
            EnigmesManager.s_Singleton.statueIsStatic = 2;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject == statuette )
        {
            EnigmesManager.s_Singleton.statueIsStatic--;
            statuette.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        }
        if (EnigmesManager.s_Singleton.statueIsStatic < 2)
        {
            Debug.Log("porte fermer");
            door.Close();
        }
    }
}
