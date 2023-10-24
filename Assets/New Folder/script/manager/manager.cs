using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class manager : Singleton<manager>
{
    
    void Start()
    {
        Debug.Log("ddd");
    }
    public void test_next_scene(int num)
    {
        SceneManager.LoadScene(num);
    }
}
