using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace SubtitlesScript // Permet de pouvoir appeller certaines fonctions du scripts dans d'autres scripts en utilisant la commande "using SubtitlesScript;" en début de script.
{

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
}
