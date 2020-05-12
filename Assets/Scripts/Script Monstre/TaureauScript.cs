using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class TaureauScript : MonoBehaviour
{

    public float vitesse = 1f;
    private NavMeshAgent agent;
    public Transform destination;
    public bool isRunning;
    public bool isWalking;
    public bool stopMoving;
    private bool canMove;
    private GameObject taureau;
    public bool isStun;
    public float timerStun;

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


        if(GetComponent<EncensCS>().isTurnOn)
        {

            TaureauGoToEncens();

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

    public void SetDestination(Transform bruit)
    {

        destination = bruit;


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

    }
}
