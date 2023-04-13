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

    Queue<GameObject> spawned_bullet = new Queue<GameObject>();
    //public static gun instance = null;
    //GameObject[] spawned_bullet;
    //GameObject spawned = null;

    //int num=0;

    private void Start()
    {
        //spawned_bullet = new GameObject[num];
    }

    GameObject creat_new_obj()
    {
        GameObject new_obj = Instantiate(bullet, barrel.position, barrel.rotation);
        new_obj.SetActive(false);
        return new_obj;
    }

    public void _fire()
    {
        if (spawned_bullet == null)
        {
            spawned_bullet[num] = Instantiate(bullet, barrel.position, barrel.rotation);
            spawned_bullet[num].GetComponent<Rigidbody>().velocity = speed * barrel.forward;
            audioSource.PlayOneShot(audioClip);
            StartCoroutine(spawned_bullet_co_ro(spawned_bullet[num]));
            num++;
        }
        else
        {
            spawned_bullet[num].SetActive(true);
            spawned_bullet[num].transform.position = barrel.position;
            spawned_bullet[num].transform.rotation = barrel.rotation;
            audioSource.PlayOneShot(audioClip);
            spawned_bullet[num].GetComponent<Rigidbody>().velocity = speed * barrel.forward;
            StartCoroutine(spawned_bullet_co_ro(spawned_bullet[num]));
        }



        //audioSource.PlayOneShot(audioClip);
        //Destroy(spawned_bullet, 2);
    }

    IEnumerator spawned_bullet_co_ro(GameObject bullet)
    {
        var wait = new WaitForSeconds(2);
        yield return wait;
        bullet.SetActive(false);
    }
}
