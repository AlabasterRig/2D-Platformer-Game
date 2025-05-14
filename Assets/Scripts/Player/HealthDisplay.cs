using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour
{
    public int Health;
    public int MaxHealth;

    public Sprite EmptyHeart;
    public Sprite FullHeart;
    public Image[] Hearts;

    public PlayerController playerController;

    private void Update()
    {
        Health = playerController.Health;
        MaxHealth = playerController.MaxHealth;
        for (int i = 0; i < Hearts.Length; i++)
        {
            if (i < Health)
            {
                Hearts[i].sprite = FullHeart;
            }
            else
            {
                Hearts[i].sprite = EmptyHeart;
            }
            if (i < MaxHealth)
            {
                Hearts[i].enabled = true;
            }
            else
            {
                Hearts[i].enabled = false;
            }
        }
    }
}
