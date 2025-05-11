using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverController : MonoBehaviour
{
    public LevelOverController levelController;
    public Button RestartButton;
    public Button QuitButton;

    private void Awake()
    {
        RestartButton.onClick.AddListener(RestartLevel);
        QuitButton.onClick.AddListener(ReturnToMainMenu);
    }

    private void ReturnToMainMenu()
    {
        gameObject.SetActive(false);
        SceneManager.LoadScene(0);
    }

    public void PlayerDied()
    {
        gameObject.SetActive(true);
    }

    public void RestartLevel()
    {
        levelController.ReloadLevel();
    }
}
