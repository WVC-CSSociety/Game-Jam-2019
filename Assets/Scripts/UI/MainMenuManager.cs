using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void LoadGameProcedural3D()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Procedural");
    }
    public void LoadGameStory3D()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Story3D");
    }
    public void LoadGameStory2D()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Story2D");
    }
    public void LoadGameSample()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("SampleScene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
