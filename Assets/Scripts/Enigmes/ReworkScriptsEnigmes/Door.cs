using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public float rotationResetSpeed = 1f;
    private Quaternion rotation;
    private Quaternion originalRotation;
    // Start is called before the first frame update
    void Start()
    {
        rotation = transform.rotation;
        rotation.y -= 90;
        originalRotation = transform.rotation;
    }
    

    public void Open()
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.time * rotationResetSpeed);
    }

    public void Close()
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, originalRotation, Time.time * rotationResetSpeed);
    }
}
