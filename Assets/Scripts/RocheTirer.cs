using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class RocheTirer : MonoBehaviour
{
    private Transform pos;
    public int distancePull;

    // Start is called before the first frame update
    void Start()
    {
        pos = transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x <= pos.position.x)
        {
            Debug.Log("Neutre");
            transform.position = pos.position;
            gameObject.GetComponent<Interactable>().enabled = true;
            GameManager.s_Singleton.pullRock1 = false;
            return;
            
        }
        if (transform.position.x >= pos.position.x + distancePull)
        {
            gameObject.GetComponent<Interactable>().enabled = false;
            GameManager.s_Singleton.pullRock1 = true;
            ReturnToPosition();
            Debug.Log("Avant");
        }

    }

    private void ReturnToPosition()
    {
        transform.Translate(pos.position);
    }



}
