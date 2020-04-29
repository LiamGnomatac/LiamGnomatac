using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemonterM : MonoBehaviour
{
    public float totalTime;
    public Collider first;
    public Collider second;
    public Collider third;
    public Collider fin;

    private float quarterTime;
    private bool isFirst;
    private bool isSecond;
    private bool isThird;

    // Start is called before the first frame update
    void Start()
    {
        GameManager.s_Singleton.firstEIsComplete = true;
        GameManager.s_Singleton.secondEIsComplete = true;
        GameManager.s_Singleton.thirdEIsComplete = true;

        quarterTime = totalTime / 4;
        quarterTime += Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        /*if(GameManager.s_Singleton.thirdEIsComplete && Time.time > quarterTime || !isThird && Time.time > quarterTime)
        {
            Debug.Log("Die");
        }*/
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other == fin)
        {

        }

        if (other == first)
        {
            isFirst = true;
        }

        if (other == second)
        {
            isSecond = true;
        }

        if (other == third)
        {
            isThird = true;
        }
    }
}
