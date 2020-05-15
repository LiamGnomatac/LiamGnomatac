using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChienScript : MonoBehaviour
{

    private float chienTimerOutZone = 5f;
    private float chienTimerAttaque = 5.0f;
    public float chienTimerTp = 0.0f;
    public float chienTPAt = 3.0f;
    public bool joueurSurZone = false;
    public bool chienCanTP = false;
    public bool chienShouldTP = false;
    public bool canCount = true;
    public GameObject zone1;
    public GameObject zone2;
    public GameObject zone3;
    public GameObject dogTorchLight;
    public GameObject dogPhoneLight;
    public bool thereIsLight;
    public bool dogCanAttackOnLight;
    public bool chienAttack;

    public static ChienScript s_Singleton;

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
        gameObject.GetComponent<MeshRenderer>().enabled = false;
        chienCanTP = false;
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(TPPerso.s_Singleton.cameraVR.transform.position);
        if (canCount == true)
        {
            chienTimerTp += Time.deltaTime;
        }

        if (chienTimerTp >= chienTPAt)
        {
            canCount = false;
            chienTimerTp = 0;
            chienShouldTP = true;
            
        }

        if (chienTimerAttaque <= 0.0f || chienTimerOutZone <= 0f)
        {
            KillingDog();

        }

      if (chienAttack == true)
        {
            chienTimerAttaque -= Time.deltaTime;

        }

    }

    private void FixedUpdate()
    {
        if (GameManager.s_Singleton.objKeyLaunch >= 3)
        {
            GameManager.s_Singleton.objKeyLaunch = 0;
            KillingDog();
        }

        if (chienShouldTP == true)
        {
            chienShouldTP = false;
            ChienTP();
        }

       if(dogPhoneLight.activeSelf == true || dogTorchLight.activeSelf == true)
        {

            thereIsLight = true;

        }

        else
        {

            thereIsLight = false;

        }



        if (joueurSurZone == false)
        {

            chienTimerOutZone -= Time.deltaTime;
        }
        else
        {

            chienTimerOutZone = 5f;

        }


        if (dogCanAttackOnLight == true && thereIsLight == true)
        {

            chienAttack = true;

        }
        else
        {
            chienAttack = false;
            chienTimerAttaque = 5f;
        }




    }

 

    public void KillingDog()
    {
        Debug.Log("Joueur tué par le chien");
        chienAttack = false;
        chienTimerAttaque = 5;
        chienTimerOutZone = 5;
        SceneManagement.s_Singleton.GetKilled();
    }

    public void OnBecameVisible()
    {
        chienCanTP = true;
    }

    public void OnBecameInvisible()
    {
        if (chienCanTP == true)
        {
            gameObject.GetComponent<MeshRenderer>().enabled = false;
            canCount = true;

        }
       

    }
    


    public void ChienTP()
    {
        
        
        int zoneChoisie = Random.Range(0, 3);

        switch (zoneChoisie)
        {
            case 0:

                gameObject.transform.position = zone1.transform.position;
                chienCanTP = false;
                gameObject.GetComponent<MeshRenderer>().enabled = true;


                break;
            case 1:

                gameObject.transform.position = zone2.transform.position;
                chienCanTP = false;
                gameObject.GetComponent<MeshRenderer>().enabled = true;

                break;

            case 2:

                gameObject.transform.position = zone3.transform.position;
                chienCanTP = false;
                gameObject.GetComponent<MeshRenderer>().enabled = true;

                break;
        }
    }

}
