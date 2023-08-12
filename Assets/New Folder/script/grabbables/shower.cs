using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class shower : MonoBehaviour
{

    public Transform reset_transforms;
    

    public void reset_pos()
    {
        transform.position = reset_transforms.position;
    }
}
