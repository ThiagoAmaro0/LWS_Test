using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialog : Interactable
{
    [SerializeField] private string[] _dialogText;
    [SerializeField] private string _lastDialogText;
    private bool _started;
    public override void OnInteract()
    {
        if (_stay && Time.timeScale != 0)
        {
            print("interact");
            DialogSystem.instance.StartDialog(!_started ? _dialogText : new string[] { _lastDialogText });
            _started = true;
        }
    }
}
