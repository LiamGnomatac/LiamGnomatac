using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warp : MonoBehaviour
{
    public GameObject warp;
    public GameObject limiteZone;
    public EncensCS encens;

    public bool isItDark = true;
    
    

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
            IsItDark();
            ChienScript.s_Singleton.CancelDogAttack();

            
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ChienScript.s_Singleton.joueurSurZone = false;
            Debug.Log("C'est pu rouge");
            limiteZone.SetActive(false);
            ChienScript.s_Singleton.PlayerOutZone();


        }
    }


    void Update()
    {

        


        

    }


    private void IsItDark()
    {
        if (encens.isTurnOn)
        {
            warp.GetComponent<Warp>().isItDark = false;
        }
        else
        {
            warp.GetComponent<Warp>().isItDark = true;
            CanAttack();
        }

        Debug.Log("c'est allumé " + isItDark);
    }

    private void CanAttack()
    {
        if (limiteZone == true && isItDark == true)
        {

            ChienScript.s_Singleton.ChienAttackOnLight();

        }
        else
        {
            CanAttack();
        }
    }

}

    