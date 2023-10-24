using UnityEngine;

public class outside_window : MonoBehaviour
{
    public Transform respwan_pos;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Untagged") || other.CompareTag("chair_main") || other.CompareTag("chair_part"))
        {
            if (other.GetComponent<Rigidbody>() != null)
            {
                other.GetComponent<Rigidbody>().velocity = Vector3.zero;
                if(other.GetComponentInChildren<Rigidbody>() != null)
                {
                    other.GetComponentInChildren<Rigidbody>().velocity = Vector3.zero;
                }
                other.gameObject.transform.position = respwan_pos.position;
            }
            else
            {
                other.GetComponentInParent<Rigidbody>().velocity = Vector3.zero;
                other.gameObject.transform.parent.position = respwan_pos.position;
            }
            
        }
    }
}
