using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private Vector3 rotation = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {
        rotation = transform.rotation.eulerAngles;
    }
    

    public void Open()
    {
        transform.Rotate(rotation.x, rotation.y -90, rotation.z);
    }

    public void Close()
    {
        transform.Rotate(rotation.x, rotation.y + 90, rotation.z);
    }
}
