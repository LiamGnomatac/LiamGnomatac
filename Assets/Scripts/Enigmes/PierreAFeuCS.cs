using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class PierreAFeuCS : MonoBehaviour
{
    private bool isPlayer;
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

    
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 8 )
        {
            if(isPlayer)
            {
                collisionNumber++;
                Instantiate(vfxSpark, transform.position, Quaternion.identity);
            }
        }
        if (collisionNumber >= NumberTimeToFall)
        {
            Destroy(GetComponent<Throwable>());
            collisionNumber = 0;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.GetComponent<HandPhysics>())
        {
            isPlayer = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if(!gameObject.GetComponent<Throwable>())
        {
            gameObject.AddComponent<Throwable>();
        }
    }

}
