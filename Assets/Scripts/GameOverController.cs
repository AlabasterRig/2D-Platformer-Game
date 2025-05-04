using UnityEngine;
using UnityEngine.UI;

public class GameOverController : MonoBehaviour
{
    public LevelController levelController;
    public Button RestartButton;

    private void Awake()
    {
        RestartButton.onClick.AddListener(RestartLevel);
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
