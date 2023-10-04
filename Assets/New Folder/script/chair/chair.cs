using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chair : MonoBehaviour
{
    public GameObject[] chair_parts;

    int part_num;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("chair_part"))
        {
            part_num = other.GetComponent<chair_part>().part_num;
            chair_parts[part_num].SetActive(true);
        }
    }
}
