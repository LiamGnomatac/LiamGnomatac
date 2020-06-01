using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SentenceManager : MonoBehaviour
{
    private Queue<string> sentences;

    public TextMeshProUGUI monologueText;
    public static SentenceManager s_Singleton;

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
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);
        sentences = new Queue<string>();
    }
    
    public void StartMonologue(Monologues monologue)
    {
        Debug.Log("Starting conversation" + monologue.name);
        sentences.Clear();
        foreach (string sentence in monologue.sentences)
        {
            sentences.Enqueue(sentence);
        }
        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if(sentences.Count == 0)
        {
            EndMonologue();
            return;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence (string sentence)
    {
        monologueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            monologueText.text += letter;
            yield return null;
        }
    }

    public void EndMonologue()
    {
        Debug.Log("end of conversation");
    }
}
