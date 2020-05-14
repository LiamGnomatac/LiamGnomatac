using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class TaureauScript : MonoBehaviour
{

    private float vitesse = 1.2f;
    private NavMeshAgent agent;
    public Transform destination;
    public bool isRunning;
    private bool canMove;
    private GameObject taureau;
    public bool isStun;
    public float timerStun = 30f;
    private bool goToEncens;
    public Transform bruit;
    private Vector3 posDestination;
    

    #region Singleton
    public static TaureauScript s_Singleton;


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

        GetComponent<NavMeshAgent>().speed = vitesse;
        agent = GetComponent<NavMeshAgent>();
        taureau = gameObject;
    }

    // Update is called once per frame
    void Update()
    {

        agent.destination = posDestination;

        
    

        if(isStun == true)
        {

            timerStun -= Time.deltaTime;


        }

       
        
    }


    private void FixedUpdate()
    {
        
        if (timerStun <= 0)
        {
            isStun = false;
            taureau.GetComponent<NavMeshAgent>().enabled = true;

        }

        
    }

    public void SetDestination()
    {

        posDestination = bruit.position;
        isRunning = true;
        vitesse = 3f;


    }


    public void TaureauGoToEncens()
    {
        if (EncensManager.s_Singleton.direction() == null)
        {


            Vector3 stay = transform.position;
            posDestination = stay;


        }
        else
        {

            posDestination = EncensManager.s_Singleton.direction();

        }
       


    }

    private void OnTriggerEnter(Collider other)
    {
        if(isRunning == true)
        {

            TaureauStun();

        }


        if (other.CompareTag("Player"))
        {

            KillingTaureau();
        }

    }

    public void TaureauStun()
    {

        taureau.GetComponent<NavMeshAgent>().enabled = false;
        timerStun = 30f;
        isStun = true;
        isRunning = false;
        vitesse = 1.2f;
    }


    public void KillingTaureau()
    {
        Debug.Log("Joueur tué par le taureau");      
        SceneManagement.s_Singleton.GetKilled();

    }

}
