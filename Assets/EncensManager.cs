using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EncensManager : MonoBehaviour
{

    public GameObject encens1;
    public GameObject encensLight1;
    public GameObject encens2;
    public GameObject encensLight2;
    public GameObject encens3;
    public GameObject encensLight3;
    public GameObject encens4;
    public GameObject encensLight4;
    public GameObject encensCheck;
    public bool thereIsLight = false;

    public static EncensManager s_Singleton;

    private void Awake()
    {
        if (s_Singleton != null)
        {
            Destroy(gameObject);
        }
        else
        {
            s_Singleton = this;
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        encensCheck.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (encensLight1 == true && thereIsLight == false)
        {
            encensCheck.transform.position = encens1.transform.position;
            thereIsLight = true;
            encensCheck.SetActive(true);
        }

        if (encensLight2 == true && thereIsLight == false)
        {
            encensCheck.transform.position = encens2.transform.position;
            thereIsLight = true;
            encensCheck.SetActive(true);
        }

        if (encensLight3 == true && thereIsLight == false)
        {
            encensCheck.transform.position = encens3.transform.position;
            thereIsLight = true;
            encensCheck.SetActive(true);
        }


        if (encensLight4 == true && thereIsLight == false)
        {
            encensCheck.transform.position = encens4.transform.position;
            thereIsLight = true;
            encensCheck.SetActive(true);
        }



    }
}
