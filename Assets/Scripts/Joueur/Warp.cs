using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warp : MonoBehaviour
{

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

        


        

    }


    private void IsItDark()
    {
        if (encens.isTurnOn)
        {
            isItDark = false;
        }
        else
        {
            isItDark = true;
        }

        Debug.Log("c'est allumé " + isItDark);
    }

    private void CanAttack()
    {
        if (limiteZone == true && isItDark == true)
        {

            ChienScript.s_Singleton.dogCanAttackOnLight = true;

        }

        else
        {

            ChienScript.s_Singleton.ChienAttackOnLight();

        }
    }

}

    