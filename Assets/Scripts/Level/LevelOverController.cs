using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<PlayerController>() != null)
        {
            int Scene = SceneManager.GetActiveScene().buildIndex;
            if (Scene < SceneManager.sceneCountInBuildSettings)
            {
                LevelManager.Instance.MarkCurrentLevelComplete();
                SceneManager.LoadScene(Scene + 1);

            }
            else
            {
                Debug.Log("All levels completed");
            }
        }
    }

    public void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Debug.Log("Scene Restarted");
    }
}
