using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SentenceManager : MonoBehaviour
{
    private Queue<string> sentences;

    public float timeBeforeDisplayText;
    public TextMeshProUGUI monologueName;
    public TextMeshProUGUI monologueText;
    public static SentenceManager s_Singleton;
    public Animator animator;

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
        sentences = new Queue<string>();
    }

    public void StartMonologue(Monologues monologue)
    {
        animator.SetBool("isOpen", true);
        Debug.Log("Starting conversation " + monologue.name);
        monologueName.text = monologue.name;
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
        Invoke("DisplayNextSentence",timeBeforeDisplayText);
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
        monologueText.text = "";
        animator.SetBool("isOpen", false);
    }
}
