using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogSystem : MonoBehaviour
{

    [SerializeField] private GameObject _dialogPanel;
    [SerializeField] private TextMeshProUGUI _text;
    private Queue<string> _msg;
    public static DialogSystem instance;

    private void Awake()
    {
        instance = this;
    }

    public void StartDialog(string[] msg)
    {
        print("START");
        Time.timeScale = 0;
        _msg = new Queue<string>(msg);
        _dialogPanel.SetActive(true);
        _text.text = _msg.Dequeue();
    }

    public void NextDialog()
    {
        if (_msg.Count > 0)
        {
            _text.text = _msg.Dequeue();
        }
        else
        {
            Time.timeScale = 1;
            _dialogPanel.SetActive(false);
        }
    }
}
