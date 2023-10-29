using Leopotam.Ecs;
using UnityEngine;
using YohohoTest;

public class SpawnView : EntityView
{
    [SerializeField] private TriggerView _triggerView;

    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private ItemType _itemType;

    [SerializeField] private int _maxCapacity;
    [SerializeField] private float _timerThreshold;

    protected override void Initialize(EcsEntity entity)
    {
        _triggerView.Initialize(entity);

        entity
            .Replace(new ItemSpawn 
            {  
                Type = _itemType 
            })
            .Replace(new Timer
            {
                Threshold = _timerThreshold,
                CurrentTime = 0f
            })
            .Replace(new ItemStorage
            {
                BoundedStack = new BoundedStack<EcsEntity>(_itemType.ToString(), _maxCapacity),
                ItemPlace = _spawnPoint,
            })
            .Replace(new TransferProvider
            {
                TransferType = TransferType.ToCollidedStorage
            });
    }
}
