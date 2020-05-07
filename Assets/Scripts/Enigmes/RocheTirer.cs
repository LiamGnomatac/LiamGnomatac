using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class RocheTirer : MonoBehaviour
{
    public bool isEndE2;
    public bool isReturn;
    public float speed;
    public GameObject LinearMapping;
    private Renderer myMat;

    // Start is called before the first frame update
    void Start()
    {
        myMat = gameObject.GetComponent<Renderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        FeedBack();
        if (transform.position == GetComponent<LinearDrive>().startPosition.position)
        {
            //Debug.Log("Neutre");
            transform.position = GetComponent<LinearDrive>().startPosition.position;
            LinearMapping.GetComponent<LinearMapping>().value = 0f;
            Actions();
            return;
            
        }
        else
        {
            //Debug.Log("tirer");
            ReturnToPosition();
            ReActions();
        }

    }

    private void Actions()
    {
        if(isEndE2)
        {
            return;
        }
        else
        {
            GameManager.s_Singleton.pullRock1 = false;
            GameManager.s_Singleton.ResetButton();
        }
    }

    private void ReActions()
    {
        if (isEndE2 && GameManager.s_Singleton.rockSort)
        {
            CloseDoor();
        }
        else
        {
            GameManager.s_Singleton.pullRock1 = true;
        }
    }

    private void ReturnToPosition()
    {
        transform.position = Vector3.MoveTowards(transform.position, GetComponent<LinearDrive>().startPosition.position, Time.deltaTime * speed);
    }

    private void CloseDoor()
    {
        if(!isReturn)
        {
            GameManager.s_Singleton.secondEIsComplete = false;
            return;
        }
        else
        {
            GameManager.s_Singleton.secondEIsComplete = true;
        }
    }

    public void FeedBack()
    {
        if(isEndE2)
        {
            return;
        }
        else
        {
            if (LinearMapping.GetComponent<LinearMapping>().value <= 0)
            {
                gameObject.GetComponent<Renderer>().material.color = Color.white;
            }
            if (LinearMapping.GetComponent<LinearMapping>().value > 0)
            {
                gameObject.GetComponent<Renderer>().material.color = Color.red;
            }
            if (LinearMapping.GetComponent<LinearMapping>().value > .25f)
            {
                gameObject.GetComponent<Renderer>().material.color = Color.green;
            }
            if (LinearMapping.GetComponent<LinearMapping>().value > .5f)
            {
                gameObject.GetComponent<Renderer>().material.color = Color.blue;
            }
            if (LinearMapping.GetComponent<LinearMapping>().value > .75f)
            {
                gameObject.GetComponent<Renderer>().material.color = Color.magenta;
            }
        }
    }
}
