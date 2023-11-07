using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class tutorial_goal : MonoBehaviour
{
    tutorial _tutorial;
    int num;
    bool is_touch;

    private void Awake()
    {
        num = 0;
        _tutorial = FindObjectOfType<tutorial>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !is_touch)
        {
            _tutorial.xr_origin.transform.position = Vector3.zero;
            _tutorial.goal_sfx.Play();
            tuoched_check(num);
            num++;
            is_touch = true;
            Invoke("cool_time", 0.2f);
        }
    }
    void cool_time()
    {
        is_touch = false;
    }
    void tuoched_check(int value)
    {
        _tutorial.ui_s[value+1].SetActive(true);


        switch (value)
        {
            case 0:
                _tutorial.xr_origin.GetComponent<TeleportationProvider>().enabled = true;
                _tutorial.xr_origin.GetComponent<locomotion_controller>().enabled = true;
                _tutorial.tele_area.SetActive(true);
                break;
            case 1:
                _tutorial.tele_area.SetActive(false);
                _tutorial.cube1.SetActive(true);
                _tutorial.cube2.SetActive(true);
                break;
            case 2:
                _tutorial.cube1.SetActive(false);
                _tutorial.cube2.SetActive(false);
                _tutorial.xr_origin.GetComponent<player_ui_controller>().enabled = true;
                _tutorial.left_ray.GetComponent<XRInteractorLineVisual>().enabled = true;
                _tutorial.right_ray.GetComponent<XRInteractorLineVisual>().enabled = true;
                break;
            case 3:
                _tutorial.start_icon.SetActive(true);
                break;
            default:
                num = 3;
                break;
        }

    }
}
