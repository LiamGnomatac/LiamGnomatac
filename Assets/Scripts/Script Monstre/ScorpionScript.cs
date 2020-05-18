using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScorpionScript : MonoBehaviour
{
    public GameObject mesh;
    public GameObject zone1;
    public GameObject zone2;
    public GameObject zone3;
    public GameObject zone4;
    public GameObject zone5;
    public float compteurMur = 8f;
    public float compteurPlafond = 15f;
    public float timerNextTP = 20f;
    public bool scorpionMove = false;
    public bool scorpionMur = false;
    public bool scorpionHitFlash = false;
    public bool scorpionPlafond = false;
    
    public Collider joueur;



    // Start is called before the first frame update
    void Start()
    {
        ScorpionMove();
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(TPPerso.s_Singleton.cameraVR.transform.position);

        if (scorpionMove == true)
        {

            timerNextTP -= Time.deltaTime;
           
        }

       if (scorpionPlafond == true)
        {
            compteurPlafond -= Time.deltaTime;
            
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

        if (compteurPlafond <= 0 && scorpionPlafond == true)
        {
            scorpionPlafond = false;
            ScorpionMove();
        }

        if(compteurMur <= 0)
        {
            ScreamerManager.s_Singleton.KillingScorpion();
            ScorpionMove();
        }

    }

    public void ScorpionTP()
    {


        int zoneChoisie = Random.Range(0, 4);

        switch (zoneChoisie)
        {
            case 0:

                gameObject.transform.position = zone1.transform.position;
                ScorpionMur();
                


                break;
            case 1:

                gameObject.transform.position = zone2.transform.position;
                ScorpionMur();


                break;

            case 2:

                if (SceneManagement.s_Singleton.niveau4)
                {
                    ScorpionTP();
                }
                else
                {
                    gameObject.transform.position = zone3.transform.position;
                    ScorpionPlaflond();
                }


                break;

            case 3:

                if (SceneManagement.s_Singleton.niveau4)
                {
                    gameObject.transform.position = zone3.transform.position;
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
        mesh.SetActive(false);
        int tempsSup = Random.Range(0, 21);
        timerNextTP = 20 + tempsSup;
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

    public void ScorpionPlaflond()
    {
        mesh.SetActive(true);
        compteurPlafond = 15f;
        scorpionPlafond = true;
        Debug.Log("Le scorpion est dans une cavité au plafond");

    }


    private void OnTriggerEnter(Collider other)
    {
        if(other == LampeTorche.s_Singleton.lightTrigger)
        {
            scorpionHitFlash = true;
        }

        if (other == Téléphone.s_Singleton.lightTrigger)
        {
            scorpionHitFlash = true;
        }

        if (other.CompareTag("Joueur"))
        {

            ScreamerManager.s_Singleton.KillingScorpion();

        }
        
    }


    

}
