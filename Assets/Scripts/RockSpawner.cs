using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

 public class RockSpawner : MonoBehaviour
 {
    public GameObject rock;

    private GameObject InvokeRock()
    {
        GameObject newrock = Instantiate(rock, transform.position, Quaternion.identity);
        return newrock;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Hand>())
        {
            Debug.Log("normalement ça marche");
            other.gameObject.GetComponent<HandAttach>().SetAttachObj(InvokeRock());
        }
    }

    /*private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Hand>())
        {
            Debug.Log("normalement ça marche");
            collision.gameObject.GetComponent<HandAttach>().SetAttachObj(InvokeRock());
        }
    }*/
}
