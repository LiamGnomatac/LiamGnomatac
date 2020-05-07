using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class CatchRock : MonoBehaviour
{
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
        if(other.GetComponent<Throwable>())
        {
            if(isMain)
            {
                GameManager.s_Singleton.isPressMain = true;
            }
            else
            {
                GameManager.s_Singleton.isPress = true;
            }
            GameManager.s_Singleton.StatueAreCatchable();
        }
    }
}
