using UnityEngine.SceneManagement;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene("FirstLevel");
        }
        else if (Input.GetKeyDown(KeyCode.X))
        {
            Application.Quit();
        }
    }
}