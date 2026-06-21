using UnityEngine;

namespace Enemies
{
    public class WaypointPath : MonoBehaviour
    {
        public static Transform[] Waypoints;

        private void Awake()
        {
            Waypoints = new Transform[transform.childCount];
            for (var i = 0; i < transform.childCount; i++)
            {
                Waypoints[i] = transform.GetChild(i);
            }
        }
    }
}
