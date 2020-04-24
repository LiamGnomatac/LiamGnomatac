using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaquePression : MonoBehaviour
{
    private Vector3 pos;
    private Vector3 onPress;
    public bool isMain;
    public float pressureDist;
    public GameObject trapDoor;

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
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            trapDoor.GetComponent<TrapDoor>().OnPress();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            Release();
            trapDoor.GetComponent<TrapDoor>().OnRelease();
        }
    }

    private void Press()
    {
        transform.position -= onPress;
    }

    private void Release()
    {
        transform.position = pos;
    }
}
