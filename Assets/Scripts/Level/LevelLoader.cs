using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Button))]
public class LevelLoader : MonoBehaviour
{
    private Button button;
    public string LevelName;

    private void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnClick);
    }

    private void OnClick()
    {
        LevelStatus levelStatus = LevelManager.Instance.GetLevelState(LevelName);
        switch(levelStatus)
        {
            case LevelStatus.Locked:
                Debug.Log("Level is locked");
                break;
            case LevelStatus.Unlocked:
                SoundManager.Instance.Play(Sounds.ButtonClick);
                SceneManager.LoadScene(LevelName);
                SoundManager.Instance.Play(Sounds.LevelStart);
                Debug.Log("Level is unlocked");
                break;
            case LevelStatus.Completed:
                SoundManager.Instance.Play(Sounds.ButtonClick);
                SceneManager.LoadScene(LevelName);
                SoundManager.Instance.Play(Sounds.LevelStart);
                Debug.Log("Level is completed");
                break;
        }
    }
}