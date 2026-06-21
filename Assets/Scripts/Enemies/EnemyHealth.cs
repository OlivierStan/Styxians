using Global_Systems;
using UnityEngine;

namespace Enemies
{
    public class EnemyHealth : MonoBehaviour
    {
        [Header("Attributes")]
        public int maxHealth = 30;
        private int _currentHealth;

        [Header("Rewards")]
        public int goldReward = 25;

        private bool _isDead = false;

        private void Start()
        {
            _currentHealth = maxHealth;
        }

        public void TakeDamage(int amount)
        {
            if (_isDead) return;

            _currentHealth -= amount;

            if (_currentHealth <= 0)
            {
                Die();
            }
        }

        private void Die()
        {
            _isDead = true;
        
            //Award gold
            PlayerStats.Gold += goldReward;
        
            Destroy(gameObject);
        }
    }
}
