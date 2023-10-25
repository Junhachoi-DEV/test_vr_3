using UnityEngine;
using UnityEngine.XR;
using Unity.XR.CoreUtils; // xrrig는 이제 안쓴다고 한다. //이거 추가해야 xrorigin쓸수 있음

public class continuous_movement : MonoBehaviour
{
    public float speed;
    public XRNode input_source;
    public float gravity = -9.81f;
    public LayerMask ground_layer;
    public float additional_height = 0.2f;


    private float falling_speed;
    private XROrigin rig;
    private Vector2 input_axis;
    private CharacterController character;

    
    void Start()
    {
        character = GetComponent<CharacterController>();
        rig = GetComponent<XROrigin>();
    }

    // Update is called once per frame
    void Update()
    {
        InputDevice device = InputDevices.GetDeviceAtXRNode(input_source);
        device.TryGetFeatureValue(CommonUsages.primary2DAxis, out input_axis);
    }

    private void FixedUpdate()
    {
        capsule_follow_headset();

        Quaternion head_dir = Quaternion.Euler(0, rig.Camera.transform.eulerAngles.y, 0);
        Vector3 dir = head_dir * new Vector3(input_axis.x, 0, input_axis.y);

        character.Move(dir * Time.fixedDeltaTime * speed);

        //gravity
        bool is_ground = check_if_ground();
        if (is_ground)
        {
            falling_speed = 0;
        }
        else
        {
            falling_speed += gravity * Time.fixedDeltaTime;
        }
        character.Move(Vector3.up * falling_speed * Time.fixedDeltaTime);
    }

    void capsule_follow_headset()
    {
        character.height = rig.CameraInOriginSpaceHeight + additional_height;
        Vector3 capsule_center = transform.InverseTransformPoint(rig.Camera.transform.position);
        character.center = new Vector3(capsule_center.x, character.height/2 + character.skinWidth, capsule_center.z);
    }


    bool check_if_ground()
    {
        Vector3 ray_start = transform.TransformPoint(character.center);
        float ray_length = character.center.y + 0.01f;
        
        bool has_hit = Physics.SphereCast(ray_start,
            character.radius,
            Vector3.down,
            out RaycastHit hit_info,
            ray_length,
            ground_layer);

        return has_hit; //레이값을 반환
    }
}
