﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaureauScript : MonoBehaviour
{

    public float vitesse = 1f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GetComponent<Encens>().EncensIsTurnOnOrNot == true)
        {

            TaureauGoToEncens();

        }
    }




    public void TaureauGoToEncens()
    {




    }




}
