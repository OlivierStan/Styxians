using Global_Systems;
using UnityEngine;

namespace Enemies
{
    public class EnemyMovement : MonoBehaviour
    {
        [SerializeField] private float speed = 5f;
        private int _wavePointIndex;

        private void Start()
        {
            transform.position = WaypointPath.Waypoints[0].position;
        }

        private void Update()
        {
            var dir = WaypointPath.Waypoints[_wavePointIndex].position - transform.position;
            transform.Translate(dir.normalized * (speed * Time.deltaTime), Space.World);

            if (Vector3.Distance(transform.position, WaypointPath.Waypoints[_wavePointIndex].position) <= 0.2f)
            {
                GetNextWaypoint();
            }
        }

        private void GetNextWaypoint()
        {
            if (_wavePointIndex >= WaypointPath.Waypoints.Length - 1)
            {
                //End of the path
                PlayerStats.Lives--;
                
                Destroy(gameObject);
                return;
            }
            _wavePointIndex++;
        }
    }
}
