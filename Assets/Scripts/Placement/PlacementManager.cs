using UnityEngine;
using UnityEngine.InputSystem;

namespace Placement
{
    public class PlacementManager : MonoBehaviour
    {
        public static PlacementManager Instance;

        [Header("Setup")]
        public LayerMask nodeLayer;
        public Camera mainCamera;

        [Header("Tower Prefabs (Temporary Test)")]
        public GameObject artemisBallistaPrefab;

        private GameObject _towerToBuild;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }

        private void Start()
        {
            if (mainCamera == null)
            {
                mainCamera = Camera.main;
            }
        
            SelectTowerToBuild(artemisBallistaPrefab);
        }

        private void Update()
        {
            if (Mouse.current != null && Mouse.current.leftButton.wasPressedThisFrame)
            {
                HandlePlacementInput();
            }
        }

        private void SelectTowerToBuild(GameObject towerPrefab)
        {
            _towerToBuild = towerPrefab;
        }

        private void HandlePlacementInput()
        {
            var mousePosition = Mouse.current.position.ReadValue();
            var ray = mainCamera.ScreenPointToRay(mousePosition);

            if (!Physics.Raycast(ray, out var hit, Mathf.Infinity, nodeLayer)) return;
        
            var targetNode = hit.collider.GetComponent<Node>();

            if (!targetNode) return;
            
            if (targetNode.currentTower)
            {
                return;
            }

            if (_towerToBuild)
            {
                BuildTowerOnNode(targetNode);
            }
        }

        private void BuildTowerOnNode(Node node)
        {
            var newTower = Instantiate(_towerToBuild, node.GetPlacementPosition(), Quaternion.identity);
        
            node.currentTower = newTower;
        }
    }
}
