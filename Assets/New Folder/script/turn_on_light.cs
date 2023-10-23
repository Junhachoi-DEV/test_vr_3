using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turn_on_light : MonoBehaviour
{
    public AudioSource sfx;
    public GameObject[] lights;
    public MeshRenderer[] lightRenderer;
    public Material[] light_material;
    public Material nolight_material;

    bool is_turn;
    int num;

    private void OnTriggerEnter(Collider other)
    {
        if (gameObject.CompareTag("Untagged") && num <= 0)
        {
            sfx.Play();
            is_turn = !is_turn;
            for (int i = 0; i< lightRenderer.Length; i++)
            {
                if (is_turn) { lightRenderer[i].material = light_material[i]; }
                else { lightRenderer[i].material = nolight_material; }
            }
            
            for (int i = 0; i < lights.Length; i++)
            {
                lights[i].SetActive(is_turn);
            }
            num++;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (gameObject.CompareTag("Untagged"))
        {
            num = 0;
        }
    }
}
