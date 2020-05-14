using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BruitManager : MonoBehaviour
{

    public GameObject bruit;
    public bool thereIsSound;

    public static BruitManager s_Singleton;

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
        bruit.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
       if (!other.CompareTag("Player") || !other.CompareTag("Monstre"))
        {
            if (thereIsSound == false)
            {
                bruit.SetActive(true);
                bruit.transform.position = other.transform.position;
                thereIsSound = true;
                //TaureauScript.s_Singleton.SetDestination();

            }
           
        }
    }

}
