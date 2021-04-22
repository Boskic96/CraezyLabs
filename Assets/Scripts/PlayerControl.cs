using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [SerializeField]
    private float speed;

    [SerializeField]
    private float forceX;

    [SerializeField]
    private float maximumPixelDistance;

    private Vector3 touchPosition;

    private void OnEnable()
    {
        TouchControls.PlayerInput += GetTouchInput;
    }

    private void OnDisable()
    {
        TouchControls.PlayerInput -= GetTouchInput;
    }

    private void FixedUpdate()
    {
        var movingTarget = transform.position + transform.forward;
        movingTarget = new Vector3((movingTarget.x + touchPosition.x), movingTarget.y, movingTarget.z);

        transform.position = Vector3.Lerp(transform.position, movingTarget, speed);
    }

    private void GetTouchInput(Vector2 touchPosition)
    {
        if(touchPosition.x < -maximumPixelDistance)
        {
            touchPosition = new Vector2(-maximumPixelDistance, touchPosition.y);
        }
        else if(touchPosition.x > maximumPixelDistance)
        {
            touchPosition = new Vector2(maximumPixelDistance, touchPosition.y);
        }

        this.touchPosition = touchPosition / 500 * forceX;
    }
}
