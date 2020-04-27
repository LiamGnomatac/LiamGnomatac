using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChienScript : MonoBehaviour
{

    private float chienTimer = 0.0f;
    public GameObject joueur;
    public bool joueurSurZone = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(joueurSurZone == false)
        {
            Debug.Log("Joueur pas sur zone");
            chienTimer += Time.deltaTime;
        }

        if(chienTimer >= 5.0f)
        {
            KillingDog();
            
        }

    }



    public void KillingDog()
    {
        Debug.Log("Joueur tué par le chien");
    }

}
