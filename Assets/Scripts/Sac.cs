﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sac : MonoBehaviour
{

    public GameObject sac ;
    public GameObject porte ;
    public GameObject telephone;
    public GameObject lampeTorche;
    public Rigidbody rigidbodyPorte ;
    public bool CanOpenDoor ; 
    float numberOfEssentialsObjects;
    int trigger = 0 ;



    // Start is called before the first frame update
    void Start()
    {
        numberOfEssentialsObjects = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (numberOfEssentialsObjects == 0)
        {
            CanOpenDoor = false;
            Debug.Log("il y a 0 objet important dans le sac");
        }

        if (numberOfEssentialsObjects == 1)
        {
            CanOpenDoor = false;
            Debug.Log("il y a 1/2 objet important dans le sac");
        }

        if (numberOfEssentialsObjects == 2)
        {
            CanOpenDoor = true;
            Debug.Log("il y a 2/2 objet important dans le sac, la porte peux s'ouvrir");
        }

        if (CanOpenDoor == true)
        {
            rigidbodyPorte.constraints = RigidbodyConstraints.None;
        }

        if (CanOpenDoor == false)
        {
            rigidbodyPorte.constraints = RigidbodyConstraints.FreezePositionY;
            rigidbodyPorte.constraints = RigidbodyConstraints.FreezeRotationY;
        }

       
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Essential")
        {
            trigger++;
            numberOfEssentialsObjects += 1;
            Debug.Log("Un Objet important à été mis dans le sac");

        }

        if (other.gameObject.tag == "Telephone")
        {
            trigger++;
            telephone.SetActive(false);
            numberOfEssentialsObjects += 1;
            Debug.Log("Le téléphone a été mis dans le sac et ne peux plus etre récupérer");
        }

        if (other.gameObject.tag == "LampeTorche")
        {
            trigger++;
            lampeTorche.SetActive(false);
            numberOfEssentialsObjects += 1;
            Debug.Log("La Lampe torche a été mis dans le sac et ne peux plus etre récupérer");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Essential")
        {
            trigger--;
            numberOfEssentialsObjects -= 1;
            Debug.Log("Un Objet important à été retiré du sac");
        }
    }
}
