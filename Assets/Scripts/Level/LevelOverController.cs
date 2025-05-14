using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelOverController : MonoBehaviour
{
    public GameObject levelCompleteUI;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>() != null)
        {
            //int Scene = SceneManager.GetActiveScene().buildIndex;
            //if (Scene < SceneManager.sceneCountInBuildSettings)
            //{
            //    LevelManager.Instance.MarkCurrentLevelComplete();
            //    SceneManager.LoadScene(Scene + 1);

            //}
            //else
            //{
            //    Debug.Log("All levels completed");
            //}
            SoundManager.Instance.Play(Sounds.LevelComplete);
            LevelManager.Instance.MarkCurrentLevelComplete();
            levelCompleteUI.SetActive(true);
            levelCompleteUI.GetComponent<LevelCompleteUIController>().ShowOnlyMainMenuIfLastLevel();
        }
    }

    public void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Debug.Log("Scene Restarted");
    }
}
