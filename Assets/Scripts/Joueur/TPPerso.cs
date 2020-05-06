using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Valve.VR.InteractionSystem;
using Valve.VR;

public class TPPerso : MonoBehaviour
{
    // Variable

    private Player player;
    private Vector3 lookAtPosition = Vector3.zero;
    private Transform lookAtJointTransform;
    public Transform cameraVR;
    public GameObject center;
    private Vector3 fwd;
    public SteamVR_Action_Boolean teleport;
    public SteamVR_Action_Boolean flashlight;
    public SteamVR_Action_Boolean flash;
    private bool zoneVisible = false;
    public GameObject zoneVue;
    public GameObject zoneSelect;
    private bool zoneVueActive = false;
    private bool zoneSelectActive = false;
    private bool flashlightSortie = false;
    private GameObject vue;
    private GameObject select;

    public float _fadeDuration = 5f;

    void Start()
    {
        FadeFromBlack();
       
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
            //Debug.Log(hit.transform.name);

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
                    FadeToBlack();
                    // TP Center                
                    center.transform.position = hit.transform.position;
                    Debug.Log("GetFlashTrue");
                    Destroy(select);
                    zoneSelectActive = false;
                    FadeFromBlack();
                }
            }
            

            else
            {
                Destroy(vue);
                zoneVueActive = false;
                Destroy(select);
                zoneSelectActive = false;
                Debug.DrawRay(cameraVR.position, cameraVR.TransformDirection(Vector3.forward) * 1000, Color.white);
                //Debug.Log("Did not Hit");
            }
            if (Physics.Raycast(cameraVR.position, cameraVR.TransformDirection(Vector3.forward), out hit, 5, layerMask))
            {

            }
        }
        else
        {
           
        }


        if (flashlight.stateDown)
        {
            
            GameManager.s_Singleton.AppearTorchLight();
        }

        if (flash.stateDown)
        {

            GameManager.s_Singleton.AppearLight();
        }
    }

    public void FadeToBlack()
    {
        //set start color
        SteamVR_Fade.Start(Color.clear, 0f);
        //set and start fade to
        SteamVR_Fade.Start(Color.black, _fadeDuration);
    }



    public void FadeFromBlack()
    {
        //set start color
        SteamVR_Fade.Start(Color.black, 0f);
        //set and start fade to
        SteamVR_Fade.Start(Color.clear, _fadeDuration);
    }

}
