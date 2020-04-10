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
    int trigger = 0;
    int triggerCaillou = 0;
   



    // Start is called before the first frame update
    void Start()
    {
        EncensIsTriggerOrNot = false;
        EncensIsTurnOnOrNot = false;
        FillOrNot = false;

        

    }

    // Update is called once per frame
    void Update()
    {
        if (trigger >0  && Input.GetKeyDown("space"))
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

        if (trigger>0)
        {
            EncensIsTriggerOrNot = true;
        }

        if (trigger < 0)
        {
            EncensIsTriggerOrNot = false;
        }


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

        if (Input.GetKeyDown("p"))
        {
            SparkOrNot = !SparkOrNot;
        }

        if (triggerCaillou > 0 && FillOrNot == true)
        {
            SparkOrNot = true;
            Instantiate(vfxSparx);
        }

        if (triggerCaillou < 0 && FillOrNot == false)
        {
            SparkOrNot = false;
            Destroy(vfxSparx);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Hand")
        {
            trigger ++;
            encens.GetComponent<Renderer>().material = newMaterialTrigger;
            Debug.Log("IsTrigger dans la manette!");
        }

        if (other.gameObject.tag == "Caillou")
        {
            triggerCaillou++;
            Debug.Log("IsTrigger dans le caillou!");
        }


    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Hand")
        {
            trigger --;
            encens.GetComponent<Renderer>().material = defaultMaterial;
        }

        if (other.gameObject.tag == "Caillou")
        {
            triggerCaillou--;
            
        }
        
    }



}
