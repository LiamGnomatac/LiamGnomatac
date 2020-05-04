using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warp : MonoBehaviour
{
    public GameObject center;
    public GameObject limiteZone;
    public GameObject chien;
    public bool isItDark;
    
    

    private void Start()
    {
        
       
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("pied");
        if (other.CompareTag("Player"))
        {
            chien.GetComponent<ChienScript>().joueurSurZone = true;
            Debug.Log("c'est rouge");
            limiteZone.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            chien.GetComponent<ChienScript>().joueurSurZone = false;
            Debug.Log("C'est pu rouge");
            limiteZone.SetActive(false);
        }
    }


    private void Update()
    {
        if(limiteZone == true && isItDark == true)
        {

            chien.GetComponent<ChienScript>().dogCanAttackOnLight = true;

        }

        else
        {

            chien.GetComponent<ChienScript>().dogCanAttackOnLight = false;

        }
    }


}

    