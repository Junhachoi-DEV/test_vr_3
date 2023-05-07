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
    private Animator hand_anime;


    void Start()
    {
        try_initialize();
    }
    void try_initialize()
    {
        List<InputDevice> devices = new List<InputDevice>();

        InputDevices.GetDevicesWithCharacteristics(controller_char, devices);

        //����̽��� �Է¹�ư ���� ����׷� ����Ұ��̴�.
        foreach (var item in devices)
        {
            Debug.Log(item.name + item.characteristics);
        }

        if (devices.Count > 0)
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
                spawned_controller = Instantiate(controller_prefabs[0], transform);
            }
        }

        spawned_hand_model = Instantiate(hand_model_prefab, transform);
        hand_anime = spawned_hand_model.GetComponent<Animator>();
    }

    void update_hand_animation()
    {
        //�׸� ��ư �ִϸ��̼�
        if (target_device.TryGetFeatureValue(CommonUsages.grip, out float grip_value))
        {
            hand_anime.SetFloat("grip", grip_value);
        }
        else
        {
            hand_anime.SetFloat("grip", 0);
        }

        //Ʈ���� ��ư �ִϸ��̼�
        if (target_device.TryGetFeatureValue(CommonUsages.trigger, out float trigger_value))
        {
            hand_anime.SetFloat("trigger", trigger_value);
        }
        else
        {
            hand_anime.SetFloat("trigger", 0);
        }

    }

    // Update is called once per frame
    void Update()
    {
        #region �����.�α� �Է�Ű
        /*
        // x,y || a,b ��ư
        if (target_device.TryGetFeatureValue(CommonUsages.primaryButton, out bool primary_btn_value) &&primary_btn_value)
        {
            Debug.Log("pressing primary btn");
        }

        //��Ƽ� ��ư
        if(target_device.TryGetFeatureValue(CommonUsages.trigger, out float triger_value) && triger_value > 0.1f)
        {
            Debug.Log("trigger pressed " + triger_value);
        }

        //���̽�ƽ
        if(target_device.TryGetFeatureValue(CommonUsages.primary2DAxis, out Vector2 primary_2d_axis_value) && primary_2d_axis_value != Vector2.zero)
        {
            Debug.Log("primary touchpad " + primary_2d_axis_value);
        }
        */
        #endregion

        if (!target_device.isValid)
        {
            try_initialize();
        }
        else
        {
            if (show_controller) //��Ʈ�ѷ��� ������
            {
                spawned_hand_model.SetActive(false);
                spawned_controller.SetActive(true);
            }
            else //���� ������
            {
                spawned_hand_model.SetActive(true);
                spawned_controller.SetActive(false);
                update_hand_animation();
            }
        }
    }
}
