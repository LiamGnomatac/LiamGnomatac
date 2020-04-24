using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Porte : MonoBehaviour
{
    public bool isDoor1;
    public bool isDoor2;
    public bool isDoor3;

    private Transform pos;
    // Start is called before the first frame update
    void Start()
    {
        pos = transform;
    }
    
    void FixedUpdate()
    {
        if (isDoor1)
        {
            if (!GameManager.s_Singleton.firstEIsComplete)
            {
                CloseDoor();
                return;
            }
            else
                Invoke("OpenDoor", 5);
        }
        if (isDoor2)
        {
            if (!GameManager.s_Singleton.secondEIsComplete)
            {
                CloseDoor();
                return;
            }
            else
                Invoke("OpenDoor", 5);
        }
        if (isDoor3)
        {
            if (!GameManager.s_Singleton.thirdEIsComplete)
            {
                CloseDoor();
                return;
            }
            else
               Invoke("OpenDoor",5);
        }
        else
            return;
    }

    private void OpenDoor()
    {
        transform.rotation = Quaternion.Euler(0, -90, 0);
    }

    private void CloseDoor()
    {
        transform.Rotate(-pos.transform.rotation.x, -pos.transform.rotation.y, -pos.transform.rotation.z);
    }
}
