using System;
using UnityEditor.Search;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelCompleteUIController : MonoBehaviour
{
    public Button NextLevelButton;
    public Button MainMenuButton;

    private void Awake()
    {
        NextLevelButton.onClick.AddListener(NextLevel);
        MainMenuButton.onClick.AddListener(ReturnToMainMenu);
    }

    private void ReturnToMainMenu()
    {
        SoundManager.Instance.Play(Sounds.ButtonClick);
        SceneManager.LoadScene(0);
    }

    private void NextLevel()
    {
        SoundManager.Instance.Play(Sounds.ButtonClick);
        int Scene = SceneManager.GetActiveScene().buildIndex;
        if (Scene + 1 < SceneManager.sceneCountInBuildSettings)
        {
            LevelManager.Instance.MarkCurrentLevelComplete();
            SceneManager.LoadScene(Scene + 1);

        }
        else
        {
            Debug.Log("All levels completed");
        }
    }

    public void ShowOnlyMainMenuIfLastLevel()
    {
        int Scene = SceneManager.GetActiveScene().buildIndex;
        if (Scene + 1 < SceneManager.sceneCountInBuildSettings)
        {
            NextLevelButton.gameObject.SetActive(true);
        }
        else
        {
            NextLevelButton.gameObject.SetActive(false);
        }
    }
}
