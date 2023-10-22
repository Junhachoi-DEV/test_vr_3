using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chair_part : MonoBehaviour
{
    public int part_num;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("chair_main"))
        {
            chair _chair = other.GetComponentInParent<chair>();
            if (_chair.is_touch && _chair.count_num == part_num)
            {
                gameObject.SetActive(false);
            }
        }
    }
    
}
