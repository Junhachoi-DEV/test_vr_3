using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class locomotion_controller : MonoBehaviour
{
    public XRController left_teleport_ray;
    public XRController right_teleport_ray;
    public InputHelpers.Button teleport_activation_button;
    public float activation_threshold = 0.1f;

    public XRRayInteractor left_interactor_ray;
    public XRRayInteractor right_interactor_ray;

    public bool enable_left_teleport { get; set; } = true;
    public bool enable_right_teleport { get; set; }= true;

    public bool is_hand_change;

    void Update()
    {
        Vector3 pos = new Vector3();
        Vector3 normal = new Vector3();
        int index = 0;
        bool valid_target = false;

        if (left_teleport_ray && !is_hand_change)
        {
            bool is_left_interactor_ray_hovering = left_interactor_ray.TryGetHitInfo(out pos, out normal, out index, out valid_target);
            left_teleport_ray.gameObject.SetActive(enable_left_teleport &&
                check_if_activated(left_teleport_ray));
        }
        else if (right_teleport_ray && is_hand_change)
        {
            bool is_right_interactor_ray_hovering = right_interactor_ray.TryGetHitInfo(out pos, out normal, out index, out valid_target);
            right_teleport_ray.gameObject.SetActive(enable_right_teleport &&
                check_if_activated(right_teleport_ray));
        }
    }

    public bool check_if_activated(XRController controller)
    {
        InputHelpers.IsPressed(controller.inputDevice, teleport_activation_button, out bool is_actiated, activation_threshold);
        return is_actiated;
    }

    public void is_hand_changer(bool value)
    {
        is_hand_change = value;
    }
}
