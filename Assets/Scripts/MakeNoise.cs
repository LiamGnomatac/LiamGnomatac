﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class MakeNoise : MonoBehaviour
{
    public bool justOneHit = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("collision with" + collision);
        if (GetComponent<Interactable>().attachedToHand != null)
        {
            justOneHit = true;
            Debug.Log(justOneHit);
        }
        if(collision.gameObject.layer == LayerMask.NameToLayer("Salle") && justOneHit)
        {
            Debug.Log("bruit");
            Vector3 pos = transform.position;
            TaureauScript.s_Singleton.SetDestination(pos);
            justOneHit = false;
        }
    }


}
