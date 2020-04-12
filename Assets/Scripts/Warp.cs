using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warp : MonoBehaviour
{
    public GameObject limiteZone;

    private void Start()
    {
        limiteZone.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("je suis detecté");
            limiteZone.SetActive(true);
        } 
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("je suis pus detecté");
            limiteZone.SetActive(false);
        }
    }
}

    