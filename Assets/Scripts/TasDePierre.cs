using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TasDePierre : MonoBehaviour
{
    int triggerManette = 0;
    public GameObject TasDePierres;
    public GameObject PierreALancer;
    public Material defaultMaterial;
    public Material newMaterialTrigger;
    public bool TasDePierresIsTriggerOrNot;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (triggerManette > 0)
        {
            TasDePierresIsTriggerOrNot = true;
        }

        if (triggerManette <= 0)
        {
            TasDePierresIsTriggerOrNot = false;
        }

        if (triggerManette > 0 && Input.GetKeyDown("s"))
        {
            Instantiate(PierreALancer);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Hand")
        {
            triggerManette++;
            TasDePierres.GetComponent<Renderer>().material = newMaterialTrigger;
            Debug.Log("IsTrigger dans la manette!");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Hand")
        {
            triggerManette--;
            TasDePierres.GetComponent<Renderer>().material = defaultMaterial;
        }
    }

    }
