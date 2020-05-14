using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class TaureauScript : MonoBehaviour
{

    public float minSpeed = 1.2f;
    public float maxSpeed = 3;
    private NavMeshAgent agent;
    public bool isRunning;
    public bool isStun;
    public float timerStun = 30f;
    

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
        agent = GetComponent<NavMeshAgent>();
        agent.speed = minSpeed;
    }

    // Update is called once per frame
    void Update()
    {
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
            agent.enabled = true;
        }
    }

    public void UpdateDestination()
    {
        if (EncensManager.s_Singleton.direction() != Vector3.zero)
        {
            agent.destination = EncensManager.s_Singleton.direction();
        }
        else
        {
            agent.isStopped = true;
        }
    }

    public void SetDestination(Vector3 bruit)
    {
        agent.destination = bruit;
        isRunning = true;
        agent.speed = maxSpeed;
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
        agent.enabled = false;
        timerStun = 30f;
        isStun = true;
        isRunning = false;
        agent.speed = minSpeed;
    }


    public void KillingTaureau()
    {
        Debug.Log("Joueur tué par le taureau");      
        SceneManagement.s_Singleton.GetKilled();
    }

}
