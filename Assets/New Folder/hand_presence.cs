using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class hand_presence : MonoBehaviour
{
    public bool show_controller = false;
    public InputDeviceCharacteristics controller_char;
    public List<GameObject> controller_prefabs;
    public GameObject hand_model_prefab;

    private InputDevice target_device;
    private GameObject spawned_controller;
    private GameObject spawned_hand_model;

    void Start()
    {
        List<InputDevice> devices = new List<InputDevice>();
        
        InputDevices.GetDevicesWithCharacteristics(controller_char, devices);

        //디바이스의 입력버튼 값을 디버그로 출력할것이다.
        foreach (var item in devices)
        {
            Debug.Log(item.name + item.characteristics);
        }

        if(devices.Count > 0)
        {
            target_device = devices[0];
            GameObject prefab = controller_prefabs.Find(controller => controller.name == target_device.name);
            if (prefab)
            {
                spawned_controller = Instantiate(prefab, transform);
            }
            else
            {
                //Debug.LogError("did not find con~~");
                spawned_controller = Instantiate(controller_prefabs[0],transform); 
            }
        }

        spawned_hand_model = Instantiate(hand_model_prefab, transform);

    }

    // Update is called once per frame
    void Update()
    {
        /*
        // x,y || a,b 버튼
        if (target_device.TryGetFeatureValue(CommonUsages.primaryButton, out bool primary_btn_value) &&primary_btn_value)
        {
            Debug.Log("pressing primary btn");
        }

        //방아쇠 버튼
        if(target_device.TryGetFeatureValue(CommonUsages.trigger, out float triger_value) && triger_value > 0.1f)
        {
            Debug.Log("trigger pressed " + triger_value);
        }

        //조이스틱
        if(target_device.TryGetFeatureValue(CommonUsages.primary2DAxis, out Vector2 primary_2d_axis_value) && primary_2d_axis_value != Vector2.zero)
        {
            Debug.Log("primary touchpad " + primary_2d_axis_value);
        }
        */

        if (show_controller)
        {
            spawned_hand_model.SetActive(false);
            spawned_controller.SetActive(true);
        }
        else
        {
            spawned_hand_model.SetActive(true);
            spawned_controller.SetActive(false);
        }
    }
}
