using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class shower : MonoBehaviour
{

    public Vector3 reset_transforms;
    public Transform transforms;
    

    public void reset_pos()
    {
        transforms.position = reset_transforms;
    }
}
