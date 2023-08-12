using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chuck_roller : MonoBehaviour
{
    public bool is_grab;
    public float speed;
    float rotate_speed;
    private void Update()
    {
        obj_rotate();
    }


    public void obj_rotate()
    {
        if (Input.GetButton("XRI_Right_TriggerButton") && is_grab)
        {
            rotate_speed += speed;
            transform.localRotation = Quaternion.Euler(rotate_speed, 0f, 90f);
        }
    }

    public void grab_true()
    {
        is_grab = true;
    }
    public void grab_false()
    {
        is_grab = false;
    }
}
