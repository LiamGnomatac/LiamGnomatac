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

    private void FixedUpdate()
    {
        if (GameManager.s_Singleton.objKeyLaunch >= 3)
        {
            GameManager.s_Singleton.objKeyLaunch = 0;
            KillingDog();
        }
    }



    public void KillingDog()
    {
        Debug.Log("Joueur tué par le chien");
        SceneManagement.s_Singleton.GetKilled();
    }

}
