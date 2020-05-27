using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class PierreAFeuCS : MonoBehaviour
{
    public LayerMask thisLayer;
    private bool isPlayer = false;
    private int collisionNumber;
    public int NumberTimeToFall;
    public GameObject vfxSpark;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public int NumberTimeCollision()
    {
        return collisionNumber;
    }

    private void Spark()
    {
        if (GetComponent<Interactable>().GetIsGrab())
        {
            collisionNumber++;
            Instantiate(vfxSpark, transform.position, Quaternion.identity);
        }
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Etincelle"))
        {
            Spark();
        }
        if (collisionNumber >= NumberTimeToFall)
        {
            Destroy(GetComponent<Throwable>());
            collisionNumber = 0;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.GetComponentInParent<HandPhysics>())
        {
            isPlayer = true;
            Debug.Log(isPlayer);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if(!gameObject.GetComponent<Throwable>())
        {
            gameObject.AddComponent<Throwable>();
        }
        if (collision.gameObject.GetComponent<HandPhysics>())
        {
            isPlayer = false;
        }
    }

}
