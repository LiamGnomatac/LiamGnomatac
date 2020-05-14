using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class TaureauRemonteScript : MonoBehaviour
{
    private NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        agent.destination = TPPerso.s_Singleton.cameraVR.transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Joueur"))
        {

            KillingTaureau();

        }
    }



    public void KillingTaureau()
    {
        Debug.Log("Joueur tué par le taureau");

        SceneManagement.s_Singleton.GetKilled();
    }

}
