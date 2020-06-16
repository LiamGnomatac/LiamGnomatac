using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Valve.VR.InteractionSystem;
using Valve.VR;

public class WarpManager : MonoBehaviour
{

    public GameObject zoneStart;
    public GameObject zoneEnd;
    // Start is called before the first frame update
    void Start()
    {
        if(TPPerso.s_Singleton)
        {
            TPPerso.s_Singleton.Invoke("FadeFromBlack", 3);
            TPPerso.s_Singleton.transform.position = zoneStart.transform.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(TPPerso.s_Singleton)
        {
            if (zoneEnd.transform.position == TPPerso.s_Singleton.transform.position)
            {
                TPPerso.s_Singleton.Invoke("FadeToBlack", 3);
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
    }
}
