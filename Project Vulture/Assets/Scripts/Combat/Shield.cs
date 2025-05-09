using UnityEngine;

namespace Combat
{
    public class Shield : MonoBehaviour
    {
        [SerializeField] SpriteRenderer spriteRenderer;

        Color defaultColor;

        private void Awake()
        {
            defaultColor = spriteRenderer.color;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (!collision.TryGetComponent(out Hitbox hitbox)) return;
            if(hitbox.IsUnblockable) return;

            spriteRenderer.color = Color.red;

            Debug.Log($"Shield Blocked {collision.name}");
            Physics2D.IgnoreCollision(collision, transform.root.GetComponent<Collider2D>());
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (!collision.TryGetComponent(out Hitbox hitbox)) return;
            if (hitbox.IsUnblockable) return;

            spriteRenderer.color = defaultColor;

            Physics2D.IgnoreCollision(collision, transform.root.GetComponent<Collider2D>(), false);
        }
    }
}
