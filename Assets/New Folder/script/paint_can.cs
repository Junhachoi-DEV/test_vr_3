using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paint_can : MonoBehaviour
{
    public Material[] mat;
    MeshRenderer mesh_r;

    private void Start()
    {
        mesh_r = GetComponent<MeshRenderer>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("paint_drump_red"))
        {
            mesh_r.material = mat[0];
        }
        else if (other.CompareTag("paint_drump_green"))
        {
            mesh_r.material = mat[1];
        }
        else if(other.CompareTag("paint_drump_blue"))
        {
            mesh_r.material = mat[2];
        }
    }
}
