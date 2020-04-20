using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Encens : MonoBehaviour
{
    public GameObject encens;
    public GameObject vfxSparx;
    public bool EncensIsTriggerOrNot;
    public bool EncensIsTurnOnOrNot;
    public bool FillOrNot;
    public bool SparkOrNot;
    public Material defaultMaterial;
    public Material newMaterialTrigger;
    public Material newMaterialTurnOn;
    int triggerManette = 0;
    int triggerCaillou = 0;
   



    // Start is called before the first frame update
    void Start()
    {
        EncensIsTriggerOrNot = false;
        EncensIsTurnOnOrNot = false;
        FillOrNot = false;
        vfxSparx.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        // Si les manettes (objet taggé "Hand") sont en collision avec l'encens et qu'on appuie sur espace... [allumage ou non des encens]
        
        if (triggerManette > 0  && Input.GetKeyDown("space"))
        {
            EncensIsTurnOnOrNot = !EncensIsTurnOnOrNot;
        }

        if (EncensIsTurnOnOrNot == true)
        {
            Debug.Log("Encens Allumé!");
        }

        if (EncensIsTurnOnOrNot == false)
        {
            Debug.Log("Encens Eteint!");
        }


        // Si les manettes (objet taggé "Hand") sont en collision avec l'encens [activation ou non du boolean]

        if (triggerManette > 0)
        {
            EncensIsTriggerOrNot = true;
        }

        if (triggerManette <= 0)
        {
            EncensIsTriggerOrNot = false;
        }


        // Si on appuie sur "h" remplissage ou non de l'encens [si vrai il est plein/ si faux il n'est pas plein]

        if ( Input.GetKeyDown("h"))
        {
            FillOrNot = !FillOrNot;
        }

        if (FillOrNot == true)
        {
            Debug.Log("Encens Remplit!");
        }

        if (FillOrNot == false)
        {
            Debug.Log("Encens Vide!");
        }


        // Si on appuie sur "p" activation des étincelle [cette commande et là que pour le playtest pour gagner du temps]

        if (Input.GetKeyDown("p"))
        {
            SparkOrNot = !SparkOrNot;
        }


        // Si on utilise les cailloux (objet taggé Caillou), qu'on est dans la zone de trigger de l'encens et que l'encens et plein : activation des étincelles

        if (triggerCaillou > 0 && FillOrNot == true)
        {
           SparkOrNot = true;
            
        }

        if (triggerCaillou <= 0 || FillOrNot == false)
        {
           SparkOrNot = false;
        }

        if (SparkOrNot == true)
        {
            vfxSparx.SetActive(true);
            Debug.Log("Des étincelles apparaissent");
        }

        if (SparkOrNot == false)
        {
            vfxSparx.SetActive(false);
            Debug.Log("Pas d'étincelles ");
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Hand")
        {
            triggerManette ++;
            encens.GetComponent<Renderer>().material = newMaterialTrigger;
            Debug.Log("IsTrigger dans la manette!");
        }

        if (other.gameObject.tag == "Caillou")
        {
            triggerCaillou++;
            Debug.Log("IsTrigger dans les cailloux!");
        }


    }


    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Hand")
        {
            triggerManette --;
            encens.GetComponent<Renderer>().material = defaultMaterial;
        }

        if (other.gameObject.tag == "Caillou")
        {
            triggerCaillou--;
            
        }
        
    }



}
