using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class PorteTorche : MonoBehaviour
{
    public Collider torchE;
    private Vector3 pos;
    private Vector3 rot;
    public GameObject VFX;


    // Start is called before the first frame update
    void Start()
    {
        pos = transform.position;
        pos.x += 0.1f;
        rot = transform.rotation.eulerAngles;
        if(torchE != gameObject)
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
            EnigmesManager.s_Singleton.firstEIsComplete = true;
            torchE.transform.position = pos;
            torchE.transform.rotation = transform.rotation;
            torchE.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            VFX.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other != torchE)
            return;

        if (other == torchE)
        {
            torchE.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            EnigmesManager.s_Singleton.firstEIsComplete = false;
            VFX.SetActive(false);
        }
    }
}
