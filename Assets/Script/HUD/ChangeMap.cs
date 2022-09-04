using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeMap : MonoBehaviour
{
    [SerializeField] private string _scene;
    [SerializeField] private Vector2 _startPos;

    public static Action<string> changeSceneAction;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<PlayerMovement>(out PlayerMovement _inv))
        {
            changeSceneAction?.Invoke(_scene);
            other.transform.position = _startPos;
            SceneManager.LoadScene(_scene);
        }
    }
}
