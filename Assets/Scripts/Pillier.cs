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
        if(collision.gameObject == taurus && taurus.GetComponent<TaureauScript>().isRunning)
        {
            RepeatingInvoke();
            GameManager.s_Singleton.pillarBroke++;
            BlindTp();
            Invoke("DestroyGObj", invTime);
        }
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

    private void BlindTp()
    {
        if (GameManager.s_Singleton.pillarBroke < 4)
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
