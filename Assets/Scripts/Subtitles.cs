using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Subtitles : MonoBehaviour
{
    public List<GameObject> listeDesLignesDeSousTitres = new List<GameObject> { };
    public int uneLigneDeSousTitre;
    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject obj in listeDesLignesDeSousTitres)
        {
            obj.SetActive(false);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }
}
