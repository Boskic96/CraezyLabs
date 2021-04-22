using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    private float xOffset;

    [SerializeField]
    private float yOffset;

    [SerializeField]
    private float zOffset;

    private PlayerControl player;

    private void Start()
    {
        player = FindObjectOfType<PlayerControl>();
    }

    private void LateUpdate()
    {
        var target = new Vector3(player.transform.position.x + xOffset, player.transform.position.y + yOffset, player.transform.position.z + zOffset);
        transform.position = target;
    }
}
