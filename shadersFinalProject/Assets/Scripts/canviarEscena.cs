using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class canviarEscena : MonoBehaviour
{
    CineScript manager;

    private void Start()
    {
        manager = FindFirstObjectByType<CineScript>();
        while (manager == null)
        {
            manager = FindFirstObjectByType<CineScript>();
        }
    }

    private void Update()
    {
        
    }

    public void change()
    {
        manager.changeScene();
    }
}
