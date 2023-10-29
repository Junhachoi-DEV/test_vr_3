using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blind : MonoBehaviour
{
    public GameObject bottom;
    public Transform start_pos;
    public Transform end_pos;
    public AudioSource sfx;
    public float speed;
    bool is_up_down;
    bool is_touched;
    bool is_moving;
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

        if((bottom.transform.position.y <= end_pos.position.y || bottom.transform.position.y >= start_pos.position.y) && is_moving)
        {
            sfx.Stop();
            is_moving = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (gameObject.CompareTag("Untagged") && num <=0)
        {
            is_moving = true;
            sfx.Play();
            is_touched = true;
            is_up_down = !is_up_down;
            num++; //한번만 실행
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (gameObject.CompareTag("Untagged"))
        {
            sfx.Stop();
            is_touched = false;
            is_moving = false;
            num = 0;
        }
    }
}
