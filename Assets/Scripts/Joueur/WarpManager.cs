using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Valve.VR.InteractionSystem;
using Valve.VR;

public class WarpManager : MonoBehaviour
{
    public GameObject center;
    public GameObject zoneStart;
    public GameObject zone1;
    public GameObject zone2;
    public GameObject zone3;
    public GameObject zone4;
    public GameObject zoneEnd;



    // Start is called before the first frame update
    void Start()
    {
        center.transform.position = zoneStart.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(zoneEnd.transform.position == center.transform.position)
        {
            center.GetComponent<TPPerso>().Invoke("FadeToBlack", 3);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
