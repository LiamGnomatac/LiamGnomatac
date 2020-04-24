using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaquePression : MonoBehaviour
{
    private Vector3 pos;
    private Vector3 onPress;
    public bool isMain;
    public float pressureDist;

    // Start is called before the first frame update
    void Start()
    {
        pos = transform.position;
        onPress.y = pressureDist;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Press();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            Release();
        }
    }

    private void Press()
    {
        Debug.Log("press");
        transform.position -= onPress;
        if(isMain)
        {
            GameManager.s_Singleton.isPressMain = true;
            return;
        }
        else
        {
            GameManager.s_Singleton.isPress = true;
            return;
        }
    }

    private void Release()
    {
        Debug.Log("pos");
        transform.position = pos;
        if (isMain)
        {
            GameManager.s_Singleton.isPressMain = false;
            return;
        }
        else
        {
            GameManager.s_Singleton.isPress = false;
            return;
        }

    }
}
