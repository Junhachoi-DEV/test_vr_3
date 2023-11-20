using UnityEngine;

public class coffee_port : MonoBehaviour
{
    public GameObject coffee_water_obj;
    public AudioSource coffee_m_sound;

    public bool is_microrange;
    bool is_clicked;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Untagged") && !is_clicked)
        {
            coffee_water_obj.SetActive(true);
            coffee_m_sound.Play();
            Invoke("deactivate_coffee", is_microrange ? 15f : 5f);
            is_clicked = true;
        }
    }
    public void deactivate_coffee()
    {
        coffee_water_obj.SetActive(false);
        coffee_m_sound.Stop();
        is_clicked = false;
    }
}
