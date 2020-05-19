using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class CatchRock : MonoBehaviour
{
    public GameObject piedestale;
    public bool isMain;

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
        Debug.Log(other.name);
        if (other.gameObject.GetComponent<Throwable>())
        {
            
            Debug.Log("contact");
            if (isMain)
            {
                EnigmesManager.s_Singleton.isPressMain = true;
                GetComponent<Renderer>().material.color = Color.green;
            }
            else
            {
                EnigmesManager.s_Singleton.isPress = true;
                GetComponent<Renderer>().material.color = Color.green;
            }
            piedestale.GetComponent<Piedestale>().StatueAreCatchable();
        }
    }
}
