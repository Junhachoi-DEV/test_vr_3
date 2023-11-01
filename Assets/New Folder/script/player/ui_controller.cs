using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ui_controller : MonoBehaviour
{
    public GameObject[] ui_s;
    public Transform menu_child_pos;
    public Transform option_child_pos;

    public void option_pos()
    {
        ui_s[1].transform.position = menu_child_pos.position;
        ui_s[1].transform.rotation = menu_child_pos.rotation;
    }
    public void ch_hand_pos()
    {
        ui_s[2].transform.position = option_child_pos.position;
        ui_s[2].transform.rotation = option_child_pos.rotation;
    }
    public void volume_pos()
    {
        ui_s[3].transform.position = option_child_pos.position;
        ui_s[3].transform.rotation = option_child_pos.rotation;
    }
    public void explain_pos()
    {
        ui_s[4].transform.position = menu_child_pos.position;
        ui_s[4].transform.rotation = menu_child_pos.rotation;
    }
}
