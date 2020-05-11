using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class TaureauScript : MonoBehaviour
{

    public float vitesse = 1f;
    private NavMeshAgent agent;
    private Transform destination;

    

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
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




    }




}
