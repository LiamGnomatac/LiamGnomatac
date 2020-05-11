using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class AssignFuctionToButton : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
        HoverButton b = gameObject.GetComponent<HoverButton>();
        b.onButtonDown.AddListener(delegate { SceneManagement.s_Singleton.LoadPreviewScene(); });
    }

}
