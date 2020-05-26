using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeNoise : MonoBehaviour
{
    public bool justOneHit = false;
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
        if(collision.gameObject.tag == "Player")
        {
            justOneHit = true;
        }
        if(collision.gameObject.layer == 9 && justOneHit)
        {
            Debug.Log("bruit");
            Vector3 pos = transform.position;
            TaureauScript.s_Singleton.SetDestination(pos);
            justOneHit = false;
        }
    }


}
