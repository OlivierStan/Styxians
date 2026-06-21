using System.Collections;
using UnityEngine;

namespace Global_Systems
{
    public class WaveManager : MonoBehaviour
    {
        [System.Serializable]
        public struct Wave
        {
            public GameObject enemyPrefab;
            public int count;
            public float spawnRate;
        }

        [Header("Wave Configuration")]
        [SerializeField] private Wave[] waves;
        [SerializeField] private Transform spawnPoint;

        [Header("Timers")]
        [SerializeField] private float timeBetweenWaves = 10f;
        private float _waveCountdown = 0f;

        private int _currentWaveIndex = 0;
        private bool _isWaveSpawning = false;

        private void Start()
        {
            _waveCountdown = timeBetweenWaves;
        }

        private void Update()
        {
            if (_isWaveSpawning || _currentWaveIndex >= waves.Length) return;

            if (_waveCountdown <= 0f)
            {
                StartCoroutine(SpawnWave());
                _waveCountdown = timeBetweenWaves;
            }

            _waveCountdown -= Time.deltaTime;
        }

        private IEnumerator SpawnWave()
        {
            _isWaveSpawning = true;
            var currentWave = waves[_currentWaveIndex];
        
            for (int i = 0; i < currentWave.count; i++)
            {
                SpawnEnemy(currentWave.enemyPrefab);
            
                yield return new WaitForSeconds(currentWave.spawnRate);
            }

            _currentWaveIndex++;
            _isWaveSpawning = false;
        }

        private void SpawnEnemy(GameObject enemyPrefab)
        {
            Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
        }
    }
}
