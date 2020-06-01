using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class TaureauScript : MonoBehaviour
{

    public float minSpeed = 1.2f;
    public float maxSpeed = 3;
    private NavMeshAgent agent;
    public bool isRunning = false;
    public bool isStun = false;
    public float stunDuration = 30;
    private float timerStun;
    

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
        timerStun = stunDuration;
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
        if (timerStun <= 0 )
        {
            isStun = false;
            agent.isStopped = false;
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
        agent.speed = maxSpeed;
        agent.ResetPath();
        agent.destination = bruit;
        isRunning = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(isRunning == true && other.gameObject.layer == 9)
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
        agent.isStopped = true;
        agent.ResetPath();
        timerStun = stunDuration;
        isStun = true;
        isRunning = false;
        agent.speed = minSpeed;
        //Invoke("UpdateDestination", timerStun);
    }


    public void KillingTaureau()
    {
        Debug.Log("Joueur tué par le taureau");      
        SceneManagement.s_Singleton.GetKilled();
    }

}
