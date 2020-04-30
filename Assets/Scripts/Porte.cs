using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Porte : MonoBehaviour
{
    public bool isDoor1;
    public bool isDoor2;
    public bool isDoor3;
    public float timeBeforeOpen;
    public float timeForOpen = 1.35f;
    private bool justOneTime = false;

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
            /*if (!GameManager.s_Singleton.firstEIsComplete)
            {
                CloseDoor();
                return;
            }
            else
                Invoke("OpenDoor", timeBeforeOpen);*/
            if(GameManager.s_Singleton.firstEIsComplete)
            {
                if(!justOneTime)
                
                {
                    Invoke("OpenDoor", timeBeforeOpen);
                }
                Invoke("OneTime", timeForOpen);
            }
            else
            {
                CloseDoor();
                justOneTime = false;
            }
        }
        if (isDoor2)
        {
            /*if (!GameManager.s_Singleton.secondEIsComplete)
            {
                CloseDoor();
                return;
            }
            else
                Invoke("OpenDoor", timeBeforeOpen);*/
            if (GameManager.s_Singleton.secondEIsComplete)
            {
                if (!justOneTime)
                {
                    Invoke("OpenDoor", timeBeforeOpen);
                }
                Invoke("OneTime", timeForOpen);
            }
            else
            {
                CloseDoor();
                justOneTime = false;
            }
        }
        if (isDoor3)
        {
            /*if (!GameManager.s_Singleton.thirdEIsComplete)
            {
                CloseDoor();
                return;
            }
            else
               Invoke("OpenDoor",timeBeforeOpen);*/
            if (GameManager.s_Singleton.thirdEIsComplete)
            {
                if (!justOneTime)

                {
                    Invoke("OpenDoor", timeBeforeOpen);
                }
                Invoke("OneTime", timeForOpen);
            }
            else
            {
                CloseDoor();
                justOneTime = false;
            }
        }
        else
            return;
            
        }

    private void OpenDoor()
    {
        //transform.rotation = Quaternion.Euler(0, -90, 0);
        transform.Rotate(pos.transform.rotation.x, pos.transform.rotation.y -1 , pos.transform.rotation.z,Space.World);
    }

    private void CloseDoor()
    {
        transform.Rotate(-pos.transform.rotation.x, -pos.transform.rotation.y, -pos.transform.rotation.z,Space.World);
    }

    private void OneTime()
    {
        justOneTime = true;
    }
}
