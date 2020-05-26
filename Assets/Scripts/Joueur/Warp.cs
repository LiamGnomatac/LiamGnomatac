using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warp : MonoBehaviour
{

    public GameObject limiteZone;
    public GameObject encens;
   
    public bool isItDark;
    
    

    void Start()
    {
        
       
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("pied");
        if (other.CompareTag("Player"))
        {
            ChienScript.s_Singleton.joueurSurZone = true;
            Debug.Log("c'est rouge");
            limiteZone.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ChienScript.s_Singleton.joueurSurZone = false;
            Debug.Log("C'est pu rouge");
            limiteZone.SetActive(false);
        }
    }


    void Update()
    {

        if(encens.GetComponent<EncensCS>().isTurnOn == true)
        {
            isItDark = false;
        }
        else
        {
            isItDark = true;
        }

        if(limiteZone == true && isItDark == true)
        {

            ChienScript.s_Singleton.dogCanAttackOnLight = true;

        }

        else
        {

            ChienScript.s_Singleton.dogCanAttackOnLight = false;

        }
    }


}

    