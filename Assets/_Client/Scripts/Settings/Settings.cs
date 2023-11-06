using UnityEngine;

namespace YohohoTest
{
    [CreateAssetMenu(fileName = "GameSettings", menuName = "Data/GameSettings")]
    public class Settings : ScriptableObject
    {
        [SerializeField] private float _playerSpeed;

        public float PlayerSpeed => _playerSpeed;
    }
}
