using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class AssignFunction : MonoBehaviour
{
    public bool quit;
    // Start is called before the first frame update
    void Start()
    {
        if(quit)
        {
            Application.Quit();
        }
        else
        {
            HoverButton b = gameObject.GetComponent<HoverButton>();
            b.onButtonDown.AddListener(delegate { SceneManagement.s_Singleton.ChooseLoadScene(0); });
        }
    }
}
