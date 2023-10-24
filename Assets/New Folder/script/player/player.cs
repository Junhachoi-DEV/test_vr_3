using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using static UnityEditor.Experimental.GraphView.GraphView;

public class player : MonoBehaviour
{
    public AudioSource[] audioSources;
    public GameObject menu;
    public GameObject tools_menu;
    public GameObject[] tools;
    public Transform menu_pos;
    public Transform tools_menu_pos;
    public Transform[] tools_pos;

    bool is_open_menu;
    bool is_tools_open;

    private void Update()
    {
        open_menu();
        open_tool_menu();
    }

    void open_menu()
    {
        if (Input.GetButtonDown("XRI_Left_PrimaryButton") && !is_open_menu)
        {
            audioSources[0].Play();
            menu.transform.position = menu_pos.position;
            menu.transform.rotation = menu_pos.rotation;
            menu.SetActive(true);
            is_open_menu = true;
        }
        else if (Input.GetButtonDown("XRI_Left_PrimaryButton") && is_open_menu)
        {
            audioSources[1].Play();
            menu.SetActive(false);
            is_open_menu = false;
        }
    }
    void open_tool_menu()
    {
        if (Input.GetButtonDown("XRI_Right_PrimaryButton") && !is_tools_open)
        {
            audioSources[0].Play();
            tools_menu.transform.position = tools_menu_pos.position;
            tools_menu.transform.rotation = tools_menu_pos.rotation;
            for (int i = 0; i < tools_pos.Length; i++)
            {
                ChangeLayerRecursively(tools[i], 5); //ui

                tools[i].SetActive(true);
                tools[i].transform.position = tools_pos[i].position;
                tools[i].transform.rotation = tools_pos[i].rotation;
                tools[i].GetComponent<Rigidbody>().useGravity = false;
                tools[i].GetComponent<Rigidbody>().velocity = Vector3.zero;
            }
            tools_menu.SetActive(true);
            is_tools_open = true;
        }
        else if(Input.GetButtonDown("XRI_Right_PrimaryButton") && is_tools_open) //아무것도 집지 않았을경우
        {
            audioSources[1].Play();
            tools_menu.SetActive(false);
            for (int i = 0; i < tools_pos.Length; i++)
            {
                tools[i].SetActive(false);
            }
            is_tools_open = false;
        }
    }
    public void open_tool_false()
    {
        tools_menu.SetActive(false);
        is_tools_open = false;
    }
    public void open_menu_false()
    {
        menu.SetActive(false);
        is_open_menu = false;
    }

    public void ChangeLayer_grabble(int tools_num)
    {
        ChangeLayerRecursively(tools[tools_num], 10); //grabbale
    }

    private void ChangeLayerRecursively(GameObject obj, int layer) //재귀함수로 모든 하위 오브젝트 레이어 변경
    {
        obj.layer = layer;

        foreach (Transform child in obj.transform)
        {
            ChangeLayerRecursively(child.gameObject, layer);
        }
    }
}
