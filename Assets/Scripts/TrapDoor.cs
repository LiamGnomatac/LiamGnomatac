using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapDoor : MonoBehaviour
{
    private Vector3 pos;
    private Vector3 onPress;
    public float pressureDist;
    // Start is called before the first frame update
    void Start()
    {
        pos = transform.position;
        onPress = new Vector3 (transform.position.x, transform.position.y - pressureDist, transform.position.z);
        Debug.Log(onPress);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPress()
    {
        transform.position = Vector3.MoveTowards(transform.position, onPress, Time.deltaTime);
    }

    public void OnRelease()
    {
        transform.position = pos;
    }
}
