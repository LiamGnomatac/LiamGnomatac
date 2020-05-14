using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EncensManager : MonoBehaviour
{

    public Vector3 encensCheck;
    public bool thereIsLight = false;
    public List<GameObject> encensList;
    public List<GameObject> encensTurnOn = new List<GameObject>();


    public static EncensManager s_Singleton;

    private void Awake()
    {
        if (s_Singleton != null)
        {
            Destroy(gameObject);
        }
        else
        {
            s_Singleton = this;
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        


    }


    public void CheckEncens()
    {

        encensTurnOn.Clear();

        for (int i = 0; i < encensList.Count; i++)
        {
           
            if (encensList[i].GetComponent<EncensCS>().isTurnOn == true)
            {

               
                encensTurnOn.Add(encensList[i]);
                Debug.Log(encensList.Count);
                
            }
        }

        
    }

    public Vector3 direction()
    {
        int rand = Random.Range(0, encensTurnOn.Count);

        Vector3 direction = encensTurnOn[rand].transform.position;

        encensTurnOn.RemoveAt(rand);

        return direction;

    }

}
