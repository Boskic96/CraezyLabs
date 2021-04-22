using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [SerializeField]
    private float speed;

    private Vector3 touchPosition;

    private void OnEnable()
    {
        TouchControls.PlayerInput += MovePlayer;
    }

    private void OnDisable()
    {
        TouchControls.PlayerInput -= MovePlayer;
    }

    private void FixedUpdate()
    {
        var movingTarget = transform.position + transform.forward;
        transform.position = Vector3.Lerp(transform.position, movingTarget, speed);
    }

    private void MovePlayer(Vector3 touchPosition)
    {
        this.touchPosition = touchPosition;
    }
}
