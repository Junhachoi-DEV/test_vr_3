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
        gameObject.layer = 10;
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("paint_drump_red"))
        {
            mesh_r.material = mat[0];
            gameObject.layer = 13;
        }
        else if (other.CompareTag("paint_drump_green"))
        {
            mesh_r.material = mat[1];
            gameObject.layer = 13;

        }
        else if(other.CompareTag("paint_drump_blue"))
        {
            mesh_r.material = mat[2];
            gameObject.layer = 13;
        }
        else if (other.CompareTag("paint_drump_white"))
        {
            mesh_r.material = mat[3];
            gameObject.layer = 13;
        }
        else if (other.CompareTag("paint_drump_black"))
        {
            mesh_r.material = mat[4];
            gameObject.layer = 13;
        }
    }

    public void paint_reset()
    {

    }
}
