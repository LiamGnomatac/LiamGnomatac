using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillierCentral : MonoBehaviour
{
    public GameObject taurus;
    public GameObject gravas;
    public float invTime;
    public float invRepeatRate;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == taurus && taurus.GetComponent<TaureauScript>().isRunning && EnigmesManager.s_Singleton.pillarBroke > 4)
        {
            DestroyGObj();
        }
    }
    private void OnDestroy()
    {
        RepeatingInvoke();
    }

    private void DestroyGObj()
    {
        Destroy(gameObject);
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
