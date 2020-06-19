using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RebootMonologue : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SentenceManager.s_Singleton.ClearQueue();
    }
}
