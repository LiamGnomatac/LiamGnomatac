using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    int buildIndex;
    public static SceneManagement s_Singleton;

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
        Scene currentScene = SceneManager.GetActiveScene();
        buildIndex = currentScene.buildIndex;
    }

    public void LoadPreviewScene()
	{
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
                break;
            case 5:
                SceneManager.LoadScene("Remonter");
                break;
        }
    }

    public void GetKilled()
    {
        GetCurrentScene();
        SceneManager.LoadScene("Death Scene");
    }
}
