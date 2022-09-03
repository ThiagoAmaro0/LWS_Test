using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : Interactable
{
    [SerializeField] private string _scene;
    public override void OnInteract()
    {
        print("LAU");
        if (_stay)
        {
            SceneManager.LoadScene(_scene);
        }
    }
}
