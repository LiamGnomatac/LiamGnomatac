using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreamerManager : MonoBehaviour
{
    public float timeBeforeGoToDeathSceen = 2.5f;
    public GameObject chien;
    public GameObject scorpion;
    public GameObject taureau;
    public static ScreamerManager s_Singleton;

    private void Awake()
    {
        if (s_Singleton != null)
        {
            Destroy(gameObject);
        }
        else
        {
            s_Singleton = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void KillingDog()
    {
        //Invoke("InvokeGetKilled", timeBeforeGoToDeathSceen);
        Debug.Log("Joueur tué par le chien");
        chien.SetActive(true);
    }

    public void KillingScorpion()
    {
        //Invoke("InvokeGetKilled", timeBeforeGoToDeathSceen);
        Debug.Log("Joueur tué par le scorpion");
        scorpion.SetActive(true);
    }

    public void KillingTaureau()
    {
        //Invoke("InvokeGetKilled", timeBeforeGoToDeathSceen);
        Debug.Log("Joueur tué par le taureau");
        taureau.SetActive(true);
    }

    private void InvokeGetKilled()
    {
        SceneManagement.s_Singleton.GetKilled();
    }
}



