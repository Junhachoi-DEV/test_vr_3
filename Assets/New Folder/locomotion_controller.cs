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

    // Update is called once per frame
    void Update()
    {
        if (left_teleport_ray)
        {
            left_teleport_ray.gameObject.SetActive(check_if_activated(left_teleport_ray));
        }
    }

    public bool check_if_activated(XRController controller)
    {
        InputHelpers.IsPressed(controller.inputDevice, teleport_activation_button, out bool is_actiated, activation_threshold);
        return is_actiated;
    }
}
