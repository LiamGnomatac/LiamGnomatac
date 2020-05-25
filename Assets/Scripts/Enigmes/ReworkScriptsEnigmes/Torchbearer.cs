using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torchbearer : MonoBehaviour
{
    public GameObject torch;
    public Door door;
    public GameObject VFX;
    private Vector3 pos;
    private Vector3 rot;
    // Start is called before the first frame update
    void Start()
    {
        if (torch == null)
        {
            Debug.Log("Torche à renseigner dans porteTorche");
        }
        pos = transform.position;
        rot = transform.rotation.eulerAngles;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == torch)
        {
            door.Open();
            torch.transform.position = pos;
            torch.transform.rotation = transform.rotation;
            torch.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            VFX.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == torch)
        {
            door.Close();
            torch.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            EnigmesManager.s_Singleton.firstEIsComplete = false;
            VFX.SetActive(false);

        }
    }
}
