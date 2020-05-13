using System.Collections;
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
        lightIntensity = pointLight.GetComponent<Light>().intensity;
        StartTurnOn();
        StayOn();
        StartFilled();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!isStayOn)
        {
            return;
        }
        else if (isStayOn && GetComponentInChildren<Light>())
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

    private void TurnOn()
    {
        if(isFilled)
        {
            Debug.Log("Flamme");
            isTurnOn = true;
            pointLight.SetActive(true);
            pointLight.GetComponent<Light>().intensity = lightIntensity;
            Instantiate(vfxFlame, pointLight.transform);
        }
    }

    public void TurnOff()
    {
        Debug.Log("Plus de Flamme");
        isTurnOn = false;
        pointLight.SetActive(false);
        Destroy(pointLight.GetComponentInChildren<ParticleSystem>().gameObject);
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
    }

    private void StayOn()
    {
        if(stayOnTimer != 0)
        {
            isStayOn = true;
        }
    }

    private void OnTriggerStay(Collider other)
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
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other == TaureauScript.s_Singleton)
        {
            TurnOff();
            EncensManager.s_Singleton.thereIsLight = false;
            EncensManager.s_Singleton.encensCheck.SetActive(false);
        }
    }


}
