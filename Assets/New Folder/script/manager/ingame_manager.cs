using UnityEngine;

public class ingame_manager : MonoBehaviour
{
    manager _manager;
    private void Awake()
    {
        _manager = FindObjectOfType<manager>();
    }
    public void test_next_scene_ing_mng(int num)
    {
        _manager.test_next_scene(num);
    }
}
