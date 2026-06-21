using UnityEngine;

namespace Placement
{
    public class Node : MonoBehaviour
    {
        [SerializeField] private Vector3 offsetPosition = new Vector3(0f, 0f, 0f);
        [HideInInspector] public GameObject currentTower;

        public Vector3 GetPlacementPosition()
        {
            return transform.position + offsetPosition;
        }
    }
}
