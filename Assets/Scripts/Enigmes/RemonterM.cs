using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemonterM : MonoBehaviour
{
    public GameObject LargeRock;
    public enum WhichTrigger{Second, Third, End};
    public WhichTrigger trigger;
    private bool isEnd;
    private bool isSecond;
    private bool isThird;
    private int i;
    public Transform[] spawnPointLandslide;
    public Transform[] spawnPointMonsterR3;
    public Transform[] spawnPointMonsterR2;
    public Transform[] spawnPointMonsterR1;
    public float invTime;
    public float invRepeatRate;
    public float countdown;
    private float time;
    public GameObject[] monstres;

    // Start is called before the first frame update
    void Start()
    {
        GameManager.s_Singleton.firstEIsComplete = true;
        GameManager.s_Singleton.secondEIsComplete = true;
        GameManager.s_Singleton.thirdEIsComplete = true;
        time = countdown;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        CountDown();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            switch (trigger)
            {
                case WhichTrigger.Second:
                    if(!GameManager.s_Singleton.thirdEIsComplete)
                    {
                        return;
                    }
                    else
                    {
                        Debug.Log("Chute de pierre");
                        i = 0;
                        Landslide();
                        isSecond = true;
                    }
                    break;
                case WhichTrigger.Third:
                    if (!GameManager.s_Singleton.secondEIsComplete)
                    {
                        if(!isSecond)
                        {
                            return;
                        }
                        else
                        {
                            i = 1;
                            Landslide();
                            Debug.Log("Chute de pierre");
                        }
                        return;
                    }
                    else
                    {
                        Debug.Log("Chute de pierre");
                        i = 2;
                        Landslide();
                        isThird = true;
                    }
                    break;
                case WhichTrigger.End:
                    isEnd = true;
                    End();
                    break;
                default:
                    break;
            }
        }
    }

    private void End()
    {
        SceneManagement.s_Singleton.ChooseLoadScene(0);
    }

    private void Landslide()
    {
        InvokeRepeating("InstanceLargeRock", invTime, invRepeatRate);
    }

    private void InstanceLargeRock()
    {
        Debug.Log("cailloux qui tombe");
        Instantiate(LargeRock, spawnPointLandslide[i]);
    }

    private void TpMonster(Transform[] list)
    {
        for (int z = 0; z < list.Length; z++)
        {
            monstres[z].transform.position = list[z].position;
        }
        return;
    }

    private void CountDown()
    {
        time -= Time.deltaTime;
        if(time<= 0)
        {
            if(!isSecond)
            {
                TpMonster(spawnPointMonsterR3);
                isSecond = true;
                time = countdown;
                return;
            }
            if(!isThird)
            {
                TpMonster(spawnPointMonsterR2);
                isThird = true;
                time = countdown;
                return;
            }
            else
            {
                TpMonster(spawnPointMonsterR1);
                time = countdown;
            }
            time = countdown;
        }
    }
}
