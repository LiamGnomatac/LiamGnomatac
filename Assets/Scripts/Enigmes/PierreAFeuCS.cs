using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class PierreAFeuCS : MonoBehaviour
{
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
        Debug.Log(collisionNumber);
    }

    public int NumberTimeCollision()
    {
        return collisionNumber;
    }

    
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.layer == 8 && gameObject.tag == "Player")
        {
            Debug.Log("Tappe un autre silex");
            collisionNumber++;
            Instantiate(vfxSpark, transform.position, Quaternion.identity);
        }
        if (collisionNumber >= NumberTimeToFall)
        {
            Debug.Log("tombe");
            Destroy(GetComponent<Throwable>());
            collisionNumber = 0;
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
