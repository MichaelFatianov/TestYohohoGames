using UnityEngine;

namespace YohohoTest
{
    [CreateAssetMenu(fileName = "GameSettings", menuName = "Data/GameSettings")]
    public class Settings : ScriptableObject
    {
        [SerializeField] private float _playerSpeed;
        [SerializeField] private float _caseSpawnTimer;
        [SerializeField] private int _stackCapacity;

        [SerializeField] private ItemView _moneyCasePrefab;

        public float PlayerSpeed => _playerSpeed;

        public float CaseSpawnTimer => _caseSpawnTimer;

        public int StackCapacity  => _stackCapacity;

        public ItemView MoneyCasePrefab => _moneyCasePrefab;
    }
}
