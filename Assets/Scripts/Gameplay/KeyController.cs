using UnityEngine;
using System.Collections;

public class KeyController : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private Collider2D KeyCollider;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        KeyCollider = GetComponent<Collider2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>() != null)
        {
            PlayerController player = collision.gameObject.GetComponent<PlayerController>();
            player.PickUpKey();
            KeyCollider.enabled = false;
            StartCoroutine(AnimateAndDestroy());
        }
    }

    private IEnumerator AnimateAndDestroy()
    {
        float duration = 0.5f;
        float elapsed = 0f;

        Vector2 startPos = transform.position;
        Vector2 endPos = startPos + Vector2.up * 1.0f;
        Color startColor = spriteRenderer.color;
        Color endColor = new Color(startColor.r, startColor.g, startColor.b, 0f);

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            float t = elapsed / duration;

            transform.position = Vector2.Lerp(startPos, endPos, t);
            spriteRenderer.color = Color.Lerp(startColor, endColor, t);

            yield return null;
        }

        Destroy(gameObject);
    }
}
