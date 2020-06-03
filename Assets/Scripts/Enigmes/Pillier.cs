using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pillier : MonoBehaviour
{
    public GameObject taurus;
    public GameObject gravas;
    public GameObject[] FlameWall;
    public float invTime;
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
        Debug.Log("toucher couler");
        if (collision.gameObject == taurus && taurus.GetComponent<TaureauScript>().isRunning)
        {
            TaureauScript.s_Singleton.TaureauStun();
            Invoke("DestroyGObj", invTime);
        }
    }

    private void OnDestroy()
    {
        EnigmesManager.s_Singleton.pillarBroke++;
        BlindTp();
        RepeatingInvoke();
    }

    private void DestroyGObj()
    {
        
        Debug.Log("death");
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

    private void BlindTp()
    {
        Debug.Log("blind");
        if (EnigmesManager.s_Singleton.pillarBroke < 4)
        {
            for (int i = 0; i < FlameWall.Length; i++)
            {
                FlameWall[i].GetComponent<FlameWall>().ReduceParticle();
            }
        }
        else
        {
            for (int i = 0; i < FlameWall.Length; i++)
            {
                Destroy(FlameWall[i]);
            }
        }
    }
}
