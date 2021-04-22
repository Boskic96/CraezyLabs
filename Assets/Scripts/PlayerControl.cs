using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [SerializeField]
    private float speed;

    private void FixedUpdate()
    {
        var movingTarget = transform.position + transform.forward;
        transform.position = Vector3.Lerp(transform.position, movingTarget, speed);
    }
}
