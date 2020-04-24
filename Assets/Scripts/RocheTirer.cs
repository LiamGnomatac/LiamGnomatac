using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class RocheTirer : MonoBehaviour
{
    public bool isEndE2;
    public float speed;
    public GameObject LinearMapping;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(transform.position.x <= GetComponent<LinearDrive>().startPosition.position.x)
        {
            //Debug.Log("Neutre");
            transform.position = GetComponent<LinearDrive>().startPosition.position;
            LinearMapping.GetComponent<LinearMapping>().value = 0f;
            Actions();
            return;
            
        }
        else
        {
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
            GameManager.s_Singleton.secondEIsComplete = true;
        }
        else
        {
            GameManager.s_Singleton.pullRock1 = true;
        }
    }

    private void ReturnToPosition()
    {
        transform.position = Vector3.MoveTowards(transform.position, GetComponent<LinearDrive>().startPosition.position, Time.deltaTime * speed);
        //LinearMapping.GetComponent<LinearMapping>().value = transform.position.x /GetComponent<LinearDrive>().endPosition.position.x;
    }
}
