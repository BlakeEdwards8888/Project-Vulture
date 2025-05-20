using System.Collections;
using UnityEngine;

namespace Combat
{
    public class Health : MonoBehaviour
    {
        [SerializeField] int startingHealth;
        [field: SerializeField] public Shield Shield { get; private set; }

        int currentHealth;

        private void Awake()
        {
            currentHealth = startingHealth;
        }

        public void TakeDamage(int amount)
        {
            currentHealth -= amount;
            Debug.Log($"{gameObject.name} took {amount} damage, {currentHealth} health remaining");
        }
    }
}
