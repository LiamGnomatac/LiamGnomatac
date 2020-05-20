using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class ButtonLock : MonoBehaviour
{
    private HoverButton hoverButton;
    // Start is called before the first frame update
    void Start()
    {
        hoverButton = GetComponent<HoverButton>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LockDown()
    {
        hoverButton.movingPart.position += hoverButton.localMoveDistance;
        hoverButton.enabled = false;
    }
}
