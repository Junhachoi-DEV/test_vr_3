using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_reset_pos : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Untagged"))
        {
            other.transform.position = Vector3.zero;
        }
    }
}
