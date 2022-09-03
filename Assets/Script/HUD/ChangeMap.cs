using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeMap : MonoBehaviour
{
    [SerializeField] private string _scene;
    [SerializeField] private Vector2 _startPos;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<PlayerMovement>(out PlayerMovement _inv))
        {
            other.transform.position = _startPos;
            SceneManager.LoadScene(_scene);
        }
    }
}
