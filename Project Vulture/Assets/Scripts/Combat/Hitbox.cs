using System;
using UnityEngine;

namespace Combat
{
    public class Hitbox : MonoBehaviour
    {
        [field: SerializeField] public bool IsUnblockable { get; private set; }
        [SerializeField] int damage;
        [SerializeField] LayerMask hitFilter;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (!collision.TryGetComponent(out Health health)) return;

            //this checks to see if the layer of the other collider is contained in the hitFilter
            if ((hitFilter & (1 << collision.gameObject.layer)) != 0)
            {
                print($"Made contact with {collision.name}");
                health.TakeDamage(damage);
            }
        }
    }
}
