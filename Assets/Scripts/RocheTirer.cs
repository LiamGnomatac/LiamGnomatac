using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class RocheTirer : MonoBehaviour
{
    private Vector3 pos;
    public float distancePull;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        pos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x <= pos.x)
        {
            Debug.Log("Neutre");
            transform.position = pos;
            gameObject.GetComponent<Interactable>().enabled = true;
            GameManager.s_Singleton.pullRock1 = false;
            return;
            
        }
        if (transform.position.x >= pos.x + distancePull)
        {
            Debug.Log("Avant");
            gameObject.GetComponent<Interactable>().enabled = false;
            GameManager.s_Singleton.pullRock1 = true;
            ReturnToPosition();
        }
        else
        {
            ReturnToPosition();
        }

    }

    private void ReturnToPosition()
    {
        transform.position = Vector3.MoveTowards(transform.position, pos, Time.deltaTime*speed);
    }



}
