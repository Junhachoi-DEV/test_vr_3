using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tree_lights : MonoBehaviour
{
    public GameObject[] lights;
    private void Start()
    {
        for (int i = 0; i < lights.Length; i++)
        {
            lights[i].SetActive(false);
        }
        StartCoroutine(light_on_co_ru());
    }
    IEnumerator light_on_co_ru()
    {
        while (true)
        {
            for (int i = 0; i < lights.Length; i++)
            {
                lights[i].SetActive(true);
                yield return yield_cache.WaitForSeconds(1f);
            }
            yield return yield_cache.WaitForSeconds(2f);
            for (int i = 0; i < lights.Length; i++)
            {
                lights[i].SetActive(false);
                yield return yield_cache.WaitForSeconds(1f);
            }
        }
    }
}
