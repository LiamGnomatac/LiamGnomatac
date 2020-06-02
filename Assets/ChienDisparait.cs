using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChienDisparait : MonoBehaviour
{




    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnBecameVisible()
    {
        Debug.Log("Chien Visible");
        ChienScript.s_Singleton.chienCanTP = true;
    }

    public void OnBecameInvisible()
    {

        Debug.Log("Chien inVisible sans TP");
        if (ChienScript.s_Singleton.chienCanTP)
        {
            Debug.Log("Chien Se TP");
            ChienScript.s_Singleton.mesh.SetActive(false);
            ChienScript.s_Singleton.Invoke("ChienTP", 3);

        }


    }

}
