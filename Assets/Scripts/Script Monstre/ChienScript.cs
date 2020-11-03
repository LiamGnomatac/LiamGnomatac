using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChienScript : MonoBehaviour
{
    #region Variable

    public Animator animator;
    public GameObject mesh;
    public float chienTimerAttaque = 5.0f;

    public StoryElementMonologue monologue;
    public bool joueurSurZone = false;
    public bool chienCanTP = true;
    public GameObject zone1;
    public GameObject zone2;
    public GameObject zone3;
    private bool thereIsLight;
    public bool dogCanAttackOnLight = false;
    private bool chienAttack;
    
    #endregion

    #region Singleton
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

    #endregion

    // Start is called before the first frame update
    void Start()
    {
        mesh.SetActive(false);
        ChienTP();
    }

    // Update is called once per frame
    void Update()
    {
        if (TPPerso.s_Singleton)
        { 
            transform.LookAt(TPPerso.s_Singleton.cameraVR.transform.position); 
        }
    }

    private void FixedUpdate()
    {
        if (GameManager.s_Singleton.objKeyLaunch >= 3)
        {
            GameManager.s_Singleton.objKeyLaunch = 0;
            ScreamerManager.s_Singleton.KillingDog();
        }
        if(TPPerso.s_Singleton.torchLight|| TPPerso.s_Singleton.cellphone)
        {
            if ((dogCanAttackOnLight && TPPerso.s_Singleton.torchLight.activeSelf == true) || (dogCanAttackOnLight && TPPerso.s_Singleton.cellphone.activeSelf == true))
            {
                thereIsLight = true;
                chienAttack = true;
                ChienAttackOnLight();
            }
            else
            {
                thereIsLight = false;
                CancelDogAttack();
            }
        }
    }

    public void ChienAttackOnLight()
    {
        if (thereIsLight && chienAttack)
        {
            chienAttack = false;
            Invoke("DogAttack", chienTimerAttaque);
            animator.SetBool("isAttack", true);
        }
    }

    private void DogAttack()
    {
        ScreamerManager.s_Singleton.KillingDog();
    }

    public void PlayerOutZone()
    {
        if (!joueurSurZone)
        {
            FindObjectOfType<AudioManager>().Play("Doggo_Grogne");
            Invoke("DogAttack", chienTimerAttaque);
            animator.SetBool("isAttack", true);
        }
    }

    public void CancelDogAttack()
    {
        if (joueurSurZone && !thereIsLight)
        {
            Debug.Log("cancel");
            CancelInvoke("DogAttack");
            animator.SetBool("isAttack", false);
        }
    }

    public void ChienTP()
    {
        Debug.Log("Chien choisi une zone");

        int zoneChoisie = Random.Range(0, 3);

        switch (zoneChoisie)
        {
            case 0:
                Debug.Log(zoneChoisie);
                gameObject.transform.position = zone1.transform.position;
                chienCanTP = false;
                mesh.SetActive(true);
                break;
            case 1:
                Debug.Log(zoneChoisie);
                gameObject.transform.position = zone2.transform.position;
                chienCanTP = false;
                mesh.SetActive(true);
                break;

            case 2:
                Debug.Log(zoneChoisie);
                gameObject.transform.position = zone3.transform.position;
                chienCanTP = false;
                mesh.SetActive(true);
                break;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == 10 || other.name == "LightTrigger")
        {
            if (monologue)
            {
                monologue.TriggerMonologue();
                Destroy(monologue.gameObject);
            }
        }
    }
}
