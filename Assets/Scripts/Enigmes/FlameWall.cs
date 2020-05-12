using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class FlameWall : MonoBehaviour
{
    public int particuleDivide;
    public GameObject VFX;
    public GameObject[] spawnPointVFX;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < spawnPointVFX.Length; i++)
        {
            Instantiate(VFX, spawnPointVFX[i].transform);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReduceParticle()
    {
        for (int i = 0; i < spawnPointVFX.Length; i++)
        {
            ParticleSystem ps = spawnPointVFX[i].GetComponentInChildren<ParticleSystem>();
            var main = ps.main;
            main.maxParticles /= particuleDivide;

            /*MainModule main = spawnPointVFX[i].GetComponent<ParticleSystem>().main;
            main.maxParticles /= particuleDivide;*/

            /*ParticleSystem.MainModule main = spawnPointVFX[i].GetComponent<ParticleSystem>().main;
            main.maxParticles /= particuleDivide;*/
        }
    }


}
