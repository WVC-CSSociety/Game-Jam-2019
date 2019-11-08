using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public static void LoadGame(GameModes mode)
    {
        switch(mode)
        {
            case GameModes.Procedural3D:
                UnityEngine.SceneManagement.SceneManager.LoadScene("Procedural");
                break;
            case GameModes.Story3D:
                UnityEngine.SceneManagement.SceneManager.LoadScene("Story3D");
                break;
            case GameModes.Story2D:
                UnityEngine.SceneManagement.SceneManager.LoadScene("Story2D");
                break;
            case GameModes.Sample:
                UnityEngine.SceneManagement.SceneManager.LoadScene("SampleScene");
                break;
        }
    }

    public enum GameModes
    {
        Story3D,
        Procedural3D,
        Story2D,
        Sample,
    }
}
