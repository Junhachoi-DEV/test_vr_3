using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class locomotion_controller : MonoBehaviour
{
    public XRController left_teleport_ray;
    //public XRController right_teleport_ray;
    public InputHelpers.Button teleport_activation_button;
    public float activation_threshold = 0.1f;

    public bool enable_left_teleport { get; set; } = true;
    //public bool enable_right_teleport = true;


    void Update()
    {
        if (left_teleport_ray)
        {
            left_teleport_ray.gameObject.SetActive(enable_left_teleport && check_if_activated(left_teleport_ray));
        }
    }

    public bool check_if_activated(XRController controller)
    {
        InputHelpers.IsPressed(controller.inputDevice, teleport_activation_button, out bool is_actiated, activation_threshold);
        return is_actiated;
    }
}
