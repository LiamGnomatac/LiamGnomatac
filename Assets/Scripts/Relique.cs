using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Relique : MonoBehaviour
{
    public float timeBeforeSceneChange;
    public GameObject gravas;
    public float invRepeatRate;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Floor")
        {
            Debug.Log("c'est cassé");
            Invoke("SceneManagement.s_Singleton.ChooseLoadScene(5)", timeBeforeSceneChange);
        }
    }

    private void RepeatingInvoke()
    {
        InvokeRepeating("InvokeGravel", 0, invRepeatRate);
    }

    private void InvokeGravel()
    {
        Instantiate(gravas, gameObject.transform);
    }
}
