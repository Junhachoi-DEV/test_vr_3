using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class chair : MonoBehaviour
{
    public AudioSource[] audioSources;
    public GameObject[] chair_parts;
    public GameObject[] next_chir_parts;

    public GameObject chair_attach_timer_obj;
    public Image chair_attach_timer_img;
    public Text chair_attach_timer_txt;

    int part_num;
    public int count_num;

    public bool is_touch;
    public bool is_drilled;
    public bool is_counting;

    chair_part _chair_part;
    chuck_roller _chuck_roller;

    public void chair_part_active(bool value)
    {
        if (count_num < chair_parts.Length && !is_counting)
        {
            next_chir_parts[count_num].SetActive(value);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("chair_part") && is_touch)
        {
            _chair_part = other.GetComponent<chair_part>();
            part_num = _chair_part.part_num;
            if (part_num == count_num && !_chair_part.is_attach)
            {
                is_drilled = false;
                audioSources[0].Play();
                chair_parts[part_num].SetActive(true);
                next_chir_parts[part_num].SetActive(false);
                if (count_num < chair_parts.Length) { count_num++; } else { return; }
                StartCoroutine(coro_count_timer());
            }
        }
        if(other.CompareTag("chuck") && is_touch)
        {
            _chuck_roller =other.GetComponent<chuck_roller>();
            is_drilled = _chuck_roller.is_rolling;
            if (is_drilled)
            {
                if(count_num < chair_parts.Length) { next_chir_parts[count_num].SetActive(true); }
                audioSources[audioSources.Length-1].Play(); //드릴 사운드
                _chair_part.is_attach = false;
                chair_attach_timer_obj.SetActive(false);
                chair_attach_timer_img.fillAmount = 0;
                is_counting = false;
            }
        }
    }
    public void is_touch_bool(bool value)
    {
        is_touch = value;
    }

    IEnumerator coro_count_timer()
    {
        chair_attach_timer_obj.SetActive(true);
        is_counting = true;
        for (int i = 5; i >= 0; i--)
        {
            audioSources[2].Play(); // timer sound
            chair_attach_timer_txt.text = i.ToString();
            for (int j = 0; j < 10; j++)
            {
                //Debug.Log("ddd");
                chair_attach_timer_img.fillAmount += 0.1f;
                yield return yeild_controller.WaitForSeconds(0.1f);
                if (is_drilled) { break; }
            }
            chair_attach_timer_img.fillAmount = 0;
            if (is_drilled) { break; }
        }
        if (!is_drilled)
        {
            audioSources[1].Play();
            chair_attach_timer_obj.SetActive(false);
            chair_parts[part_num].SetActive(false);
            if (is_touch) { next_chir_parts[part_num].SetActive(true); }
            _chair_part.is_attach = true;
            _chair_part.gameObject.SetActive(true);
            _chair_part.gameObject.transform.position = chair_parts[part_num].transform.position;
            count_num--;
            yield return yeild_controller.WaitForSeconds(0.5f);
            _chair_part.is_attach = false;
        }
        yield return yeild_controller.WaitForSeconds(0.1f);
        is_drilled = false;
        is_counting = false;
    }
}
