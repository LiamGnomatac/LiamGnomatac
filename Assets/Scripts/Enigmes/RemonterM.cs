using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemonterM : MonoBehaviour
{
    public float timeBeforeTimerDeathBegin = 5;
    public float countdownBeforeDeath = 30;
    public GameObject zoneFin;
    public GameObject VFXFlame;
    public StoryElementMonologue monologue;

    public static RemonterM s_Singleton;
    private void Awake()
    {
        if (s_Singleton != null)
        {
            Destroy(gameObject);
        }
        else
        {
            s_Singleton = this;
        }
    }
    private void Start()
    {
        VFXFlame.SetActive(false);
        zoneFin.SetActive(false);
        Debug.Log("false");
        Invoke("FirstTimerBegin", timeBeforeTimerDeathBegin);
    }

    private void FirstTimerBegin()
    {
        Invoke("CountdownDeathBegin", countdownBeforeDeath);
    }

    private void CountdownDeathBegin()
    {
        ScreamerManager.s_Singleton.KillingScorpion();
    }

    public void GoToCredits()
    {
        Debug.Log("crédit");
        zoneFin.SetActive(true);
    }

    public void spawnFlames()
    {
        Debug.Log("bcp flames");
        VFXFlame.SetActive(true);
        GoToCredits();
        if (monologue)
        {
            monologue.TriggerMonologue();
            Destroy(monologue);
        }
    }
}
