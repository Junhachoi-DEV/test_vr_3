using UnityEngine;

public class water_on : MonoBehaviour
{

    public GameObject switch_pos;
    public float _off = 0.2f;

    public GameObject particle_obj;

    bool is_touch;
    private void Update()
    {
        if (is_touch)
        {
            Vector3 rotation = switch_pos.transform.rotation.eulerAngles;
            if (rotation.x <= _off)
            {
                particle_obj.SetActive(false);
            }
            else
            {
                particle_obj.SetActive(true);
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Untagged"))
        {
            is_touch = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Untagged"))
        {
            is_touch = false;
        }
    }
}
