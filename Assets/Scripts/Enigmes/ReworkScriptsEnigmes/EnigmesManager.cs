using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnigmesManager : MonoBehaviour
{
    
    #region Variable Enigme
    
    [HideInInspector]
    public bool firstEIsComplete = false, secondEIsComplete = false, thirdEIsComplete = false;

    
    //[HideInInspector]
    public bool rockIsPull, rockGetOut;
    [HideInInspector]
    public int statueIsStatic;

    //[HideInInspector]
    public bool isPressMain, isPress;

    #endregion

    public static EnigmesManager s_Singleton;
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
    void Update()
    {
        
    }

    #region Enigme

    

    #endregion
}
