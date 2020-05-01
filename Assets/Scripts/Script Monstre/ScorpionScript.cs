using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScorpionScript : MonoBehaviour
{

    public GameObject zone1;
    public GameObject zone2;
    public GameObject zone3;
    public float compteurMur = 8f;
    public float compteurPlafond = 15f;
    public float timerNextTP = 20f;
    public bool scorpionMove = false;
    public bool scorpionMur = false;
    public bool scorpionHitFlash = false;
    public bool scorpionPlafond = false;



    // Start is called before the first frame update
    void Start()
    {
        ScorpionMove();
    }

    // Update is called once per frame
    void Update()
    {
        if(scorpionMove == true)
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
            KillingScorpion();
        }

    }

    public void ScorpionTP()
    {


        int zoneChoisie = Random.Range(0, 3);

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

                gameObject.transform.position = zone3.transform.position;
                ScorpionPlaflond();


                break;
        }
    }

    public void ScorpionMove()
    {
        gameObject.GetComponent<MeshRenderer>().enabled = false;
        int tempsSup = Random.Range(0, 21);
        timerNextTP = 20 + tempsSup;
        scorpionMove = true;
        Debug.Log("Le scorpion se déplace");



    }

    public void ScorpionMur()
    {
        gameObject.GetComponent<MeshRenderer>().enabled = true;
        compteurMur = 8f;
        scorpionMur = true;
        Debug.Log("Le scorpion est dans un mur");

    }

    public void ScorpionPlaflond()
    {
        gameObject.GetComponent<MeshRenderer>().enabled = true;
        compteurPlafond = 15f;
        scorpionPlafond = true;
        Debug.Log("Le scorpion est dans une cavité au plafond");

    }

    public void KillingScorpion()
    {
        Debug.Log("Joueur tué par le scorpion");
        
        SceneManagement.s_Singleton.GetKilled();
    }

}
