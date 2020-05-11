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





        if(GetComponent<EncensCS>().isTurnOn)
        {

            TaureauGoToEncens();

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

        taureau.GetComponent<NavMeshAgent>() = false;

    }
}
