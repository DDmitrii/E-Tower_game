using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    public float PlatformSpeedCoef = 1.0f;

    private void Start()
    {
        if (PlayerPrefs.HasKey("PlatformSpeed"))
        {
            PlatformSpeedCoef = PlayerPrefs.GetFloat("PlatformSpeed");
        }
    }

    public void SetHardSpeed()
    {
        PlatformSpeedCoef = 5.0f;
        PlayerPrefs.SetFloat("PlatformSpeed", PlatformSpeedCoef);
        RestartGame();
    }

    public void SetMediumSpeed()
    {
        PlatformSpeedCoef = 2.0f;
        PlayerPrefs.SetFloat("PlatformSpeed", PlatformSpeedCoef);
        RestartGame();
    }

    public void SetEasySpeed()
    {
        PlatformSpeedCoef = 1.0f;
        PlayerPrefs.SetFloat("PlatformSpeed", PlatformSpeedCoef);
        RestartGame();
    }

    private void RestartGame()
    {
        PlatformMove.score = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
