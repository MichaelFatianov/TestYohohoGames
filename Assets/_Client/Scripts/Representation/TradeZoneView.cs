using Leopotam.Ecs;
using UnityEngine;
using YohohoTest;

public class TradeZoneView : EntityView
{
    [SerializeField] private TriggerView _triggerView;
    [SerializeField] private int _maxCapacity;

    [SerializeField] private Transform _itemsPosition;

    protected override void Initialize(EcsEntity entity)
    {
        _triggerView.Initialize(entity);

        entity
            .Replace(new TradeZone { })
            .Replace(new ItemStorage
            {
                BoundedStack = new BoundedStack<EcsEntity>("Trade Zone",_maxCapacity),
                ItemPlace = _itemsPosition,
            })
            .Replace(new TransferProvider
            {
                TransferType = TransferType.FromCollidedStorage
            });
    }

}
