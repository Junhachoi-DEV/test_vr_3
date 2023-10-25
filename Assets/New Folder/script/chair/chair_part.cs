using UnityEngine;

public class chair_part : MonoBehaviour
{
    public int part_num;
    public bool is_attach;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("chair_main") && !is_attach)
        {
            chair _chair = other.GetComponentInParent<chair>();
            if (_chair.is_touch && _chair.count_num == part_num)
            {
                gameObject.SetActive(false);
            }
        }
    }
    
}
