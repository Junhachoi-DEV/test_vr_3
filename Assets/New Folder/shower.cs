using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shower : MonoBehaviour
{
    public Transform[] cur_transforms;
    Transform[] next_transforms;
    
    void Start()
    {
        next_transforms = cur_transforms;
        Debug.Log(cur_transforms);
    }

    public void reset_pos()
    {
        for (int i = 0; i < cur_transforms.Length; i++)
        {
            cur_transforms[i].position = next_transforms[i].position;
            Debug.Log(cur_transforms[i].position);
        }
    }
}
