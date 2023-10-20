using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chair_part2 : MonoBehaviour
{
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("chair_main"))
        {
            gameObject.SetActive(false);
        }
    }
}
