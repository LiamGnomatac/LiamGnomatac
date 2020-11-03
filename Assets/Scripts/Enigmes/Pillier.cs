using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pillier : MonoBehaviour
{
    public GameObject taurus;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject == taurus)
        {
            Debug.Log(collision.gameObject.name);
        }
        GetComponentInParent<PillierManager>().DestroyPillar(taurus, gameObject);
    }
}