using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warp : MonoBehaviour
{
    public GameObject center;
    public GameObject limiteZone;
    public GameObject zoneVue;
    public GameObject zoneSelect;

    private void Start()
    {
        limiteZone.SetActive(false);
        zoneVue.SetActive(false);
        zoneSelect.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("pied");
        if (other.CompareTag("Player"))
        {
            Debug.Log("c'est rouge");
            limiteZone.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("C'est pu rouge");
            limiteZone.SetActive(false);
        }
    }
}

    