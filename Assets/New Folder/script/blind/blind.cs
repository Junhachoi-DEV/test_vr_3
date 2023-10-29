using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blind : MonoBehaviour
{
    public GameObject bottom;
    public Transform start_pos;
    public Transform end_pos;

    public float speed;

    void Start()
    {
        bottom.transform.position = start_pos.position;
    }

    void Update()
    {
        blind_controller();
    }

    public void blind_controller()
    {
        if(Input.GetMouseButton(0) && bottom.transform.position.y > end_pos.position.y)
        {
            bottom.transform.Translate(Vector3.down * speed * Time.deltaTime);
        }
        else if (Input.GetMouseButton(1) && bottom.transform.position.y < start_pos.position.y)
        {
            bottom.transform.Translate(Vector3.up * speed * Time.deltaTime);
        }
    }
}
