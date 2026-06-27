using Global_Systems;
using TMPro;
using UnityEngine;

namespace UI
{
    public class LevelUI : MonoBehaviour
    {
        [Header("UI Text References")]
        [SerializeField] private TextMeshProUGUI goldText;
        [SerializeField] private TextMeshProUGUI livesText;

        private int _lastRecordedGold = -1;
        private int _lastRecordedLives = -1;

        private void Update()
        {
            if (PlayerStats.Gold != _lastRecordedGold)
            {
                _lastRecordedGold = PlayerStats.Gold;
                goldText.text = $"{_lastRecordedGold}";
            }

            if (PlayerStats.Lives == _lastRecordedLives) return;
            
            _lastRecordedLives = PlayerStats.Lives;

            livesText.text = $"{_lastRecordedLives}";
        }
    }
}
