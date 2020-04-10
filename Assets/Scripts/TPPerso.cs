using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class TPPerso : MonoBehaviour
{
    // Start is called before the first frame update

    private Player player;
    private Vector3 lookAtPosition = Vector3.zero;
    private Transform lookAtJointTransform;


    void Start()
    {
        player = Player.instance;
    }


    //-------------------------------------------------
    void Update()
    {
        if (Application.isPlaying)
        {
            lookAtPosition.x = player.hmdTransform.position.x;
            lookAtPosition.y = lookAtJointTransform.position.y;
            lookAtPosition.z = player.hmdTransform.position.z;

            lookAtJointTransform.LookAt(lookAtPosition);
        }
    }


   
}
