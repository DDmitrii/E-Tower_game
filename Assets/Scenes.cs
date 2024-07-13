using UnityEngine;
using UnityEngine.SceneManagement;

public class Scenes : MonoBehaviour
{
    public void ReastartLevel()
    {
        PlatformMove.score = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}