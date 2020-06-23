using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class TaureauScript : MonoBehaviour
{
    public float stunDuration = 30;
    public float minSpeed = 1.2f;
    public float maxSpeed = 3;
    private NavMeshAgent agent;
    public bool isRunning = false;
    private bool isStun = false;
    private bool hasDestination = false;
    private float timerStun;
    private Animator anim;
    private Vector3 taurusPositionOnGround;
    private Vector3 rockDirection;
    private RaycastHit hit;
    private NavMeshHit navMeshHit;

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
        /*if(isStun == true)
        {
            timerStun -= Time.deltaTime;
        }*/
        if(hasDestination)
        {
            if (NavMesh.FindClosestEdge(rockDirection,out navMeshHit, NavMesh.AllAreas))
            {
                //Debug.Log(navMeshHit.position);
                SetDestination(navMeshHit.position);
                hasDestination = false;
            }
        }
    }


    private void FixedUpdate()
    {
        /*if (timerStun <= 0 )
        {
            isStun = false;
            agent.isStopped = false;
        }*/
    }

    public void UpdateDestination()
    {
        isStun = false;
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        if (EncensManager.s_Singleton.direction() != Vector3.zero)
        {
            agent.destination = EncensManager.s_Singleton.direction();
            anim.SetBool("isWalking", true);
            anim.SetBool("isDeath", false);
        }
        else
        {
            agent.isStopped = true;
            anim.SetBool("isWalking", false);
            anim.SetBool("isDeath", false);
        }
    }
    public void GetRockPosition(Vector3 rock)
    {
        if(!isStun)
        {
            isRunning = true;
            taurusPositionOnGround.x = transform.position.x;
            taurusPositionOnGround.z = transform.position.z;
            rockDirection = rock /*- taurusPositionOnGround*/;
            hasDestination = true;
            anim.SetBool("isRunning", true);
            anim.SetBool("isDeath", false);
        }
    }
    
    private void SetDestination(Vector3 bruit)
    {
        agent.speed = maxSpeed;
        agent.ResetPath();
        agent.destination = bruit;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("collide with " + collision);
        if (isRunning == true && collision.gameObject.layer == 9)
        {
            Debug.Log("stun");
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
        Debug.Log("stun");
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
        anim.SetBool("isDeath", false);
    }

    public void KillingTaureau()
    {
        Debug.Log("Joueur tué par le taureau");      
        SceneManagement.s_Singleton.GetKilled();
    }
}