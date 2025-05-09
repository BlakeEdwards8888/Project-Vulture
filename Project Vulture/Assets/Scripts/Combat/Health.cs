using System.Collections;
using UnityEngine;

namespace Combat
{
    public class Health : MonoBehaviour
    {
        [SerializeField] int startingHealth;

        [SerializeField] SpriteRenderer spriteRenderer;

        int currentHealth;

        private void Awake()
        {
            currentHealth = startingHealth;
        }

        public void TakeDamage(int amount)
        {
            currentHealth -= amount;
            Debug.Log($"{gameObject.name} took {amount} damage, {currentHealth} health remaining");
            if(spriteRenderer != null) StartCoroutine(SpriteFlash());
        }

        IEnumerator SpriteFlash()
        {
            Color defaultColor = spriteRenderer.color;

            spriteRenderer.color = Color.red;

            yield return new WaitForSeconds(0.2f);

            spriteRenderer.color = defaultColor;

            yield return null;
        }
    }
}
