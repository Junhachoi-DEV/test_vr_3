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

        gameObject.layer = 10;
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("paint_drump_red"))
        {
            if (mesh_r) { mesh_r.material = mat[0]; }
            else if(skinned_mech_r) { skinned_mech_r.material = mat[0]; }

            collision_r.paintColor = mat[0].color;
            //gameObject.layer = 13;
        }
        //else if (other.CompareTag("paint_drump_green"))
        //{
        //    if (mesh_r) { mesh_r.material = mat[1]; }
        //    else if (skinned_mech_r) { skinned_mech_r.material = mat[1]; }

        //    collision_r.paintColor = mat[1].color;
        //    gameObject.layer = 13;
        //}
        //else if(other.CompareTag("paint_drump_blue"))
        //{
        //    if (mesh_r) { mesh_r.material = mat[2]; }
        //    else if (skinned_mech_r) { skinned_mech_r.material = mat[2]; }

        //    collision_r.paintColor = mat[2].color;
        //    gameObject.layer = 13;
        //}
        //else if (other.CompareTag("paint_drump_white"))
        //{
        //    if (mesh_r) { mesh_r.material = mat[3]; }
        //    else if (skinned_mech_r) { skinned_mech_r.material = mat[3]; }

        //    collision_r.paintColor = mat[3].color;
        //    gameObject.layer = 13;
        //}
        //else if (other.CompareTag("paint_drump_black"))
        //{
        //    if (mesh_r) { mesh_r.material = mat[4]; }
        //    else if (skinned_mech_r) { skinned_mech_r.material = mat[4]; }

        //    collision_r.paintColor = mat[4].color;
        //    gameObject.layer = 13;
        //}
        else if (other.CompareTag("paint_drump_erase"))//5
        {
            if (mesh_r) { mesh_r.material = mat[1]; }
            else if (skinned_mech_r) { skinned_mech_r.material = mat[1]; }

            collision_r.paintColor = mat[1].color;
            //gameObject.layer = 13;
        }
    }

    public void paint_reset()
    {

    }
}
