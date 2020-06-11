using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillierManager : MonoBehaviour
{
    public GameObject zoneCentrale;
    public GameObject taurus;
    public GameObject gravas;
    public GameObject[] FlameWall;
    public Relique relique;
    public float invTime;
    public float invRepeatRate;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void DestroyPillar(GameObject collision, GameObject gm)
    {
        if(collision == taurus && taurus.GetComponent<TaureauScript>().isRunning)
        {
            EnigmesManager.s_Singleton.pillarBroke++;
            StuntTaurus();
            BlindTp();
            CanCatchRelique();
            InstantiateGravel(collision.transform.position);
            Destroy(gm);
        }
    }

    private void InstantiateGravel(Vector3 pos)
    {
        Instantiate(gravas, pos, Quaternion.identity);
        Instantiate(gravas, pos, Quaternion.identity);
    }
    private void StuntTaurus()
    {
        Debug.Log("toucher couler");
        TaureauScript.s_Singleton.TaureauStun();
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
    private void CanCatchRelique()
    {
        Debug.Log("toucher");
        if (EnigmesManager.s_Singleton.pillarBroke >= 4)
        {
            zoneCentrale.SetActive(true);
            relique.DeFreeze();
        }
    }
}
