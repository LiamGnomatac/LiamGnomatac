using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class Door : MonoBehaviour
{
    //public float rotationResetSpeed = 1f;
    //public int rotationAngle = 90;
    private Quaternion rotation;
    private Quaternion originalRotation;
    // Start is called before the first frame update
    void Start()
    {
        //rotation = transform.rotation;
        //rotation.y -= rotationAngle;
        //originalRotation = transform.rotation;
    }

    public void Open()
    {
        GetComponent<Animator>().SetBool("Interact",true);
        //transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.time * rotationResetSpeed);
    }

    public void Close()
    {
        //transform.rotation = Quaternion.Slerp(transform.rotation, originalRotation, Time.time * rotationResetSpeed);
        GetComponent<Animator>().SetBool("Interact", false);
    }
}
