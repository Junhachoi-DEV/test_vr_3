using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paint_for_skined : MonoBehaviour
{
    public Material[] mat;
    SkinnedMeshRenderer skinned_r;

    private void Start()
    {
        skinned_r = GetComponent<SkinnedMeshRenderer>();
        gameObject.layer = 10;
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("paint_drump_red"))
        {
            
            skinned_r.material = mat[0];
            gameObject.layer = 13;
        }
        else if (other.CompareTag("paint_drump_green"))
        {
            
            skinned_r.material = mat[1];
            gameObject.layer = 13;

        }
        else if (other.CompareTag("paint_drump_blue"))
        {
            
            skinned_r.material = mat[2];

            gameObject.layer = 13;
        }
        else if (other.CompareTag("paint_drump_white"))
        {
            
            skinned_r.material = mat[3];

            gameObject.layer = 13;
        }
        else if (other.CompareTag("paint_drump_black"))
        {
            
            skinned_r.material = mat[4];
            gameObject.layer = 13;
        }
    }
}
