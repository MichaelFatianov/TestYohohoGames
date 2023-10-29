using Leopotam.Ecs;
using UnityEngine;
using YohohoTest;

public class CreateTransferSystem : IEcsRunSystem
{    
    private EcsFilter<ItemStorage, TransferProvider> _stackFilter;

    public void Run()
    {                   
        foreach (var index in _stackFilter)
        {
            var entity = _stackFilter.GetEntity(index);

            ref var itemStorage = ref _stackFilter.Get1(index);

            ref var transferType = ref _stackFilter.Get2(index).TransferType;

            if (entity.Has<Collision>())
            {                
                ref var collision = ref entity.Get<Collision>();                

                var otherEntity = collision.Other;

                if (otherEntity.Has<ItemStorage>())
                {
                    ref var otherStorage = ref otherEntity.Get<ItemStorage>();
                    
                        switch (transferType)
                        {
                            case TransferType.FromCollidedStorage:
                                if (itemStorage.BoundedStack.AvailableSlots > 0 && otherStorage.BoundedStack.Count > 0)
                                {
                                    entity.Replace(new Transfer
                                    {
                                        From = otherStorage,
                                        To = itemStorage
                                    });
                                }
                                    
                                break;

                            case TransferType.ToCollidedStorage:
                                if (otherStorage.BoundedStack.AvailableSlots > 0 && itemStorage.BoundedStack.Count > 0)
                                {
                                    entity.Replace(new Transfer
                                    {
                                        From = itemStorage,
                                        To = otherStorage
                                    });
                                }                                   
                                break;
                        }                                           
                }
            }
        }
    }
}
