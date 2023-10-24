using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paint_can : MonoBehaviour
{
    public AudioSource[] audioSources;
    public Material[] mat;
    MeshRenderer mesh_r;
    SkinnedMeshRenderer skinned_mech_r;

    public CollisionPainter collision_r;

    private void Start()
    {
        mesh_r = GetComponent<MeshRenderer>();
        skinned_mech_r =GetComponent<SkinnedMeshRenderer>();
        mat[mat.Length - 1].color = Color.black;
        mat[0].color = Color.white;
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("paint_drump_red"))
        {
            mat[0].color = mat[mat.Length-1].color;
            if (mesh_r) { mesh_r.material = mat[0]; }
            else if(skinned_mech_r) { skinned_mech_r.material = mat[0]; }

            collision_r.paintColor = mat[0].color;
            audioSources[0].Play();
        }
        else if (other.CompareTag("paint_drump_erase"))
        {
            if (mesh_r) { mesh_r.material = mat[2]; } //basic color
            else if (skinned_mech_r) { skinned_mech_r.material = mat[2]; }

            collision_r.paintColor = mat[1].color;
            audioSources[1].Play();
        }
        else if (other.CompareTag("paint_wall"))
        {
            audioSources[2].Play();
        }
    }

    public void paint_reset()
    {

    }
}
