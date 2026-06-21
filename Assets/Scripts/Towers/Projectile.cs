using Enemies;
using UnityEngine;

namespace Towers
{
    public class Projectile : MonoBehaviour
    {
        private Transform _target;
        [SerializeField] private float speed = 15f;
        [SerializeField] private int damage = 10;

    
        public void Seek(Transform targetEnemy)
        {
            _target = targetEnemy;
        }

        private void Update()
        {
            //If enemy dies before projectile hits, destroy it
            if (!_target)
            {
                Destroy(gameObject);
                return;
            }

            //Point toward the enemy
            Vector3 dir = _target.position - transform.position;
            if (dir != Vector3.zero)
            {
                transform.rotation = Quaternion.LookRotation(dir);
            }

            //Move toward target
            var distanceThisFrame = speed * Time.deltaTime;
            transform.Translate(dir.normalized * distanceThisFrame, Space.World);

            //Check collision
            if (Vector3.Distance(transform.position, _target.position) <= 0.3f)
            {
                HitTarget();
            }
        }

        private void HitTarget()
        {
            var enemyHealth = _target.GetComponent<EnemyHealth>();

            if (enemyHealth)
            {
                enemyHealth.TakeDamage(damage);
            }
        
            Destroy(gameObject);
        }
    }
}
