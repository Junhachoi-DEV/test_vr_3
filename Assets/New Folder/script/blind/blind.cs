using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blind : MonoBehaviour
{
    public GameObject bottom;
    public Transform start_pos;
    public Transform end_pos;

    public float speed;
    bool is_up_down;
    bool is_touched;
    int num;

    void Update()
    {
        blind_controller();
    }

    public void blind_controller()
    {
        if(is_touched && is_up_down && bottom.transform.position.y > end_pos.position.y)
        {
            bottom.transform.Translate(Vector3.down * speed * Time.deltaTime);
        }
        else if (is_touched && !is_up_down && bottom.transform.position.y < start_pos.position.y)
        {
            bottom.transform.Translate(Vector3.up * speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (gameObject.CompareTag("Untagged") && num <=0)
        {
            is_touched = true;
            is_up_down = !is_up_down;
            num++; //�ѹ��� ����
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (gameObject.CompareTag("Untagged"))
        {
            is_touched = false;
            num= 0;
        }
    }
}
