using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House : Interactable
{
    public static Action nextDay;
    public override void OnInteract()
    {
        if (_stay)
        {
            PopupManager.instance.ShowPopup("Do you Want to sleep?", () => FadeManager.instance.Fade(false, () =>
            {
                nextDay?.Invoke();
                FadeManager.instance.Fade(true, () => { });
            }), true);
        }
    }
}
