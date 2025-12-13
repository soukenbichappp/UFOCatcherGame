using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Cysharp.Threading.Tasks;
using System;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private PlayerView _playerView;
    [SerializeField] private GameObject _laserPrefab;
    [SerializeField] private float _laserDuration = 3f;

    private UFOInput _ufoInput;
    private Vector2 _inputDirection;
    private float _inputMouseX;

    void Awake()
    {
        _ufoInput = new UFOInput();
        _ufoInput.Enable();
    }

    public void OnDisable()
    {
        _ufoInput.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        _inputDirection = _ufoInput.Player.Move.ReadValue<Vector2>();
        _inputMouseX = Input.GetAxis("Mouse X");

        if (_inputDirection != Vector2.zero)
        {
            _playerView.PlayerMove(_inputDirection);
        }

        if (Mathf.Abs(_inputMouseX) > 0.1f)
        {
            _playerView.PlayerRotate(_inputMouseX);
        }

        if (_ufoInput.Player.Laser.triggered)
        {
            ShotLaser();
        }
    }

    private async void ShotLaser()
    {
        // åıê¸Çî≠éÀÇ∑ÇÈèàóù
        _laserPrefab.gameObject.SetActive(true);
        await UniTask.Delay(TimeSpan.FromSeconds(_laserDuration));
        _laserPrefab.gameObject.SetActive(false);
    }

    
}
