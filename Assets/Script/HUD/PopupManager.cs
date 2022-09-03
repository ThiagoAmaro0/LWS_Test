using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PopupManager : MonoBehaviour
{
    [SerializeField] private GameObject _popUpPanel;
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private Button _yesButton;
    public static PopupManager instance;

    private void Awake()
    {
        instance = this;
    }

    public void ShowPopup(string msg, UnityAction yesAction, bool canAccept)
    {
        Time.timeScale = 0;
        _yesButton.onClick.RemoveAllListeners();
        _yesButton.onClick.AddListener(yesAction);
        _yesButton.onClick.AddListener(() => _popUpPanel.SetActive(false));
        _yesButton.onClick.AddListener(() => Time.timeScale = 1);
        _yesButton.interactable = canAccept;
        _text.text = msg;
        _popUpPanel.SetActive(true);
    }

    public void ClosePopup()
    {
        Time.timeScale = 1;
        _popUpPanel.SetActive(false);
    }

}
