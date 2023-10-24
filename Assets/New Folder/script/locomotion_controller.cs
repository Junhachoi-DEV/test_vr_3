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

    public XRRayInteractor left_interactor_ray;
    public XRRayInteractor right_interactor_ray;

    public bool enable_left_teleport { get; set; } = true;
    //public bool enable_right_teleport { get; set; }= true;

    void Update()
    {
        Vector3 pos = new Vector3();
        Vector3 normal = new Vector3();
        int index = 0;
        bool valid_target = false;


        if (left_teleport_ray)
        {
            bool is_left_interactor_ray_hovering = left_interactor_ray.TryGetHitInfo(out pos, out normal, out index, out valid_target);
            left_teleport_ray.gameObject.SetActive(enable_left_teleport &&
                check_if_activated(left_teleport_ray) &&
                !is_left_interactor_ray_hovering);
        }

    }

    public bool check_if_activated(XRController controller)
    {
        InputHelpers.IsPressed(controller.inputDevice, teleport_activation_button, out bool is_actiated, activation_threshold);
        return is_actiated;
    }
}
