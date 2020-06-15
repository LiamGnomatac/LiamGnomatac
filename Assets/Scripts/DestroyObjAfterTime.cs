using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObjAfterTime : MonoBehaviour
{
    public float destroyTime;
    public bool destroyAfterPlayerGrab;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroyGO", destroyTime);
    }

    public void DestroyGO()
    {
        Destroy(gameObject);
    }
}
