using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartGame : MonoBehaviour
{
    private bool isAlive = true;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && isAlive == false)
        {
            SceneManager.LoadScene(0);
        }
        else if (Input.GetKeyDown(KeyCode.K) && isAlive)
        {
            SceneManager.LoadScene(0);
        }
    }
}
