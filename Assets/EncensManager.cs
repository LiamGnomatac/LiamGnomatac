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
    public Vector3 encensCheck;
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
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        Invoke("CheckEncens", 5);


    }


    private void CheckEncens()
    {

        if (encens1.GetComponent<EncensCS>().isTurnOn == true && thereIsLight == false)
        {
            encensCheck = encens1.transform.position;
            thereIsLight = true;

        }


        if (encens2.GetComponent<EncensCS>().isTurnOn == true && thereIsLight == false)
        {
            encensCheck = encens2.transform.position;
            thereIsLight = true;

        }

        if (encens3.GetComponent<EncensCS>().isTurnOn == true && thereIsLight == false)
        {
            encensCheck = encens3.transform.position;
            thereIsLight = true;

        }


        if (encens4.GetComponent<EncensCS>().isTurnOn == true && thereIsLight == false)
        {
            encensCheck = encens4.transform.position;
            thereIsLight = true;

        }


    }


}
