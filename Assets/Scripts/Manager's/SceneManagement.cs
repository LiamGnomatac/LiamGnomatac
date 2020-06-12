using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    int buildIndex;
    public static SceneManagement s_Singleton;
    private int DeathCount;
    public bool niveau4 = false;

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
        DontDestroyOnLoad(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GetCurrentScene()
    {
        Debug.Log("Recup build index");
        Scene currentScene = SceneManager.GetActiveScene();
        buildIndex = currentScene.buildIndex;
        Debug.Log(buildIndex);
    }

    public void LoadPreviewScene()
	{
        Debug.Log("Entré dans la fonction LPS");
        switch (buildIndex)
        {
            
            case 0:
                // Do something...
                SceneManager.LoadScene("BureauAsset");
                break;
            case 1:
                // Do something...
                SceneManager.LoadScene("Niveau1");
                break;
            case 2:
                SceneManager.LoadScene("Niveau2");
                break;
            case 3:
                SceneManager.LoadScene("Niveau3");
                break;
            case 4:
                SceneManager.LoadScene("Niveau4");
                niveau4 = true;
                break;
            
            case 5:
                SceneManager.LoadScene("Credit");
                break;
        }
    }

    public void ChooseLoadScene(int load)
    {
        switch (load)
        {

            case 0:
                // Do something...
                SceneManager.LoadScene("BureauAsset");
                break;
            case 1:
                // Do something...
                SceneManager.LoadScene("Niveau1");
                break;
            case 2:
                SceneManager.LoadScene("Niveau2");
                break;
            case 3:
                SceneManager.LoadScene("Niveau3");
                break;
            case 4:
                SceneManager.LoadScene("Niveau4");
                break;
            
            case 5:
                SceneManager.LoadScene("Credit");
                break;
        }
    }

    public void GetKilled()
    {
        ScreamerManager.s_Singleton.chien.SetActive(false);
        ScreamerManager.s_Singleton.scorpion.SetActive(false);
        ScreamerManager.s_Singleton.taureau.SetActive(false);
        DeathCount++;
        Debug.Log("Joueur Mort");
        GetCurrentScene();
        SceneManager.LoadScene("Death Scene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    private void TorchToPhone()
    {
        if(DeathCount > 2)
        {
            TPPerso.s_Singleton.torchLightIsBroke = true;
        }
    }
}
