using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemonterM : MonoBehaviour
{
    public enum WhichTrigger{Second, Third, End};
    public WhichTrigger trigger;
    private bool isEnd;
    private bool isSecond;
    private bool isThird;

    // Start is called before the first frame update
    void Start()
    {
        GameManager.s_Singleton.firstEIsComplete = true;
        GameManager.s_Singleton.secondEIsComplete = true;
        GameManager.s_Singleton.thirdEIsComplete = true; 
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
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
                            Debug.Log("Chute de pierre");
                        }
                        return;
                    }
                    else
                    {
                        Debug.Log("Chute de pierre");
                        isThird = true;
                    }
                    break;
                case WhichTrigger.End:
                    isEnd = true;
                    break;
                default:
                    break;
            }
        }
    }
}
