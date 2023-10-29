using Leopotam.Ecs;
using UnityEngine;
using YohohoTest;

public class ItemTransferSystem : IEcsRunSystem
{    
    private EcsFilter<ItemStack, TransferProvider>.Exclude<Player> _stackFilter;

    public void Run()
    {                   
        foreach (var index in _stackFilter)
        {
            var entity = _stackFilter.GetEntity(index);
            ref var itemStack = ref _stackFilter.Get1(index);
            ref var transferType = ref _stackFilter.Get2(index).TransferType;

            if (entity.Has<Collision>())
            {                
                ref var collision = ref entity.Get<Collision>();                

                var otherEntity = collision.Other;

                if (otherEntity.Has<ItemStack>())
                {
                    ref var otherStack = ref otherEntity.Get<ItemStack>();
                    
                    switch (transferType)
                    {
                        case TransferType.FromCollidedStack:

                            var itemStackSlots = itemStack.MaxCapacity - itemStack.Stack.Count;
                            if (itemStackSlots > 0 && otherStack.Stack.Count > 0)
                            {
                                var numberOfIterations = Mathf.Min(itemStackSlots, otherStack.Stack.Count);

                                Debug.Log("Transfer " + numberOfIterations + " items to StaticStack");

                                for (int i = 0; i < numberOfIterations; i++)
                                {
                                    var itemEntity = otherStack.Stack.Pop();
                                    itemStack.Stack.Push(itemEntity);
                                    itemEntity.Replace(new Transfer 
                                    { 
                                        From = otherStack,
                                        To = itemStack
                                    });                                   
                                }
                            }
                            break;

                        case TransferType.ToCollidedStack:

                            var otherStackSlots = otherStack.MaxCapacity - otherStack.Stack.Count;

                            if (otherStackSlots > 0 && itemStack.Stack.Count > 0)
                            {
                                var numberOfIterations = Mathf.Min(otherStackSlots, itemStack.Stack.Count);

                                Debug.Log("Transfer " + numberOfIterations + " items to CollidedStack");

                                for (int i = 0; i < numberOfIterations; i++)
                                {
                                    var itemEntity = itemStack.Stack.Pop();
                                    otherStack.Stack.Push(itemEntity);
                                    itemEntity.Replace(new Transfer
                                    {
                                        From = itemStack,
                                        To = otherStack
                                    });
                                }
                            }
                            break;
                    }
                }
            }
        }
    }
}
