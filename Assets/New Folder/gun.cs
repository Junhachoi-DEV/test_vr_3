using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gun : MonoBehaviour
{
    public float speed = 40;
    public GameObject bullet;
    public Transform barrel;
    public AudioSource audioSource;
    public AudioClip audioClip;

    //Queue<GameObject> spawned_bullet = new Queue<GameObject>();
    //public static gun instance = null;
    GameObject[] spawned_bullet;
    GameObject[] pool_bullet;
    //GameObject spawned = null;

    int num=10;

    private void Start()
    {
        spawned_bullet = new GameObject[num];

        generate();
    }

    void generate()
    {
        for (int i = 0; i < spawned_bullet.Length; i++)
        {
            spawned_bullet[i] = Instantiate(bullet);
        }
    }


    GameObject make_obj()
    {
        pool_bullet = spawned_bullet;
        for(int i = 0;i < pool_bullet.Length; i++)
        {
            if (!pool_bullet[i].gameObject.activeSelf)
            {
                pool_bullet[i].SetActive(true);
                return pool_bullet[i];
            }
        }
        return null;
    }
    GameObject[] get_pool()
    {
        return pool_bullet;
    }


    public void _fire()
    {
        StartCoroutine(spawned_bullet_co_ro());

    }

    IEnumerator spawned_bullet_co_ro()
    {
        GameObject bullet = make_obj();
        bullet.transform.position = barrel.position;
        bullet.transform.rotation = barrel.rotation;
        audioSource.PlayOneShot(audioClip);
        bullet.GetComponent<Rigidbody>().velocity = speed * barrel.forward;

        yield return yield_cache.WaitForSeconds(2);
        bullet.SetActive(false);
    }
}
