using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerView : MonoBehaviour
{
    [SerializeField] private float _playerMoveSpeed = 5f;

    public void PlayerMove(Vector2 direction)
    {
        Vector3 moveDirection = new Vector3(direction.x, 0, direction.y);
        transform.Translate(moveDirection * Time.deltaTime * _playerMoveSpeed);
    }

    public void PlayerRotate(float mouseX)
    {
        transform.Rotate(Vector3.up, mouseX);
    }
}
