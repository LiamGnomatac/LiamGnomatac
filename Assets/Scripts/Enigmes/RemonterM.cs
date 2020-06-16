using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemonterM : MonoBehaviour
{
    public float timeBeforeTimerDeathBegin = 5;
    public float countdownBeforeDeath = 30;
    public GameObject zoneFin;
    public GameObject VFXFlame;
    public List<Transform> spawnPointFlame;
    public StoryElementMonologue monologue;
    private void Start()
    {
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
        for (int i = 0; i < spawnPointFlame.Count; i++)
        {
            Instantiate(VFXFlame, spawnPointFlame[i]);
        }
        if(monologue)
        {
            monologue.TriggerMonologue();
            Destroy(monologue);
        }
        GoToCredits();
    }
}
