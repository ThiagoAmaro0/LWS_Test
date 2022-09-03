using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    [SerializeField] protected GameObject inputIcon;
    protected bool _stay;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<PlayerInventory>(out PlayerInventory _inv))
        {
            _stay = true;
            inputIcon.SetActive(true);
            print("STAY");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.TryGetComponent<PlayerInventory>(out PlayerInventory _inv))
        {
            _stay = false;
            inputIcon.SetActive(false);
            print("STAY");
        }
    }

    public abstract void OnInteract();
}
