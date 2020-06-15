using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torchbearer : MonoBehaviour
{
    public GameObject torch;
    public Door door;
    public GameObject VFX;
    public Vector3 rotationAngle;
    private Vector3 pos;
    private Quaternion rot;
    // Start is called before the first frame update
    void Start()
    {
        if (torch == null)
        {
            Debug.Log("Torche à renseigner dans porteTorche");
        }
        pos = transform.position;
        rot.eulerAngles = rotationAngle;
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
            torch.transform.rotation = rot;
            torch.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            VFX.SetActive(true);

            if(GetComponent<StoryElementMonologue>())
            {
                GetComponent<StoryElementMonologue>().TriggerMonologue();
                Destroy(GetComponent<StoryElementMonologue>());
            }
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
