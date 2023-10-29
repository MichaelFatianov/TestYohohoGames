using Leopotam.Ecs;
using UnityEngine;

public class TransferOperationSystem : IEcsRunSystem
{
    private EcsFilter<Transfer> _filter;

    public void Run()
    {
        foreach(var index in _filter)
        {
            ref var entity = ref _filter.GetEntity(index);
            ref var transfer = ref _filter.Get1(index);

            var fromStorage = transfer.From;
            var toStorage = transfer.To;
                
            var numberOfIterations = Mathf.Min(toStorage.BoundedStack.AvailableSlots, fromStorage.BoundedStack.Count);

            for (int i = 0; i < numberOfIterations; i++)
            {
                var itemEntity = fromStorage.BoundedStack.Pop();                
                var itemView = itemEntity.Get<ItemViewRef>().View;
                itemView.PositionInStack = toStorage.BoundedStack.Count;
                toStorage.BoundedStack.Push(itemEntity);

                itemEntity.Replace(new TransferAnimation
                {
                    Destination = toStorage.ItemPlace
                });
            }           
        }
    }
}
