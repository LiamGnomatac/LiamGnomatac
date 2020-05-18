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
        if(other.gameObject == statuette && !statuette.GetComponent<Throwable>())
        {
            statuette.AddComponent<Interactable>();
            statuette.AddComponent<Throwable>();
        }
        if (other.gameObject == statuette)
        {
            Debug.Log(statuette.name);
            statuette.transform.position = transform.position;
            statuette.transform.Rotate(transform.rotation.eulerAngles);
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
        if(other.gameObject == statuette )
        {
            GameManager.s_Singleton.statueIsStatic--;
            statuette.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        }

        if (GameManager.s_Singleton.statueIsStatic < 2)
        {
            GameManager.s_Singleton.thirdEIsComplete = false;
        }



    }


    public void StatueAreCatchable()
    {
        if (GameManager.s_Singleton.isPressMain && GameManager.s_Singleton.isPress)
        {
            if (!statuette.GetComponent<Interactable>())
            {
                statuette.AddComponent<Interactable>();
                statuette.AddComponent<Throwable>();
                statuette.GetComponent<Renderer>().material.color = Color.green;
            }

        }
    }

}
