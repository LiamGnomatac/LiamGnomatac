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
    private Animator anim;
    

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
        anim = GetComponentInChildren<Animator>();
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
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        if (EncensManager.s_Singleton.direction() != Vector3.zero)
        {
            agent.destination = EncensManager.s_Singleton.direction();
            anim.SetBool("isWalking", true);
        }
        else
        {
            agent.isStopped = true;
            anim.SetBool("isWalking", false);
        }
    }

    public void SetDestination(Vector3 bruit)
    {
        agent.speed = maxSpeed;
        agent.ResetPath();
        agent.destination = bruit;
        isRunning = true;
        anim.SetBool("isRunning", true);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (isRunning == true && collision.gameObject.layer == 9)
        {
            TaureauStun();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
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
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationY;
        Invoke("UpdateDestination", timerStun);
        anim.SetBool("isWalking", false);
        anim.SetBool("isRunning", false);
    }

    public void KillingTaureau()
    {
        Debug.Log("Joueur tué par le taureau");      
        SceneManagement.s_Singleton.GetKilled();
    }
}