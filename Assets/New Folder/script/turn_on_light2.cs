using System.Collections;
using UnityEngine;

public class turn_on_light2 : MonoBehaviour
{
    public GameObject _light;

    public MeshRenderer light_renderer;
    public Material light_material;
    public Material nolight_material;


    private void OnTriggerEnter(Collider other)
    {
        if (gameObject.CompareTag("Untagged"))
        {
            _light.SetActive(true);
            light_renderer.material = light_material;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (gameObject.CompareTag("Untagged"))
        {
            StartCoroutine(co_light_turnoff());
        }
    }

    IEnumerator co_light_turnoff()
    {
        yield return new WaitForSeconds(1);
        _light.SetActive(false);
        light_renderer.material = nolight_material;
    }
}
