using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeManager : MonoBehaviour
{
    [SerializeField, Header("フェードさせたいキャンバスをアタッチ")] private CanvasGroup _fadeCanvasGroup;
    [SerializeField, Header("フェードインにかかる時間")] private float _fadeInSpeed = 1.0f;
    [SerializeField, Header("フェードアウトにかかる時間")] private float _fadeOutSpeed = 1.0f;

    private bool _isFading = false;

    public void FadeIn()
    {
        if (_isFading) return;
        _isFading = true;

        DOVirtual.Float(
            _fadeCanvasGroup.alpha,
            0,
            _fadeInSpeed,
            alpha => _fadeCanvasGroup.alpha = alpha
        ).OnComplete(() => _isFading = false);        
    }

    public void FadeOut()
    {
        if (_isFading) return;
        _isFading = true;

        DOVirtual.Float(
            _fadeCanvasGroup.alpha,
            1,
            _fadeOutSpeed,
            alpha => _fadeCanvasGroup.alpha = alpha
        ).OnComplete(() =>
        { _isFading = false;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        });
    }
}
