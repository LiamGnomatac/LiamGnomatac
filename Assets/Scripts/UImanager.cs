using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    public Image transitionTp;

    public static UiManager s_Singleton;

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
        transitionTp.canvasRenderer.SetAlpha(0);
    }


    public void FadeIn()
    {
        transitionTp.CrossFadeAlpha(1, 1, false);
    }

    public void FadeOut()
    {
        transitionTp.CrossFadeAlpha(0, 1, false);
    }

}
