using UnityEngine;

namespace Combat
{
    public class Shield : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (!collision.TryGetComponent(out Hitbox hitbox)) return;
            if(hitbox.IsUnblockable) return;

            Physics2D.IgnoreCollision(collision, transform.root.GetComponent<Collider2D>());
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (!collision.TryGetComponent(out Hitbox hitbox)) return;
            if (hitbox.IsUnblockable) return;

            Physics2D.IgnoreCollision(collision, transform.root.GetComponent<Collider2D>(), false);
        }

        public bool IsBlocking(Collider2D collider)
        {
            if (GetComponent<Collider2D>().IsTouching(collider)) return true;
            return false;
        }
    }
}
