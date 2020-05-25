using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using Valve.VR.InteractionSystem;

public class ButtonLock : MonoBehaviour
{
    private HoverButton hoverButton;
    private Interactable interactable;
    private Vector3 startPos;
    // Start is called before the first frame update
    void Start()
    {
        hoverButton = GetComponent<HoverButton>();
        interactable = GetComponent<Interactable>();
        startPos = hoverButton.movingPart.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LockDown()
    {
        if (EnigmesManager.s_Singleton.rockIsPull)
        {
            hoverButton.enabled = false;
            interactable.enabled = false;
            hoverButton.movingPart.position += hoverButton.localMoveDistance;
            GetComponent<PositionConstraint>().constraintActive = true ;
            //GetComponentInChildren<Transform>().position = Vector3.MoveTowards(hoverButton.movingPart.position, hoverButton.movingPart.position += hoverButton.localMoveDistance, 0);
        }
    }

    public void LockUp()
    {
        hoverButton.movingPart.position = startPos;
        GetComponent<PositionConstraint>().constraintActive = false;
    }
}
