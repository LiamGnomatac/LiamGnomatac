using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Monologues
{
    public string name;
    [TextArea(2,5)]
    public string[] sentences;
}
