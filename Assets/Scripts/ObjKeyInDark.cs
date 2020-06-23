using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjKeyInDark : MonoBehaviour
{
    public float timeToReturn;
    private Vector3 pos;

    // Start is called before the first frame update
    void Start()
    {
        pos = transform.position;
        transform.position = pos;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "ZoneTP")
        {
            CancelInvoke("returnToPos");
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "ZoneTP")
        {
            Invoke("returnToPos", timeToReturn);
        }
        
    }

    private void returnToPos()
    {
        transform.position = pos;
        GameManager.s_Singleton.objKeyLaunch++;
        Debug.Log(GameManager.s_Singleton.objKeyLaunch);
    }
}
