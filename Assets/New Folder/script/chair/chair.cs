using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chair : MonoBehaviour
{
    public GameObject[] chair_parts;
    public GameObject[] next_chir_parts;


    int part_num;
    public int count_num;

    public bool is_touch;

    public void chair_part_active(bool value)
    {
        if (count_num < chair_parts.Length-1)
        {
            next_chir_parts[count_num].SetActive(value);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("chair_part")&& is_touch)
        {
            part_num = other.GetComponent<chair_part>().part_num;
            if (part_num == count_num)
            {
                chair_parts[part_num].SetActive(true);
                next_chir_parts[part_num].SetActive(false);
                if (count_num < chair_parts.Length-1) { count_num++; } else { return; }
                next_chir_parts[count_num].SetActive(true);
            }
        }
    }


    public void is_touch_bool(bool value)
    {
        is_touch = value;
    }
}
