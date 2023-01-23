using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTeleport : MonoBehaviour
{
    public Transform teleportPoint;

    void OnTriggerEnter(Collider collision)
    {
        ProcessTeleportCollision(collision.gameObject);
    }

    void ProcessTeleportCollision(GameObject collider)
    {
        if (collider.CompareTag("Teleporter"))
        {
            transform.position = teleportPoint.position;
            Debug.Log("Teleport!");
        }
    }
}
