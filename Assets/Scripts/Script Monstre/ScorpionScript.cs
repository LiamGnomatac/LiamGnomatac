using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScorpionScript : MonoBehaviour
{

    public GameObject zone1;
    public GameObject zone2;
    public GameObject zone3;




    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ScorpionTP()
    {


        int zoneChoisie = Random.Range(0, 3);

        switch (zoneChoisie)
        {
            case 0:

                gameObject.transform.position = zone1.transform.position;
                
                


                break;
            case 1:

                gameObject.transform.position = zone2.transform.position;
                
             

                break;

            case 2:

                gameObject.transform.position = zone3.transform.position;
               
                

                break;
        }
    }
}
