using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paint_can : MonoBehaviour
{
    public Material[] mat;
    MeshRenderer mesh_r;
    SkinnedMeshRenderer skinned_mech_r;

    public CollisionPainter collision_r;

    private void Start()
    {
        mesh_r = GetComponent<MeshRenderer>();
        skinned_mech_r =GetComponent<SkinnedMeshRenderer>();
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("paint_drump_red"))
        {
            if (mesh_r) { mesh_r.material = mat[0]; }
            else if(skinned_mech_r) { skinned_mech_r.material = mat[0]; }

            collision_r.paintColor = mat[0].color;
        }
        else if (other.CompareTag("paint_drump_erase"))
        {
            if (mesh_r) { mesh_r.material = mat[2]; } //basic color
            else if (skinned_mech_r) { skinned_mech_r.material = mat[2]; }

            collision_r.paintColor = mat[1].color;
        }
    }

    public void paint_reset()
    {

    }
}
