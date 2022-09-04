using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    [SerializeField] protected GameObject inputIcon;
    protected Transform _other;
    protected bool _stay;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<PlayerInventory>(out PlayerInventory _inv))
        {
            _stay = true;
            _other = other.transform;
            inputIcon.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.TryGetComponent<PlayerInventory>(out PlayerInventory _inv))
        {
            _stay = false;
            _other = null;
            inputIcon.SetActive(false);
        }
    }

    public abstract void OnInteract();
}
