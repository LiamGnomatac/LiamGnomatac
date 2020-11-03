using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScorpionScript : MonoBehaviour
{
    public GameObject mesh;
    public Transform zone1;
    public Transform zone2;
    public Transform zone3;
    public float compteurMur = 8f;
    
    public float timerNextTP = 20f;
    public bool scorpionMove = false;
    public bool scorpionMur = false;
    public bool scorpionHitFlash = false;
    // Start is called before the first frame update
    void Start()
    {
        ScorpionMove();
    }

    // Update is called once per frame
    void Update()
    {
        if (TPPerso.s_Singleton)
        {
            transform.LookAt(TPPerso.s_Singleton.cameraVR.transform.position);
        }

        if (scorpionMove == true)
        {
            timerNextTP -= Time.deltaTime;
        }

       if(scorpionMur == true)
        {

            compteurMur -= Time.deltaTime;
            

        }

       if (scorpionHitFlash == true && scorpionMur == true)
        {

            scorpionMur = false;
            scorpionHitFlash = false;
            Debug.Log("Le scorpion a fui");
            ScorpionMove();

        }

    }

    private void FixedUpdate()
    {
        if (timerNextTP <= 0 && scorpionMove == true)
        {
            scorpionMove = false;
            ScorpionTP();
        }

        

        if(compteurMur <= 0)
        {
            if(SceneManagement.s_Singleton)
            {
                ScreamerManager.s_Singleton.KillingScorpion();
                ScorpionMove();
            }
        }
    }

    public void ScorpionTP()
    {
        Debug.Log("je tp");

        int zoneChoisie = Random.Range(0, 3);
        
        switch (zoneChoisie)
        {
            case 0:
                Debug.Log("je zone1");
                gameObject.transform.position = zone1.position;
                ScorpionMur();
                


                break;
            case 1:
                Debug.Log("je zone2");
                gameObject.transform.position = zone2.position;
                ScorpionMur();


                break;

       
            case 2:
                Debug.Log("je pas fini");
                if (SceneManagement.s_Singleton.niveau4)
                {
                    gameObject.transform.position = zone3.position;
                    ScorpionMur();
                }
                else
                {
                    ScorpionTP();
                }
                break;
        }
    }

    public void ScorpionMove()
    {
        Debug.Log("je bouge");
        mesh.SetActive(false);
        int tempsSup = Random.Range(0, 21);
        timerNextTP = 30 + tempsSup;
        scorpionHitFlash = false;
        scorpionMove = true;
        Debug.Log("Le scorpion se déplace");



    }

    public void ScorpionMur()
    {
        mesh.SetActive(true);
        compteurMur = 12f;
        scorpionMur = true;
        Debug.Log("Le scorpion est dans un mur");

    }

   

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("scorpion collide with"+other);
        Debug.Log("trigger ok");
        if (other.gameObject.layer == 10 || other.name == "LightTrigger")
        {
            Debug.Log("Hello light");
            scorpionHitFlash = true;
            if (GetComponent<StoryElementMonologue>())
            {
                GetComponent<StoryElementMonologue>().TriggerMonologue();
                Destroy(GetComponent<StoryElementMonologue>());
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("scorpion collide with" + collision);
        Debug.Log("collision ok");
        if (collision.gameObject.layer == 10)
        {
            Debug.Log("Hello light");
            scorpionHitFlash = true;
            if (GetComponent<StoryElementMonologue>())
            {
                GetComponent<StoryElementMonologue>().TriggerMonologue();
                Destroy(GetComponent<StoryElementMonologue>());
            }
        }
    }
}
