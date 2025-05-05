using System;
using UnityEngine;
using UnityEngine.UI;

public class LobbyController : MonoBehaviour
{
    public Button PlayButton;
    public Button QuitButton;
    public GameObject LevelSelection;

    private void Awake()
    {
        PlayButton.onClick.AddListener(PlayGame);
        QuitButton.onClick.AddListener(QuitGame);
    }

    private void QuitGame()
    {
        Application.Quit();
        Debug.Log("Game is exiting...");
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }

    private void PlayGame()
    {
        LevelSelection.SetActive(true);
    }

    
}
