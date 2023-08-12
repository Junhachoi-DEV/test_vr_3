using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paint_spring_cont : MonoBehaviour
{
    UnityChan.SpringManager springManager;

    void Start()
    {
        springManager = GetComponentInParent<UnityChan.SpringManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Untagged"))
        {
            springManager.stiffnessForce = 0f;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Untagged"))
        {
            springManager.stiffnessForce = 1f;
        }
    }
}
