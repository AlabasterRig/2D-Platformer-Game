using UnityEngine;

public class LevelButton : MonoBehaviour
{
    public int levelNumber;

    public void OnLevelButtonClick()
    {
        LevelManager.Instance.LoadAnyLevel(levelNumber);
    }
}
