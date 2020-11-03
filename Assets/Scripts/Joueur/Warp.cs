using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warp : MonoBehaviour
{
    public GameObject warp;
    public GameObject limiteZone;
    public EncensCS encens;
    private bool isItDark;

    void Start()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        //Debug.Log("pied");
        if (other.CompareTag("Player")&& ChienScript.s_Singleton)
        {
            IsItDark();
            ChienScript.s_Singleton.joueurSurZone = true;
            //Debug.Log("c'est rouge");
            limiteZone.SetActive(true);
            ChienScript.s_Singleton.CancelDogAttack();
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && ChienScript.s_Singleton)
        {
            ChienScript.s_Singleton.joueurSurZone = false;
            //Debug.Log("C'est pu rouge");
            limiteZone.SetActive(false);
            ChienScript.s_Singleton.PlayerOutZone();
        }
    }

    void Update()
    {
        if(TPPerso.s_Singleton.flash.state)
        {
            Debug.Log("appuie sur touche");
            IsItDark();
        }
    }
    private void IsItDark()
    {
        if(encens)
        {
            if (encens.isTurnOn)
            {
                ChienScript.s_Singleton.dogCanAttackOnLight = false;
                isItDark = false;
                Debug.Log("éteint");
            }
            else
            {
                ChienScript.s_Singleton.dogCanAttackOnLight = true;
                isItDark = true;
                Debug.Log("allumé");
            }
            Debug.Log("isItDark = " + isItDark);
        }
    }

    private void CanAttack()
    {
        if (limiteZone == true && isItDark == true && ChienScript.s_Singleton)
        {
            ChienScript.s_Singleton.ChienAttackOnLight();
        }
        else
        {
            CanAttack();
        }
    }

}

    