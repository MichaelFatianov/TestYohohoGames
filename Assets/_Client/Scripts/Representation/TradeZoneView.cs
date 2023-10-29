using Leopotam.Ecs;
using System.Collections.Generic;
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
            .Replace(new ItemStack
            {
                Stack = new Stack<EcsEntity>(),
                ItemPlace = _itemsPosition,
                MaxCapacity = _maxCapacity,
                CurrentAmount = 0
            })
            .Replace(new TransferProvider
            {
                TransferType = TransferType.FromCollidedStack
            });
    }

}
