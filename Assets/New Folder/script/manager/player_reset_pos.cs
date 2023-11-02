using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_reset_pos : MonoBehaviour
{
    public Transform player_pos;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Untagged"))
        {
            other.transform.position = player_pos.position;
        }
    }
}
