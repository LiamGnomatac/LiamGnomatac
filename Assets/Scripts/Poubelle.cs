using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poubelle : MonoBehaviour
{
    public GameObject vfxLoadingPlaytest;
    public bool PapierIsTriggerOrNot;
    public bool ExitGame;
    int triggerPapier = 0;
    float chrono;
    // Start is called before the first frame update
    void Start()
    {
        chrono = 10;
    }

    // Update is called once per frame
    void Update()
    {
        

        if (chrono <=0)
        {
            chrono = 0;
            ExitGame = true;
            Time.timeScale = 0;
            Application.Quit();
            Debug.Log("ca marche");
        }

        if (triggerPapier > 0)
        {
            PapierIsTriggerOrNot = true;
            chrono -= Time.deltaTime;
        }

        if (triggerPapier <= 0)
        {
            PapierIsTriggerOrNot = false;
            chrono = 10;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Papier")
        {
            triggerPapier++;
            vfxLoadingPlaytest.SetActive(true);
            Debug.Log("Papier IsTrigger dans la poubelle!");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Papier")
        {
            triggerPapier--;
            vfxLoadingPlaytest.SetActive(false);
        }
    }
    void OnGUI ()
    {
        GUI.Box(new Rect(700, 10, 150, 100), chrono.ToString());
    }
}

