using UnityEngine.SceneManagement;

public class manager : Singleton<manager>
{
    public void test_next_scene(int num)
    {
        SceneManager.LoadScene(num);
    }
}
