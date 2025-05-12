using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelFailedController : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<PlayerController>() != null)
        {
            SoundManager.Instance.Play(Sounds.PlayerDeath);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            Debug.Log("Player Died from falling!");
        }
    }
}
