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
        GameManager.LoadGame(GameManager.GameModes.Procedural3D);
    }
    public void LoadGameStory3D()
    {
        GameManager.LoadGame(GameManager.GameModes.Story3D);
    }
    public void LoadGameStory2D()
    {
        GameManager.LoadGame(GameManager.GameModes.Story2D);
    }
    public void LoadGameSample()
    {
        GameManager.LoadGame(GameManager.GameModes.Sample);
    }

    public void LoadGame(GameManager.GameModes gameMode)
    {
        GameManager.LoadGame(gameMode);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
