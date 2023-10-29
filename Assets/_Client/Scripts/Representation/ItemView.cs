using Leopotam.Ecs;
using UnityEngine;

public class ItemView : EntityView
{

    [SerializeField] private ItemType _itemType;

    protected override void Initialize(EcsEntity entity)
    {
        entity
            .Replace(new ItemViewRef { View = this });
    }
}
