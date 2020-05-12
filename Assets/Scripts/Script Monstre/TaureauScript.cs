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
    public bool stopMoving;
    private bool canMove;
    private GameObject taureau;
    public bool isStun;
    public float timerStun = 30f;
    private bool goToEncens;
    public Transform bruit;

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

    // Start is called before the first frame update
    void Start()
    {

        vitesse = GetComponent<NavMeshAgent>().speed;
        canMove = true;
        agent = GetComponent<NavMeshAgent>();
        taureau = gameObject;
    }

    // Update is called once per frame
    void Update()
    {

        agent.destination = destination.position;

        
    

        if(isStun == true)
        {

            timerStun -= Time.deltaTime;


        }


        if(GetComponent<EncensCS>().isTurnOn && isRunning == false)
        {
            GetComponent<EncensCS>().transform.position = destination.position;
            goToEncens = true;

        }
    }


    private void FixedUpdate()
    {
        
        if (timerStun <= 0)
        {
            isStun = false;
            taureau.GetComponent<NavMeshAgent>().enabled = true;

        }

        if (isRunning == true)
        {

            vitesse = 3;
        }
       else
        {

            vitesse = 1.2f;
        }
    }

    public void SetDestination()
    {

        destination.position = bruit.position;
        isRunning = true;


    }


    public void TaureauGoToEncens()
    {

        GetComponent<EncensCS>().TurnOff();


    }

    private void OnTriggerEnter(Collider other)
    {
        if(isRunning == true)
        {

            TaureauStun();

        }


    }

    public void TaureauStun()
    {

        taureau.GetComponent<NavMeshAgent>().enabled = false;
        timerStun = 30f;
        isStun = true;
        isRunning = false;

    }


    public void KillingTaureau()
    {
        Debug.Log("Joueur tué par le taureau");      
        SceneManagement.s_Singleton.GetKilled();

    }

}
