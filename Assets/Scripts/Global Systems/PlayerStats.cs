using UnityEngine;
using UnityEngine.InputSystem;

namespace Global_Systems
{
    public class PlayerStats : MonoBehaviour
    {
        public static int Gold;
        [SerializeField] private int startGold = 400;

        public static int Lives;
        [SerializeField] private int startLives = 20;

        private void Awake()
        {
            Gold = startGold;
            Lives = startLives;
        }

        private void Update()
        {
            if (Debug.isDebugBuild && Keyboard.current != null && Keyboard.current.gKey.wasPressedThisFrame)
            {
                Gold += 100;
            }
        }
    }
}
