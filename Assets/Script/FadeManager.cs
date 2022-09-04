using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class FadeManager : MonoBehaviour
{
    [SerializeField] private Image _fadeImage;
    public static FadeManager instance;

    private void Awake()
    {
        instance = this;
        _fadeImage.color = new Color(0.22f, 0.22f, 0.22f, 1);
        StartCoroutine(ChangeAlpha(0, null));
    }

    public void Fade(bool isOut, UnityAction endAction)
    {
        _fadeImage.color = new Color(0.22f, 0.22f, 0.22f, isOut ? 1 : 0);
        StartCoroutine(ChangeAlpha(isOut ? 0 : 1, endAction));
    }
    private IEnumerator ChangeAlpha(float target, UnityAction endAction)
    {
        Time.timeScale = 0;
        _fadeImage.gameObject.SetActive(true);
        float dir = target - _fadeImage.color.a;
        while (_fadeImage.color.a != target)
        {
            _fadeImage.color += new Color(0, 0, 0, dir / 120);
            if (_fadeImage.color.a < 0)
                _fadeImage.color = new Color(0.22f, 0.22f, 0.22f, 0);
            if (_fadeImage.color.a > 1)
                _fadeImage.color = new Color(0.22f, 0.22f, 0.22f, 1);

            yield return new WaitForEndOfFrame();
        }
        endAction?.Invoke();
        _fadeImage.gameObject.SetActive(false);
        Time.timeScale = 1;
    }
}
