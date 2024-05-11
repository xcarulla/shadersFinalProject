using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CineScript : MonoBehaviour
{

    private static CineScript instance;

    private static List<string> llistaEscenes = new List<string> { "Tele", "HUB", "DotMatrixScene", "HUB", "DisolveScene" };
    private static List<Color> llistaColors   = new List<Color>  { Color.cyan, Color.red, Color.green, Color.magenta, Color.cyan };

    private int currentScene = 0;

    public Material portalMat;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void changeScene()
    {
        string sceneName = llistaEscenes[currentScene];
        Color colorPortal = llistaColors[currentScene];
        portalMat.SetColor("_BaseColor", colorPortal);
        currentScene++;
        SceneManager.LoadScene(sceneName);
    }
}
