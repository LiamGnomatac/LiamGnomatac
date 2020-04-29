using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class Piedestale : MonoBehaviour
{
    public GameObject statuette;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == statuette)
        {
            Debug.Log("je rentre");
            statuette.transform.position = transform.position;
            statuette.transform.Rotate(transform.rotation.eulerAngles);
            statuette.GetComponent<Interactable>().enabled = false;
            statuette.GetComponent<Throwable>().enabled = false;
            statuette.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            GameManager.s_Singleton.statueIsStatic++;
        }
        if (GameManager.s_Singleton.statueIsStatic >= 2)
        {
            GameManager.s_Singleton.thirdEIsComplete = true;
            GameManager.s_Singleton.statueIsStatic = 2;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject == statuette)
        {
            GameManager.s_Singleton.statueIsStatic--;
        }

        if (GameManager.s_Singleton.statueIsStatic < 2)
        {
            GameManager.s_Singleton.thirdEIsComplete = false;
        }
    }
}
