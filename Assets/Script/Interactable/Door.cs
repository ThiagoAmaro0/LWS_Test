using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : Interactable
{
    [SerializeField] private string _scene;
    [SerializeField] private Vector2 _startPos;
    public override void OnInteract()
    {
        if (_stay && Time.timeScale != 0)
        {
            FadeManager.instance.Fade(false, () =>
            {
                _other.transform.position = _startPos;
                SceneManager.LoadScene(_scene);
            });
        }
    }
}
