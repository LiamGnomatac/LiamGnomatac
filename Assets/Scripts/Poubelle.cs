using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poubelle : MonoBehaviour
{
    public GameObject vfx;
    public float timeBeforeQuit = 5;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Papier")
        {
            vfx.SetActive(true);
            Invoke("Quit", timeBeforeQuit);
            Debug.Log("Papier IsTrigger dans la poubelle!");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Papier")
        {
            vfx.SetActive(false);
            CancelInvoke("Quit");
        }
    }

    private void Quit()
    {
        Application.Quit();
    }

}

