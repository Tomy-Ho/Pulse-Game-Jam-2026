using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButtonManager : MonoBehaviour
{
    public void ButtonClicked()
    {
        SceneManager.LoadScene(2);
    }

    public void test()
    {
        Debug.Log("hi");
    }
}
