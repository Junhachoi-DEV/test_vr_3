using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fruits : MonoBehaviour
{
    public GameObject[] parts;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("knife"))
        {
            for (int i = 0; i < parts.Length; i++)
            {
                parts[i].SetActive(true);
                parts[i].transform.position = gameObject.transform.position;
            }
            gameObject.SetActive(false);
        }
    }
}
