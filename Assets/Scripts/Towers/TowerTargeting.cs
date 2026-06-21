using UnityEngine;
using UnityEngine.Serialization;

namespace Towers
{
    public class TowerTargeting : MonoBehaviour
    {
        [Header("Attributes")]
        [SerializeField] private float range = 10f;
        [SerializeField] private float fireRate = 1f;
        private float _fireCountdown = 0f;
        
        [Header("Setup Fields")]
        [SerializeField] private string enemyTag = "Enemy";
        [SerializeField] private GameObject projectilePrefab;
        [SerializeField] private Transform firePoint;
        
        private Transform _target;

        private void Start()
        {
            InvokeRepeating(nameof(UpdateTarget), 0f, 0.2f); //Scan 5 times a second
        }

        void UpdateTarget()
        {
            var enemies = GameObject.FindGameObjectsWithTag(enemyTag);
            var shortestDistance = Mathf.Infinity;
            GameObject nearestEnemy = null;

            foreach (var enemy in enemies)
            {
                var distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
                
                if (!(distanceToEnemy < shortestDistance)) continue;
                
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }

            if (nearestEnemy != null && shortestDistance <= range)
            {
                _target = nearestEnemy.transform;
            }
            else
            {
                _target = null;
            }
        }

        private void Update()
        {
            if (!_target) return;
        
            //Visual rotate
            Vector3 dir = _target.position - transform.position;
            Quaternion lookRotation = Quaternion.LookRotation(dir);
            Vector3 rotation = lookRotation.eulerAngles;
            transform.rotation = Quaternion.Euler(0f, rotation.y, 0f);
            
            //Firing Logic Cooldown
            if (_fireCountdown <= 0f)
            {
                Shoot();
                _fireCountdown = 1f / fireRate;
            }

            _fireCountdown -= Time.deltaTime;
        }

        void Shoot()
        {
            var projectileGo = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
            var projectile = projectileGo.GetComponent<Projectile>();

            if (projectile)
            {
                projectile.Seek(_target);
            }
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, range);
        }
    }
}
