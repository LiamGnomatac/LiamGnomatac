using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            torchE.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            Debug.Log("Enigme complété");
        }
    }
}
