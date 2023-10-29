using Leopotam.Ecs;
using Unity.VisualScripting;
using UnityEngine;
using YohohoTest;

public class CreateTradeSystem : IEcsRunSystem
{
    private EcsFilter<TradeZone, ItemStorage> _filter;
    public void Run()
    {
        foreach(var index in _filter)
        {
            var tradeOperation = new TradeOperation();
            ref var entity = ref _filter.GetEntity(index);
            ref var itemsToSell = ref _filter.Get2(index).BoundedStack;

            for(var i = 0; i < itemsToSell.Count; i++)
            {
                var itemEntity = itemsToSell.Pop();
                var itemCost = itemEntity.Get<Item>().Cost;
                tradeOperation.Value += itemCost;
                var view = itemEntity.Get<ItemViewRef>().View;
                Object.Destroy(view.gameObject);
                itemEntity.Destroy();
            }

            entity.Replace(tradeOperation);
        }
    }    
}
