using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private static LevelManager instance;
    public static LevelManager Instance { get { return instance; } }

    public string[] Levels = { "Level1", "Level2", "Level3", "Level4", "Level5" };

    private void Awake()
    {
        //PlayerPrefs.DeleteAll(); // TODO: Remove - Only for DEBUG
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        if (GetLevelState(Levels[0]) == LevelStatus.Locked)
        {
            SetLevelState(Levels[0], LevelStatus.Unlocked);
        }
    }

    public void MarkCurrentLevelComplete()
    {
        Scene CurrentScene = SceneManager.GetActiveScene();
        SetLevelState(CurrentScene.name, LevelStatus.Completed);
        Debug.Log("Level Completed: " + CurrentScene.name);

        //int nextLevelIndex = CurrentScene.buildIndex + 1;
        //Scene NextScene = SceneManager.GetSceneByBuildIndex(nextLevelIndex);
        //SetLevelState(NextScene.name, LevelStatus.Unlocked);

        int CurrentSceneIndex = Array.FindIndex(Levels, x => x == CurrentScene.name);
        int NextSceneIndex = CurrentSceneIndex + 1;
        if (NextSceneIndex < Levels.Length)
        {
            SetLevelState(Levels[NextSceneIndex], LevelStatus.Unlocked);
        }
    }

    public LevelStatus GetLevelState(string Level)
    {
        LevelStatus levelStatus = (LevelStatus)PlayerPrefs.GetInt(Level, (int)LevelStatus.Locked);
        return levelStatus;
    }

    public void SetLevelState(string Level, LevelStatus levelStatus)
    {
        PlayerPrefs.SetInt(Level, (int)levelStatus);
    }

    public void LoadAnyLevel(int LevelIndex)
    {
        SceneManager.LoadScene(LevelIndex);
    }
}
