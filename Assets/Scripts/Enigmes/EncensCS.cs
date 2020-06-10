﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EncensCS : MonoBehaviour
{
    public bool isTurnOn;
    public bool isFilled;
    public float stayOnTimer = 0;
    public GameObject oil;
    public GameObject vfxFlame;
    public GameObject pointLight;

    private bool isStayOn;
    private float lightIntensity;
    
    // Start is called before the first frame update
    void Start()
    {
        StayOn();
        pointLight.SetActive(false);
        lightIntensity = pointLight.GetComponent<Light>().intensity;
        StartTurnOn();
        StartFilled();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!isStayOn || GetComponentInChildren<Light>() == null)
        {
            return;
        }
        else if (isStayOn && GetComponentInChildren<Light>().enabled)
        {
            Debug.Log("va s'eteindre");
            Invoke("TurnOffWithTime", stayOnTimer);
        }
    }

    public void FilledWithOil()
    {
        isFilled = true;
        oil.SetActive(true);
        Debug.Log("GlouGlouGlou");
    }

    private void StartFilled()
    {
        if(isFilled)
        {
            FilledWithOil();
        }
    }

    private void StartTurnOn()
    {
        if(isTurnOn)
        {
            FilledWithOil();
            TurnOn();
        }
    }

    public void TurnOn()
    {
        if(isFilled)
        {
            Debug.Log("Flamme");
            isTurnOn = true;
            pointLight.SetActive(true);
            pointLight.GetComponent<Light>().intensity = lightIntensity;
            Instantiate(vfxFlame, pointLight.transform);
            TaureauScript.s_Singleton.UpdateDestination();
        }
    }

    public void TurnOff()
    {
        Debug.Log("Plus de Flamme");
        isTurnOn = false;
        pointLight.SetActive(false);
        TaureauScript.s_Singleton.UpdateDestination();
        if (pointLight.GetComponentInChildren<ParticleSystem>().gameObject)
        {
            Destroy(pointLight.GetComponentInChildren<ParticleSystem>().gameObject);
        }
    }

    private void RandTurnOn()
    {
        Debug.Log("clong");
        if(!isTurnOn)
        {
            int rand = Random.Range(0, 3);
            if (rand != 0)
            {
                return;
            }
            else
            {
                TurnOn();
            }
        }
        
    }

    private void TurnOffWithTime()
    {
        pointLight.GetComponent<Light>().intensity -= 0.05f;
        if(pointLight.GetComponent<Light>().intensity <= 0)
        {
            TurnOff();
        }
        if (GetComponent<StoryElementMonologue>())
        {
            GetComponent<StoryElementMonologue>().TriggerMonologue();
            Destroy(GetComponent<StoryElementMonologue>());
        }
    }

    private void StayOn()
    {
        if(stayOnTimer != 0)
        {
            isStayOn = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<PierreAFeuCS>())
        {
            if (isFilled)
            {
                if (other.gameObject.GetComponent<PierreAFeuCS>().NumberTimeCollision() >= 1)
                {
                    RandTurnOn();
                }
            }

        }
        if (other.CompareTag("Monstre"))
        {

            TurnOff();
            EncensManager.s_Singleton.thereIsLight = false;

        }
    }
}
