﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EncensManager : MonoBehaviour
{

    public Vector3 encensCheck;
    public bool thereIsLight = false;
    public List<EncensCS> encensList;
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

        


    }


    

    public Vector3 direction()
    {
        for (int i = 0; i < encensList.Count; i++)
        {
            if (encensList[i].isTurnOn)
            {
                return encensList[i].transform.position;
            }
        }
        return Vector3.zero;
    }

}
