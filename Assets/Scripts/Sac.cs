using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class Sac : MonoBehaviour
{

    public GameObject sac ;
    public GameObject porte ;
    public GameObject poignee;
    public GameObject porteRotation;
    public GameObject telephone;
    public GameObject lampeTorche;
    public GameObject zoneEnd;
    public Interactable interactablePorte;
    public Interactable interactablePoignee;
    public Interactable interactablePorteRotation;
    public Rigidbody rigidbodyPorte ;
    private bool CanOpenDoor ; 
    float numberOfEssentialsObjects;
    int trigger = 0 ;
    private Transform pos;


    // Start is called before the first frame update
    void Start()
    {
        numberOfEssentialsObjects = 0;
        porte.GetComponent<Interactable>().enabled = false;
        poignee.GetComponent<Interactable>().enabled = false;
        porteRotation.GetComponent<Interactable>().enabled = false;
        porteRotation.GetComponent<CircularDrive>().enabled = false;
        zoneEnd.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (numberOfEssentialsObjects == 0)
        {
            CanOpenDoor = false;
            Debug.Log("il y a 0 objet important dans le sac");
        }

        if (numberOfEssentialsObjects == 1)
        {
            CanOpenDoor = false;
            Debug.Log("il y a 1/2 objet important dans le sac");
        }

        if (numberOfEssentialsObjects == 2)
        {
            CanOpenDoor = true;
            Debug.Log("il y a 2/2 objet important dans le sac, la porte peux s'ouvrir");
        }

        if (CanOpenDoor == true)
        {
            //porte.GetComponent<Interactable>().enabled = true;
            poignee.GetComponent<Interactable>().enabled = true;
            //porteRotation.GetComponent<Interactable>().enabled = true;
            porteRotation.GetComponent<CircularDrive>().enabled = true;

        }

        if (CanOpenDoor == false)
        {
            porte.GetComponent<Interactable>().enabled = false;
            poignee.GetComponent<Interactable>().enabled = false;
            porteRotation.GetComponent<Interactable>().enabled = false;
            porteRotation.GetComponent<CircularDrive>().enabled = false;
        }

       
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Essential")
        {
            trigger++;
            numberOfEssentialsObjects += 1;
            Debug.Log("Un Objet important à été mis dans le sac");

        }

        if (other.gameObject.tag == "Telephone")
        {
            trigger++;
            telephone.SetActive(false);
            numberOfEssentialsObjects += 1;
            Debug.Log("Le téléphone a été mis dans le sac et ne peux plus etre récupérer");
        }

        if (other.gameObject.tag == "LampeTorche")
        {
            trigger++;
            lampeTorche.SetActive(false);
            numberOfEssentialsObjects += 1;
            Debug.Log("La Lampe torche a été mis dans le sac et ne peux plus etre récupérer");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Essential")
        {
            trigger--;
            numberOfEssentialsObjects -= 1;
            Debug.Log("Un Objet important à été retiré du sac");
        }
    }

    private void OpenDoor()
    {
        //transform.rotation = Quaternion.Euler(0, -90, 0);
        porte.transform.Rotate(pos.transform.rotation.x, pos.transform.rotation.y - 1, pos.transform.rotation.z, Space.World);
    }

    private void CloseDoor()
    {
        porte.transform.Rotate(-pos.transform.rotation.x, -pos.transform.rotation.y, -pos.transform.rotation.z, Space.World);
    }

    private void FixedUpdate()
    {
        if(CanOpenDoor == true)
        {
            zoneEnd.SetActive(true);
            if(GetComponent<StoryElementMonologue>())
            {
                GetComponent<StoryElementMonologue>().TriggerMonologue();
                Destroy(GetComponent<StoryElementMonologue>());
            }

        }
    }
}
