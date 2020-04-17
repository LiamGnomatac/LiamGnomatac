﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;
using Valve.VR;

public class TPPerso : MonoBehaviour
{
    // Variable

  
    private Player player;
    private Vector3 lookAtPosition = Vector3.zero;
    private Transform lookAtJointTransform;
    public Transform cameraVR;
    public GameObject zoneDeJeu;
    public GameObject center;
    public Transform tpPoint;
    private Vector3 fwd;
    public SteamVR_Action_Boolean teleport;
    private bool zoneVisible = false;
    public GameObject zoneVue;
    public GameObject zoneSelect;
    private bool zoneVueActive = false;
    private bool zoneSelectActive = false;
    private GameObject vue;
    private GameObject select;

    void Start()
    {
        player = Player.instance;
        fwd = cameraVR.TransformDirection(Vector3.forward);
       
    }


    //-------------------------------------------------
    void Update()
    {
        vue = GameObject.FindGameObjectWithTag("ZoneVue");

        select = GameObject.FindGameObjectWithTag("ZoneSelect");

        fwd = cameraVR.TransformDirection(Vector3.forward);

        int layerMask = 1 << 8;

        // This would cast rays only against colliders in layer 8.

        // But instead we want to collide against everything except layer 8. The ~ operator does this, it inverts a bitmask.

        layerMask = ~layerMask;

        RaycastHit hit;

        // Does the ray intersect any objects excluding the player layer
        Debug.DrawRay(cameraVR.position, cameraVR.forward * 5, Color.red);

        //Range de 10
        if (Physics.Raycast(cameraVR.position, cameraVR.forward, out hit, 10, layerMask))
        {
            Debug.Log(hit.transform.name);

            // Un comparetag sur le raycast
            if (hit.collider.gameObject.CompareTag("ZoneTP"))
            {
                Debug.Log("Zone visible OK");
                if (zoneVueActive == false)
                {
                    Instantiate(zoneVue, hit.transform.position, hit.transform.rotation);
                    vue = GameObject.FindGameObjectWithTag("ZoneVue");
                    zoneVueActive = true;
                }   
               // Input tp
                if (teleport.stateDown )
                {
                    if (zoneSelectActive == false)
                    {
                        Instantiate(zoneSelect, hit.transform.position, hit.transform.rotation);
                        select = GameObject.FindGameObjectWithTag("ZoneSelect");
                        zoneSelectActive = true;

                    }

                    Destroy(vue);
                    zoneVueActive = false;

                   
                }

                if (teleport.stateUp)
                {


                    // TP Center                
                    center.transform.position = hit.transform.position;
                    Debug.Log("GetFlashTrue");
                    Destroy(select);
                    zoneSelectActive = false;
                }
            }
            

            else
            {
                Destroy(vue);
                zoneVueActive = false;
                Destroy(select);
                zoneSelectActive = false;
                Debug.DrawRay(cameraVR.position, cameraVR.TransformDirection(Vector3.forward) * 1000, Color.white);
                Debug.Log("Did not Hit");
            }
            if (Physics.Raycast(cameraVR.position, cameraVR.TransformDirection(Vector3.forward), out hit, 5, layerMask))
            {

            }
        }
        else
        {
           
        }

        
    }

    
   
}
