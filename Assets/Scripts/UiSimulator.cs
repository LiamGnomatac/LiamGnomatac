using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using Valve.VR.InteractionSystem;



public class UiSimulator : MonoBehaviour
{
    public GameObject Joueur;

    public GameObject UiDeLaMort;
    public GameObject UiDeLaPause;
    public GameObject UiDeLesOptions;
    public GameObject UiDeLesSousTitres;
    public GameObject Pointer;
    public GameObject VRInputModule;

    public Button BoutonMortOui;
    public Button BoutonMortNon;
    public Button BoutonMortQuitter;

    public Button BoutonPauseReprendre;
    public Button BoutonPauseNon;
    public Button BoutonPauseQuitter;

    public Button BoutonOptionsVolume;
    public Button BoutonOptionsPlus;
    public Button BoutonOptionsMoins;
    public Button BoutonOptionsSousTitres;
    public Button BoutonOptionsOui;
    public Button BoutonOptionsNon;
    public Button BoutonOptionsRetour;


    public bool mort;

    public AudioMixer audioMixer;

    private int RetourALaScenePrecedente;

    public void EffetDesBoutonsRelancerLaSceneActive()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void EffetDesBoutonsRetournerALaSceneOuOnEstMort()
    {
        //  /!\  Dans les builds settings, il faut alterner entre les scenes de jeu et la scene de mort 
        //(ex:BureauAsset(0), Niveau1(1), Death Scene(2), Niveau 2(3), Death Scene(4), ect...)
        RetourALaScenePrecedente = SceneManager.GetActiveScene().buildIndex -1;
    }

    public void EffetDesBoutonsAllerAuBureau()
    {
        SceneManager.LoadScene("BureauAsset");
    }

    public void EffetDesBoutonsQuitterLeJeu()
    {
        Application.Quit(); 
    }

    public void EffetDesBoutonsReprendre()
    {
        UiDeLaPause.SetActive(false);
    }

    public void EffetDesBoutonsRetour()
    {
        UiDeLesOptions.SetActive(false);
    }

    public void EffetDuBoutonOuiDesSousTitres()
    {
        UiDeLesSousTitres.SetActive(true); 
    }

    public void EffetDuBoutonNonDesSousTitres()
    {
        UiDeLesSousTitres.SetActive(false);
    }

    public void LeSonPlusFort(float volume=100)
    {
        AudioListener.volume =+ 10;
    }

    public void LeSonMoinsFort(float volume=100)
    {
        AudioListener.volume =- 10;
    }

    // Start is called before the first frame update
    void Start()
    {
        UiDeLaMort.SetActive(false);
        UiDeLaPause.SetActive(false);
        UiDeLesOptions.SetActive(false);
        UiDeLesSousTitres.SetActive(false);
        mort = false;

        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Death Scene"))
        {
            UiDeLaMort.SetActive(true);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKeyDown("p"))
        {
            UiDeLaPause.SetActive(true);
            UiDeLaMort.SetActive(!UiDeLaMort);
            UiDeLesOptions.SetActive(!UiDeLesOptions);
            UiDeLesSousTitres.SetActive(!UiDeLesSousTitres);
            mort = false;
            //gameObject.GetComponent<Throwable>().enabled = false; //a modif marche pas cette ligne là
        }

        if (Input.GetKeyDown("o"))
        {
            UiDeLesOptions.SetActive(true);
            UiDeLaMort.SetActive(!UiDeLaMort);
            UiDeLaPause.SetActive(!UiDeLaPause);
            UiDeLesSousTitres.SetActive(!UiDeLesSousTitres);
            mort = false;
        }

        if (Input.GetKeyDown("s"))
        {
            UiDeLesSousTitres.SetActive(true);
            UiDeLaMort.SetActive(!UiDeLaMort);
            UiDeLaPause.SetActive(!UiDeLaPause);
            UiDeLesOptions.SetActive(!UiDeLesOptions);
            mort = false;
        }

        if (Input.GetKeyDown("m"))
        {
            mort = !mort;
            UiDeLaPause.SetActive(!UiDeLaPause);
            UiDeLesOptions.SetActive(!UiDeLesOptions);
            UiDeLesSousTitres.SetActive(!UiDeLesSousTitres);
        }


        if (mort == true)
        {
        
            SceneManager.LoadScene("Death Scene");

        }

        if (UiDeLaPause.activeInHierarchy || UiDeLaMort.activeInHierarchy || UiDeLesOptions.activeInHierarchy)
        {
            Pointer.SetActive(true);
            VRInputModule.SetActive(true);
            Debug.Log("Le pointer est présent");
        }

        if (!UiDeLaPause.activeInHierarchy || !UiDeLaMort.activeInHierarchy || !UiDeLesOptions.activeInHierarchy)
        {
            Pointer.SetActive(false);
            VRInputModule.SetActive(false);
            Debug.Log("Le pointer n'est pas là");
        }

    }

    public void OnPointerClick(PointerEventData eventData)
    {
        
    }
}
