using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class PorteTorche : MonoBehaviour
{
    public Collider torchE;

    // Start is called before the first frame update
    void Start()
    {
        if(torchE == null)
        {
            Debug.Log("Torche à renseigner dans porteTorche");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other != torchE)
        { return; }

        if(other == torchE)
        {
            GameManager.s_Singleton.firstEIsComplete = true;
            torchE.transform.position = transform.position;
            torchE.transform.Rotate(transform.rotation.eulerAngles);
            torchE.GetComponent<Throwable>().enabled = false;
            torchE.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other != torchE)
            return;

        if (other == torchE)
        {
            GameManager.s_Singleton.firstEIsComplete = false;
            torchE.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        }
    }
}
