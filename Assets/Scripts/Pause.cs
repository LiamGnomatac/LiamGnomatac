using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{

    private bool isPause;

    public GameObject canvas;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.G))
        {
            TogglePause();
            ToggleCanvas();
        }
    }

    public void ToggleCanvas()
    {
        canvas.SetActive(!canvas.activeSelf);
    }
    
    public void TogglePause()
    {
        if(isPause)
        {
            Time.timeScale = 1;
            isPause = false;
            ToggleCanvas();
        }
        else
        {
            Time.timeScale = 0;
            isPause = true;
        }
    }

    public void Quit()
    {
        Application.Quit();
    }
}
