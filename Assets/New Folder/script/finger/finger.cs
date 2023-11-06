using UnityEngine;
using UnityEngine.UI;

public class finger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Untagged"))
        {
            if (other.GetComponent<Button>() != null)
            {
                other.GetComponent<Button>().onClick.AddListener(on_click);
            }
        }
    }
    void on_click()
    {
        Debug.Log("gkgkgk");
    }
}
