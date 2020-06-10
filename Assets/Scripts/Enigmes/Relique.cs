using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class Relique : MonoBehaviour
{
    public float timeBeforeSceneChange;
    public GameObject gravas;
    public float invRepeatRate;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Destroy(GetComponentInChildren<ParticleSystem>().gameObject);
        }
        if(collision.gameObject.name == "Floor")
        {
            Debug.Log("c'est cassé");
            Invoke("changeScene", timeBeforeSceneChange);
        }
    }

    private void RepeatingInvoke()
    {
        InvokeRepeating("InvokeGravel", 0, invRepeatRate);
    }

    public void DeFreeze()
    {
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        gameObject.AddComponent<Throwable>();
    }

    private void InvokeGravel()
    {
        Instantiate(gravas, gameObject.transform.position, Quaternion.identity);
    }

    private void changeScene()
    {
        SceneManagement.s_Singleton.ChooseLoadScene(6);
    }
}
