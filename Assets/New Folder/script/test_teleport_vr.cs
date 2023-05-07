using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test_teleport_vr : MonoBehaviour
{
    public GameObject teleportIndicatorPrefab; // The prefab of the teleportation indicator
    public Transform cameraRig; // The transform of the camera rig
    public Transform head; // The transform of the player's head
    public float maxDistance = 10.0f; // The maximum distance that the player can teleport
    public LayerMask teleportLayerMask; // The layer mask for valid teleport locations

    private GameObject teleportIndicator; // The teleportation indicator object
    private Vector3 teleportLocation; // The current teleport location
    private bool canTeleport = false; // Whether the player can currently teleport

    void Update()
    {
        // Check if the player is pressing the teleport button (in this case, the A button on the Oculus Touch controller)
        if (Input.GetButtonDown("Teleport"))
        {
            RaycastHit hit;
            if (Physics.Raycast(head.position, head.forward, out hit, maxDistance, teleportLayerMask))
            {
                canTeleport = true;
                teleportLocation = hit.point;
                if (teleportIndicator == null)
                {
                    teleportIndicator = Instantiate(teleportIndicatorPrefab);
                }
                teleportIndicator.SetActive(true);
                teleportIndicator.transform.position = teleportLocation;
            }
        }

        // Check if the player has released the teleport button
        if (Input.GetButtonUp("Teleport") && canTeleport)
        {
            cameraRig.position = new Vector3(teleportLocation.x, cameraRig.position.y, teleportLocation.z);
            teleportIndicator.SetActive(false);
            canTeleport = false;
        }

        // Check if the player has cancelled the teleportation (in this case, the B button on the Oculus Touch controller)
        if (Input.GetButtonDown("CancelTeleport") && canTeleport)
        {
            teleportIndicator.SetActive(false);
            canTeleport = false;
        }
    }
}
